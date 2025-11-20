<template>
  <div class="w-full">
    <div
          class="flex flex-col lg:flex-row md:items-center lg:justify-between gap-6"
        >
          <div class="md:flex-1">
            <h1 class="text-2xl font-bold text-gray-900">
              Análisis de Ciclo Efectivo
            </h1>
            
            <h2 class="text-sm font-bold text-gray-500">
              Indicadores del mes: 
              <span
                v-if="datosFinancieros?.partidas?.ultimoMes"
                class="text-blue-600 ml-2 capitalize"
              >
                ({{ datosFinancieros.partidas.ultimoMes.mes }})
              </span>
            </h2>
          </div>

          <div class="flex flex-col md:flex-row gap-4 md:items-center">
            <div class="flex gap-3 items-center">
              <!-- Fecha Inicio -->
              <div class="flex flex-col">
                <label class="text-xs font-semibold text-gray-600 mb-1.5"
                  >Fecha Inicial</label
                >
                <input
                  type="date"
                  v-model="startDate"
                  class="px-3 py-2 rounded-lg border border-gray-300 text-sm focus:ring-2 focus:ring-blue-500 focus:border-transparent transition-all"
                />
              </div>

              <!-- Fecha Fin -->
              <div class="flex flex-col">
                <label class="text-xs font-semibold text-gray-600 mb-1.5"
                  >Fecha Final</label
                >
                <input
                  type="date"
                  v-model="endDate"
                  class="px-3 py-2 rounded-lg border border-gray-300 text-sm focus:ring-2 focus:ring-blue-500 focus:border-transparent transition-all"
                />
              </div>
            </div>

            <!-- Botón Actualizar -->
            <div class="md:self-end">
              <button
                @click="handleLoadData"
                :disabled="isLoading"
                class="bg-gradient-to-r from-blue-600 to-blue-700 hover:from-blue-700 hover:to-blue-800 disabled:from-gray-400 disabled:to-gray-500 text-white px-5 py-2.5 rounded-lg text-sm font-semibold shadow-md hover:shadow-lg transition-all duration-300 transform hover:-translate-y-0.5 disabled:transform-none flex items-center gap-2 whitespace-nowrap"
              >
                <svg
                  class="w-4 h-4"
                  fill="none"
                  stroke="currentColor"
                  viewBox="0 0 24 24"
                >
                  <path
                    stroke-linecap="round"
                    stroke-linejoin="round"
                    stroke-width="2"
                    d="M4 4v5h.582m15.356 2A8.001 8.001 0 004.582 9m0 0H9m11 11v-5h-.581m0 0a8.003 8.003 0 01-15.357-2m15.357 2H15"
                  />
                </svg>
                {{ isLoading ? "Cargando..." : "Actualizar" }}
              </button>
            </div>
          </div>
        </div>
  </div>
</template>

<script setup>
import { ref, onMounted, watch } from "vue";
import * as echarts from "echarts";
import api from "@/api";

const props = defineProps({
  tipoCon: { type: String, default: "Produccion" },
});

const chartRef = ref(null);
let chartInstance = null;
const loading = ref(false);
const geoJsonUrl = "https://raw.githubusercontent.com/.../ecuador-cantones.geojson"; // reemplaza por tu fuente ArcGIS


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
