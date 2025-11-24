<template>
  <div class="w-full">
    <div class="flex flex-col lg:flex-row md:items-center lg:justify-between gap-6">
          <div class="md:flex-1">
            <h1 class="text-2xl font-bold text-gray-900">
              Análisis de Ciclo Efectivo
            </h1>
            
            <h2 class="text-sm font-bold text-gray-500">
              Indicadores del mes: 
              <span
                v-if="datos?.cicloFinal?.ultimoMes"
                class="text-blue-600 ml-2 capitalize"
              >
                ({{ datos?.cicloFinal?.ultimoMes }})
              </span>
            </h2>
          </div>          
    </div>
    <!-- LOADING -->
    <div v-if="isLoading" class="flex flex-col items-center justify-center py-12">
      <div class="animate-spin rounded-full h-12 w-12 border-b-2 border-blue-600"></div>
      <p class="mt-4 text-gray-600 font-medium">Procesando datos...</p>
    </div>

    <!-- ERROR -->
    <div v-if="error" class="bg-red-50 border-l-4 border-red-500 text-red-800 p-4 mb-6 rounded-lg shadow-sm">
      <p class="font-bold">Error</p>
      <p class="text-sm">{{ error }}</p>
    </div>


    <!-- Contenido Principal  -->
    <div v-show="!isLoading && !error && datos">

      <!-- CARDS PRINCIPALES -->
      <div class="mb-8 mt-8">
        <div class="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-5 gap-5">

          <!-- Días Cartera -->
          <div class="stat-card border-l-4 border-blue-500">
            <div class="flex justify-between items-start mb-2">
              <div>
                <p class="text-xs font-bold text-gray-500 uppercase tracking-wider">
                  Días de Cartera 
                </p>
                <p class="text-xl font-bold text-blue-600 mt-1">
                  {{ datos?.cicloFinal?.diasCXC }}
                </p>
              </div>
              <div class="bg-blue-50 p-1 rounded-lg">
                <Icon icon="fluent:box-24-regular" class="w-6 h-6 text-blue-600" />
              </div>
            </div>
          </div>

          <!-- Días Proveedores -->
          <div class="stat-card border-l-4 border-emerald-500">
            <div class="flex justify-between items-start mb-3">
              <div>
                <p class="text-xs font-bold text-gray-500 uppercase tracking-wider">
                  Días Proveedores 
                </p>
                <p class="text-xl font-bold text-emerald-600 mt-1">
                  {{ datos?.cicloFinal?.diasCXP }}
                </p>
              </div>
              <div class="bg-emerald-100 p-1 rounded-lg">
                <Icon icon="fluent:person-money-24-regular" class="w-6 h-6 text-emerald-600" />
              </div>
            </div>
          </div>

          <!-- Días Ciclo Efectivo -->
          <div class="stat-card border-l-4 border-orange-500">
            <div class="flex justify-between items-start mb-3">
              <div>
                <p class="text-xs font-bold text-gray-500 uppercase tracking-wider">
                  Ciclo Efectivo
                </p>
                <p class="text-xl font-bold text-orange-600 mt-1">
                  {{ datos?.cicloFinal?.cicloEfectivo }}
                </p>
              </div>
              <div class="bg-red-100 p-1 rounded-lg">
                <Icon icon="fluent:receipt-money-24-regular" class="w-6 h-6 text-orange-600" />
              </div>
            </div>
          </div>

          <!-- Costo por dia -->
          <div class="stat-card border-l-4 border-red-500">
            <div class="flex justify-between items-start mb-3">
              <div>
                <p class="text-xs font-bold text-gray-500 uppercase tracking-wider">
                  Costo + Gasto x dia
                </p>
                <p class="text-xl font-bold text-red-600 mt-1">
                  {{ formatCurrency(datos?.cicloFinal?.costoGastoPorDia) }} 
                </p>
              </div>
              <div class="bg-red-100 p-1 rounded-lg">
                <Icon icon="fluent:arrow-sort-down-lines-24-filled" class="w-6 h-6 text-red-600" />
              </div>
            </div>
          </div>

          <!-- Capital de Trabajo -->
          <div class="stat-card border-l-4 border-purple-500">
            <div class="flex justify-between items-start mb-3">
              <div>
                <p class="text-xs font-bold text-gray-500 uppercase tracking-wider">
                  Capital de Trabajo
                </p>
                <p class="text-xl font-bold text-purple-600 mt-1">
                  {{ formatCurrency(datos?.cicloFinal?.capitalTrabajo) }} 
                </p>
              </div>
              <div class="bg-purple-100 p-1 rounded-lg">
                <Icon icon="fluent:money-hand-24-filled" class="w-6 h-6 text-purple-600" />
              </div>
            </div>
          </div>

        </div>

         <!-- Seccion Charts -->

        <div class="grid grid-cols-1 md:grid-cols-2 gap-2 mt-5 mb-8">
          <div class="bg-white p-4 rounded-xl shadow-sm">
            <h3 class="text-lg font-semibold mb-4 text-center">Conversion del Efectivo</h3>
            <div ref="chartCicloRef" class="w-full h-[350px]"></div>
          </div>

          <div class="bg-white p-4 rounded-xl shadow-sm">
            <h3 class="text-lg font-semibold mb-4 text-center">Capital de Trabajo en Circulacion</h3>
            <div ref="chartCapitalRef" class="w-full h-[350px]"></div>
          </div>
        </div>

        <div class="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-4 gap-5">

          <!-- Caja Minima -->
          <div class="stat-card border-l-4 border-rose-500">
            <div class="flex justify-between items-start mb-2">
              <div>
                <p class="text-xs font-bold text-gray-500 uppercase tracking-wider">
                  Caja Minima
                </p>
                <p class="text-xl font-bold text-rose-600 mt-1">
                  {{ datos?.cicloFinal?.cajaMinimaRequerida }}
                </p>
              </div>
              <div class="bg-rose-100 p-1 rounded-lg">
                <Icon icon="fluent:shield-task-24-regular" class="w-6 h-6 text-rose-600" />
              </div>
            </div>
          </div>

          <!-- Saldo Banco -->
          <div class="stat-card border-l-4 border-sky-500">
            <div class="flex justify-between items-start mb-3">
              <div>
                <p class="text-xs font-bold text-gray-500 uppercase tracking-wider">
                  Saldo Banco
                </p>
                <p class="text-xl font-bold text-sky-600 mt-1">
                  {{ datos?.cicloFinal?.saldoBanco }}
                </p>
              </div>
              <div class="bg-emerald-100 p-1 rounded-lg">
                <Icon icon="fluent:building-bank-24-regular" class="w-6 h-6 text-sky-600" />
              </div>
            </div>
          </div>

          <!-- capacidad de pago -->
          <div class="stat-card border-l-4"
               :class="datos?.cicloFinal?.capacidadPago >= 0 ? 'border-emerald-500' : 'border-red-500'">
            <div class="flex justify-between items-start mb-3">
              <div>
                <p class="text-xs font-bold text-gray-500 uppercase tracking-wider">
                  Capacidad de Pago
                </p>
                <p class="text-xl font-bold mt-1"
                :class="datos?.cicloFinal?.capacidadPago >= 0 ? 'text-emerald-600' : 'text-red-600'">
                  {{ datos?.cicloFinal?.capacidadPago }}
                </p>
              </div>
              <div  class="p-1 rounded-lg"
                :class="datos?.cicloFinal?.capacidadPago >= 0 ? 'bg-emerald-100' : 'bg-red-100'">
                <Icon
                    :icon="datos?.cicloFinal?.capacidadPago >= 0
                      ? 'fluent:arrow-growth-24-filled'
                      : 'fluent:arrow-trending-down-24-filled'"
                    class="w-6 h-6"
                    :class="datos?.cicloFinal?.capacidadPago >= 0 ? 'text-emerald-600' : 'text-red-600'"
                  />
              </div>
            </div>
          </div>

          <!-- Banco promedio -->
          <div class="stat-card border-l-4 border-indigo-500">
            <div class="flex justify-between items-start mb-3">
              <div>
                <p class="text-xs font-bold text-gray-500 uppercase tracking-wider">
                  Costo + Gasto x dia
                </p>
                <p class="text-xl font-bold text-indigo-600 mt-1">
                  {{ formatCurrency(datos?.cicloFinal?.bancoPromedio) }} 
                </p>
              </div>
              <div class="bg-indigo-100 p-1 rounded-lg">
                <Icon icon="fluent:data-bar-vertical-24-filled" class="w-6 h-6 text-indigo-600" />
              </div>
            </div>
          </div>

          

        </div>




      </div>

     

    </div>



  </div>
</template>

<script setup>
import { ref, onMounted , nextTick } from "vue";
import { Icon } from "@iconify/vue";
import { push } from "notivue";
import { useDashboardStore } from "@/stores/Composable/dashboard.store";
import { buildCicloCharts } from "@/composables/Dashboard/Charts/cicloCharts";
import { formatearMoneda } from "@/utils/formatters";
const store = useDashboardStore();

const datos = ref(null);
const isLoading = ref(false);
const error = ref(null);

const chartCicloRef = ref(null);
const chartCapitalRef= ref(null);


const formatCurrency = (value) => {
  if (value === null || value === undefined || value === "-") return "-";
  return formatearMoneda(value);
};

onMounted(async () => {
  isLoading.value = true;
  error.value = null;


  try {
    // Si la cache no es valida, recargar datos
    if (!store.isCacheValid && store.cicloEfectivoData) {
      await nextTick();
      await buildCicloCharts({
        mesesActivos: datos.value.mesesActivos,
        mensual: datos.value.ciclosMensual,
        chartCicloRef,
        chartCapitalTrabajoRef: chartCapitalRef,
      });

      return;
    }

    datos.value = store.cicloEfectivoData;

    await nextTick();

    await buildCicloCharts({
      mesesActivos: datos.value.mesesActivos,
      mensual: datos.value.ciclosMensual,
      chartCicloRef: chartCicloRef,
      chartCapitalTrabajoRef: chartCapitalRef
      ,});


    } catch (err) {
    console.error(err);

    push({
      type: "error",
      title: "Error al cargar datos de Ciclo Efectivo",
      text: err.message || "Ocurrió un error inesperado.",
      duration: 5000,
    });

    error.value = err;

  } finally {
    isLoading.value = false;
  }


});





// async function loadDataAndMap() {
//   loading.value = true;
//   try {
//     // 1) GeoJSON
//     const geoRes = await fetch(geoJsonUrl);
//     const geoJson = await geoRes.json();

//     // 2) API backend (normalizado)
//     const apiRes = await fetch(`${apiUrlBase}?tipoConexion=${encodeURIComponent(props.tipoCon)}`);
//     const apiData = await apiRes.json(); // asumiendo JSON puro: [{DPA_DESCAN, TotalGuardias}, ...]

//     // normalizar y emparejar
//     const seriesData = geoJson.features.map((f) => {
//       const nombre = (f.properties.DPA_DESCAN || "").toString().trim().toUpperCase();
//       const found = apiData.find(d => (d.DPA_DESCAN || "").toString().trim().toUpperCase() === nombre);
//       return {
//         name: nombre,
//         value: found ? Number(found.TotalGuardias) || 0 : 0,
//         rawFeature: f
//       };
//     });

//     // registrar mapa
//     echarts.registerMap("EcuadorCantones", geoJson);

//     // init chart
//     if (!chartInstance) {
//       chartInstance = echarts.init(chartRef.value);
//       window.addEventListener("resize", () => chartInstance && chartInstance.resize());
//     }

//     const option = {
//       title: { text: "Guardias por Cantón", left: "center" },
//       tooltip: { trigger: "item", formatter: (p) => `${p.name}<br/>Guardias: ${p.value}` },
//       visualMap: {
//         min: 0,
//         max: Math.max(...seriesData.map(d => d.value)) || 10,
//         left: "left",
//         bottom: "10",
//         text: ["Alto", "Bajo"],
//         calculable: true
//       },
//       series: [{
//         type: "map",
//         map: "EcuadorCantones",
//         roam: true,
//         emphasis: { label: { show: false } },
//         data: seriesData
//       }]
//     };

//     chartInstance.setOption(option);

//     // click handler
//     chartInstance.off("click");
//     chartInstance.on("click", async (params) => {
//       if (!params || !params.name) return;
//       // puedes solicitar detalle por canton (si tienes endpoint)
//       detailName.value = params.name;
//       // ejemplo: buscar en apiData o llamar otro endpoint
//       detailData.value = apiData.find(d => (d.DPA_DESCAN || "").toString().trim().toUpperCase() === params.name) || { message: "Sin datos" };
//       detailVisible.value = true;
//     });

//   } catch (err) {
//     console.error(err);
//   } finally {
//     loading.value = false;
//   }
// }


</script>

<style scoped>
.stat-card {
  @apply bg-white rounded-xl p-2 shadow-sm hover:shadow-lg transition-all duration-300 border border-gray-100;
}

.stat-card:hover {
  @apply transform -translate-y-1;
}

.percentage-badge {
  @apply px-3 py-1 rounded-full text-xs font-bold;
}
</style>


