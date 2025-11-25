<template>
  <div class="w-full">
    <div class="flex flex-col lg:flex-row md:items-center lg:justify-between gap-6">
          <div class="md:flex-1">
            <h1 class="text-2xl font-bold text-gray-900">
              Análisis de Capital de Trabajo
            </h1>
            
            <h2 class="text-sm font-bold text-gray-500">
              Indicadores del mes: 
              <span
                v-if="datos?.analisisFinal?.ultimoMes"
                class="text-blue-600 ml-2 capitalize"
              >
                ({{ datos?.analisisFinal?.ultimoMes }})
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
        <div class="grid grid-cols-1 md:grid-cols-3 lg:grid-cols-3 gap-5">

          <!-- Días Cartera -->
          <div class="stat-card border-l-4 border-blue-500">
            <div class="flex justify-between items-start mb-2">
              <div>
                <p class="text-xs font-bold text-gray-500 uppercase tracking-wider">
                  Cartera del mes  
                </p>
                <p class="text-xl font-bold text-blue-600 mt-1">
                  {{ formatCurrency(datos?.analisisFinal?.clientesUltimoMes) }}
                </p>
                <p  class="text-sm text-gray-500 font-semibold mt-1">
                  Promedio: {{ formatCurrency(datos?.analisisFinal?.clientesPromedio) }}
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
                  Proveedores 
                </p>
                <p class="text-xl font-bold text-emerald-600 mt-1">
                  {{ formatCurrency(datos?.analisisFinal?.proveedoresUltimoMes) }}
                </p>
                <p  class="text-sm text-gray-500 font-semibold mt-1">
                  Promedio: {{ formatCurrency(datos?.analisisFinal?.proveedoresPromedio) }}
                </p>
              </div>
              <div class="bg-emerald-100 p-1 rounded-lg">
                <Icon icon="fluent:person-money-24-regular" class="w-6 h-6 text-emerald-600" />
              </div>
            </div>
          </div>

          <!-- Banco -->
          <div class="stat-card border-l-4 border-sky-500">
            <div class="flex justify-between items-start mb-3">
              <div>
                <p class="text-xs font-bold text-gray-500 uppercase tracking-wider">
                  Banco
                </p>
                <p class="text-xl font-bold text-sky-600 mt-1">
                  {{ formatCurrency(datos?.analisisFinal?.bancoUltimoMes) }}
                </p>
                <p  class="text-sm text-gray-500 font-semibold mt-1">
                  Promedio: {{ formatCurrency(datos?.analisisFinal?.bancoPromedio) }}
                </p>
              </div>
              <div class="bg-sky-100 p-1 rounded-lg">
                <Icon icon="fluent:receipt-money-24-regular" class="w-6 h-6 text-sky-600" />
              </div>
            </div>
          </div>     
        </div>

         <!-- Seccion Charts -->

         <div class="flex justify-center mt-8 mb-8">
            <div class="w-full max-w-3xl px-4">
              <div class="bg-gradient-to-br from-white to-gray-50 p-6 rounded-2xl shadow-lg border border-gray-100 hover:shadow-xl transition-shadow duration-300">
                <div class="flex items-center justify-center gap-3 mb-6">
                  <div class="bg-indigo-100 p-2.5 rounded-lg">
                    <Icon icon="fluent:data-bar-vertical-24-regular" class="w-6 h-6 text-indigo-600" />
                  </div>
                  <h3 class="text-xl font-bold text-gray-800">Conversión del Efectivo</h3>
                </div>
                <div ref="chartAnalisisRef" class="w-full h-[420px]"></div>
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
import { buildAnalisisCharts } from "@/composables/Dashboard/Charts/analisisCharts";
import { formatearMoneda } from "@/utils/formatters";

const store = useDashboardStore();

const datos = ref(null);
const isLoading = ref(false);
const error = ref(null);

const chartAnalisisRef = ref(null);



// cards

const formatCurrency = (value) => {
  if (value === null || value === undefined || value === "-") return "-";
  return formatearMoneda(value);
};

onMounted(async () => {
  isLoading.value = true;
  error.value = null;


  try {
    // Si la cache no es valida, recargar datos
    if (store.isCacheValid && store.analisisData) {
      
      datos.value = store.analisisData;
      await nextTick();
      await buildAnalisisCharts({
        
        chartRef:chartAnalisisRef,
        clienteUltimoMes : datos.value.analisisFinal.clientesUltimoMes,
        proveedorUltimoMes: datos.value.analisisFinal.proveedoresUltimoMes,
        ventasUltimoMes : datos.value.analisisFinal.ventasUltimoMes,
        costoUltimoMes: datos.value.analisisFinal.costoUltimoMes,
        gastosUltimoMes : datos.value.analisisFinal.gastosUltimoMes,
        utilidadOperativa : datos.value.analisisFinal.utilidadOperativa  
      });

      return;
    }

    if (!store.analisisData) {
      throw new Error("No hay datos disponibles. Por favor, recarga la página o verifica que los datos se hayan cargado correctamente.");
    }
    
    datos.value = store.analisisData;

    await nextTick();

    await buildAnalisisCharts({
      
        chartRef: chartAnalisisRef,
        clienteUltimoMes : datos.value.analisisFinal.clientesUltimoMes,
        proveedorUltimoMes: datos.value.analisisFinal.proveedoresUltimoMes,
        ventasUltimoMes : datos.value.analisisFinal.ventasUltimoMes,
        costoUltimoMes: datos.value.analisisFinal.costoUltimoMes,
        gastosUltimoMes : datos.value.analisisFinal.gastosUltimoMes,
        utilidadOperativa : datos.value.analisisFinal.utilidadOperativa          
      });


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