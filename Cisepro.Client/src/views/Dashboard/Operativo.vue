<template>
  <div class="w-full">
    <div class="flex items-center justify-between mb-4">
      <h2 class="text-lg font-semibold">Dashboard Operativo</h2>
      <div v-if="loading" class="text-sm text-gray-500">Cargando...</div>
    </div>

    <div ref="chartRef" class="w-full h-[600px] rounded-md border border-gray-100"></div>

    <!-- Modal o panel de detalle (muy simple) -->
    <div v-if="detailVisible" class="mt-4 bg-white border rounded p-3 shadow">
      <h3 class="font-medium mb-2">Detalle: {{ detailName }}</h3>
      <pre class="text-sm text-gray-700">{{ detailData }}</pre>
      <button class="mt-2 px-3 py-1 bg-gray-100 rounded" @click="detailVisible = false">Cerrar</button>
    </div>
  </div>
</template>

<script setup>
import { ref, onMounted, watch } from "vue";
import * as echarts from "echarts";

const props = defineProps({
  tipoCon: { type: String, default: "Produccion" },
});

const chartRef = ref(null);
let chartInstance = null;
const loading = ref(false);
const geoJsonUrl = "https://raw.githubusercontent.com/.../ecuador-cantones.geojson"; // reemplaza por tu fuente ArcGIS
const apiUrlBase = "/api/dashboard/guardians-by-canton"; // ajusta según tu baseUrl

const detailVisible = ref(false);
const detailName = ref("");
const detailData = ref(null);

async function loadDataAndMap() {
  loading.value = true;
  try {
    // 1) GeoJSON
    const geoRes = await fetch(geoJsonUrl);
    const geoJson = await geoRes.json();

    // 2) API backend (normalizado)
    const apiRes = await fetch(`${apiUrlBase}?tipoConexion=${encodeURIComponent(props.tipoCon)}`);
    const apiData = await apiRes.json(); // asumiendo JSON puro: [{DPA_DESCAN, TotalGuardias}, ...]

    // normalizar y emparejar
    const seriesData = geoJson.features.map((f) => {
      const nombre = (f.properties.DPA_DESCAN || "").toString().trim().toUpperCase();
      const found = apiData.find(d => (d.DPA_DESCAN || "").toString().trim().toUpperCase() === nombre);
      return {
        name: nombre,
        value: found ? Number(found.TotalGuardias) || 0 : 0,
        rawFeature: f
      };
    });

    // registrar mapa
    echarts.registerMap("EcuadorCantones", geoJson);

    // init chart
    if (!chartInstance) {
      chartInstance = echarts.init(chartRef.value);
      window.addEventListener("resize", () => chartInstance && chartInstance.resize());
    }

    const option = {
      title: { text: "Guardias por Cantón", left: "center" },
      tooltip: { trigger: "item", formatter: (p) => `${p.name}<br/>Guardias: ${p.value}` },
      visualMap: {
        min: 0,
        max: Math.max(...seriesData.map(d => d.value)) || 10,
        left: "left",
        bottom: "10",
        text: ["Alto", "Bajo"],
        calculable: true
      },
      series: [{
        type: "map",
        map: "EcuadorCantones",
        roam: true,
        emphasis: { label: { show: false } },
        data: seriesData
      }]
    };

    chartInstance.setOption(option);

    // click handler
    chartInstance.off("click");
    chartInstance.on("click", async (params) => {
      if (!params || !params.name) return;
      // puedes solicitar detalle por canton (si tienes endpoint)
      detailName.value = params.name;
      // ejemplo: buscar en apiData o llamar otro endpoint
      detailData.value = apiData.find(d => (d.DPA_DESCAN || "").toString().trim().toUpperCase() === params.name) || { message: "Sin datos" };
      detailVisible.value = true;
    });

  } catch (err) {
    console.error(err);
  } finally {
    loading.value = false;
  }
}

onMounted(() => {
  loadDataAndMap();
});

// si tipoCon cambia recargar
watch(() => props.tipoCon, () => loadDataAndMap());
</script>

<style scoped>
/* nada extra: usamos Tailwind */
</style>
