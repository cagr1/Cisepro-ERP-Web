<template>
  <div
    class="flex-1 flex flex-col transition-all duration-300 w-full"
    id="mainContent"
  >
    <!-- <div class="w-full transition-all" id="mainContent"> -->
    <main class="w-full">
      <div class="mb-8 bg-white p-2 rounded-lg shadow-sm">
        <div
          class="flex flex-col lg:flex-row md:items-center lg:justify-between gap-6"
        >
          <div class="md:flex-1 ml-10">
            <h1 class="text-xl font-bold text-gray-900">Analisis de Partida</h1>
            <p class="text-gray-600 mt-1">Análisis Mensual</p>
          </div>
          <div
            class="flex flex-col md:flex-row gap-4 md:items-center md:flex-[2]"
          >
            <div
              class="flex-1 flex flex-col md:flex-row gap-3 items-start md:items-center"
            >
              <!-- Input Fecha Inicio -->
              <div class="w-full md:w-auto">
                <label class="block text-sm font-medium text-gray-700 mb-1"
                  >Fecha Inicial</label
                >
                <input
                  type="date"
                  v-model="startDate"
                  class="w-40 px-3 py-2 rounded-xl border border-slate-300 text-sm focus:ring-2 focus:ring-blue-500"
                />
              </div>

              <!-- Input Fecha Fin -->
              <div class="w-full md:w-auto">
                <label class="block text-sm font-medium text-gray-700 mb-1"
                  >Fecha Final</label
                >
                <input
                  type="date"
                  v-model="endDate"
                  class="w-40 px-3 py-2 rounded-xl border border-slate-300 text-sm focus:ring-2 focus:ring-blue-500"
                />
              </div>
            </div>

            <div class="md:self-end">
              <button
                @click="handleLoadData"
                :disabled="loading"
                class="bg-gradient-to-r from-blue-500 to-blue-600 hover:from-blue-600 hover:to-blue-700 text-white px-4 py-2.5 rounded-md text-sm font-medium shadow-lg hover:shadow-xl transition-all duration-300 transform hover:-translate-y-0.5 focus:ring-2 focus:ring-blue-300 focus:outline-none flex items-center"
              >
                <svg
                  class="w-5 h-5 mr-2 self-center"
                  viewBox="0 0 24 24"
                  fill="currentColor"
                  style="display: block; transform: translateY(1px)"
                >
                  <path
                    fill-rule="evenodd"
                    clip-rule="evenodd"
                    d="M1.85 7.5C1.85 4.66 4.06 1.85 7.5 1.85c2.78 0 4.15 2.06 4.74 3.15H10.5a.5.5 0 0 0 0 1h3a.5.5 0 0 0 .5-.5v-3a.5.5 0 0 0-1 0v1.81C12.3 3.07 10.67.85 7.5.85 3.44.85.85 4.19.85 7.5S3.44 14.15 7.5 14.15c1.94 0 3.56-.77 4.71-1.94.62-.63 1.1-1.37 1.43-2.17.1-.25-.02-.55-.27-.66-.25-.1-.54.02-.65.27-.28.68-.69 1.31-1.21 1.84-.97.99-2.34 1.65-4 1.65-3.44 0-5.65-2.81-5.65-5.65z"
                  />
                </svg>
                {{ loading ? "Cargando..." : "Actualizar" }}
              </button>
            </div>
          </div>
        </div>
      </div>

      <!-- Estado de carga -->
      <div
        v-if="isLoading"
        class="flex flex-col items-center justify-center py-12"
      >
        <div
          class="animate-spin rounded-full h-12 w-12 border-b-2 border-blue-600"
        ></div>
        <p class="mt-4 text-gray-600 font-medium">
          Procesando datos financieros...
        </p>
      </div>

      <!-- Error -->
      <div v-if="error" class="bg-red-50 border-l-4 border-red-500 text-red-800 p-4 mb-6 rounded-lg shadow-sm" role="alert">
        <div class="flex items-center">
          <svg class="w-5 h-5 mr-2" fill="currentColor" viewBox="0 0 20 20">
            <path fill-rule="evenodd" d="M10 18a8 8 0 100-16 8 8 0 000 16zM8.707 7.293a1 1 0 00-1.414 1.414L8.586 10l-1.293 1.293a1 1 0 101.414 1.414L10 11.414l1.293 1.293a1 1 0 001.414-1.414L11.414 10l1.293-1.293a1 1 0 00-1.414-1.414L10 8.586 8.707 7.293z" clip-rule="evenodd" />
          </svg>
          <div>
            <p class="font-bold">Error al cargar datos</p>
            <p class="text-sm">{{ error }}</p>
          </div>
        </div>
      </div>

      <!-- Contenido principal -->
      <div v-show="!loading && !error">
       <!-- KPIs Principales - Estilo de la imagen -->
        <div class="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-6 gap-4 mb-6">
          <!-- Días CXC -->
          <div class="kpi-card bg-gradient-to-br from-blue-50 to-blue-100 border-l-4 border-blue-600">
            <div class="flex items-start justify-between">
              <div class="flex-1">
                <div class="flex items-center gap-2 mb-2">
                  <div class="bg-blue-600 p-1.5 rounded-lg">
                    <svg class="w-5 h-5 text-white" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                      <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M12 8c-1.657 0-3 .895-3 2s1.343 2 3 2 3 .895 3 2-1.343 2-3 2m0-8c1.11 0 2.08.402 2.599 1M12 8V7m0 1v8m0 0v1m0-1c-1.11 0-2.08-.402-2.599-1M21 12a9 9 0 11-18 0 9 9 0 0118 0z" />
                    </svg>
                  </div>
                  <h3 class="text-sm font-bold text-gray-700 uppercase tracking-wide">Días CXC</h3>
                </div>
                <p class="text-3xl font-bold text-blue-700 mb-1">{{ getLastValue('diasCxc') }}</p>
                <p class="text-xs text-gray-600">días de cobro</p>
              </div>
            </div>
          </div>

          <!-- Días CXP -->
          <div class="kpi-card bg-gradient-to-br from-orange-50 to-orange-100 border-l-4 border-orange-600">
            <div class="flex items-start justify-between">
              <div class="flex-1">
                <div class="flex items-center gap-2 mb-2">
                  <div class="bg-orange-600 p-1.5 rounded-lg">
                    <svg class="w-5 h-5 text-white" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                      <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M17 9V7a2 2 0 00-2-2H5a2 2 0 00-2 2v6a2 2 0 002 2h2m2 4h10a2 2 0 002-2v-6a2 2 0 00-2-2H9a2 2 0 00-2 2v6a2 2 0 002 2zm7-5a2 2 0 11-4 0 2 2 0 014 0z" />
                    </svg>
                  </div>
                  <h3 class="text-sm font-bold text-gray-700 uppercase tracking-wide">Días CXP</h3>
                </div>
                <p class="text-3xl font-bold text-orange-700 mb-1">{{ getLastValue('diasCxp') }}</p>
                <p class="text-xs text-gray-600">días de pago</p>
              </div>
            </div>
          </div>

          <!-- Ciclo Efectivo -->
          <div class="kpi-card bg-gradient-to-br from-purple-50 to-purple-100 border-l-4 border-purple-600">
            <div class="flex items-start justify-between">
              <div class="flex-1">
                <div class="flex items-center gap-2 mb-2">
                  <div class="bg-purple-600 p-1.5 rounded-lg">
                    <svg class="w-5 h-5 text-white" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                      <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M4 4v5h.582m15.356 2A8.001 8.001 0 004.582 9m0 0H9m11 11v-5h-.581m0 0a8.003 8.003 0 01-15.357-2m15.357 2H15" />
                    </svg>
                  </div>
                  <h3 class="text-sm font-bold text-gray-700 uppercase tracking-wide">Ciclo Efectivo</h3>
                </div>
                <p class="text-3xl font-bold text-purple-700 mb-1">{{ getLastValue('cicloEfectivo') }}</p>
                <p class="text-xs text-gray-600">días</p>
              </div>
            </div>
          </div>
        </div>

        <!-- Fila de KPIs Secundarios -->
        <div class="grid grid-cols-1 md:grid-cols-2 gap-4 mb-6">
          <!-- Costo + Gasto por Día -->
          <div class="kpi-card bg-gradient-to-br from-emerald-50 to-emerald-100 border-l-4 border-emerald-600">
            <div class="flex items-start justify-between">
              <div class="flex-1">
                <div class="flex items-center gap-2 mb-2">
                  <div class="bg-emerald-600 p-1.5 rounded-lg">
                    <svg class="w-5 h-5 text-white" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                      <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 7h6m0 10v-3m-3 3h.01M9 17h.01M9 14h.01M12 14h.01M15 11h.01M12 11h.01M9 11h.01M7 21h10a2 2 0 002-2V5a2 2 0 00-2-2H7a2 2 0 00-2 2v14a2 2 0 002 2z" />
                    </svg>
                  </div>
                  <h3 class="text-sm font-bold text-gray-700 uppercase tracking-wide">Costo + Gasto x Día</h3>
                </div>
                <p class="text-3xl font-bold text-emerald-700 mb-1">{{ formatCurrency(getLastValue('costoGastoPorDia')) }}</p>
                <p class="text-xs text-gray-600">promedio diario</p>
              </div>
            </div>
          </div>

          <!-- Capital de Trabajo -->
          <div class="kpi-card bg-gradient-to-br from-indigo-50 to-indigo-100 border-l-4 border-indigo-600">
            <div class="flex items-start justify-between">
              <div class="flex-1">
                <div class="flex items-center gap-2 mb-2">
                  <div class="bg-indigo-600 p-1.5 rounded-lg">
                    <svg class="w-5 h-5 text-white" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                      <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M13 7h8m0 0v8m0-8l-8 8-4-4-6 6" />
                    </svg>
                  </div>
                  <h3 class="text-sm font-bold text-gray-700 uppercase tracking-wide">Capital de Trabajo</h3>
                </div>
                <p class="text-3xl font-bold text-indigo-700 mb-1">{{ formatCurrency(getLastValue('capitalTrabajo')) }}</p>
                <p class="text-xs text-gray-600">en circulación</p>
              </div>
            </div>
          </div>
        </div>

        <!-- Promedio Capital de Trabajo - Destacado -->
        <div v-if="datosFinancieros" class="bg-gradient-to-r from-blue-600 to-indigo-600 rounded-xl p-6 shadow-lg mb-6">
          <div class="flex items-center justify-between text-white">
            <div>
              <p class="text-sm font-semibold uppercase tracking-wide opacity-90">Promedio Capital de Trabajo</p>
              <p class="text-4xl font-bold mt-2">{{ formatCurrency(datosFinancieros.promedioCapitalTrabajo) }}</p>
            </div>
            <div class="bg-white bg-opacity-20 p-4 rounded-lg">
              <svg class="w-10 h-10 text-white" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 19v-6a2 2 0 00-2-2H5a2 2 0 00-2 2v6a2 2 0 002 2h2a2 2 0 002-2zm0 0V9a2 2 0 012-2h2a2 2 0 012 2v10m-6 0a2 2 0 002 2h2a2 2 0 002-2m0 0V5a2 2 0 012-2h2a2 2 0 012 2v14a2 2 0 01-2 2h-2a2 2 0 01-2-2z" />
              </svg>
            </div>
          </div>
        </div>
      
      </div>
    </main>
  </div>
</template>

<script setup>
import { useAuthStore } from "@/stores/auth.store";

import {
  ref,
  onMounted,
  computed,
  watch,
  nextTick,
  onBeforeUnmount,
} from "vue";
import { getDefaultDates, formatDateWithTime } from "@/utils/dateUtils";
import { useFinancialCalculations } from '@/api/Dashboard/financialCalculations';
import api from "@/api";
import { push } from "notivue";

const authStore = useAuthStore();
const tipoConexion = computed(() => authStore.selectedCompany || "Cisepro");



// Estados reactivos
const loading = ref(false);

const datosFinancieros = ref(null);
const startDate = ref("");
const endDate = ref("");


const {
  procesarData,
  isLoading,
  error,
  formatearMoneda
} = useFinancialCalculations();




// Formateador de moneda
const formatCurrency = (value) => {
  return new Intl.NumberFormat("en-US", {
    style: "currency",
    currency: "USD",
  }).format(value);
};



// Configurar fechas iniciales
const setDefaultDates = () => {
  const { startDate: defaultStart, endDate: defaultEnd } = getDefaultDates();
  startDate.value = defaultStart;
  endDate.value = defaultEnd;
};

// Obtener el último valor de un indicador
const getLastValue = (key) => {
  if (!datosFinancieros.value?.cicloEfectivo?.length) return '-';
  const lastMonth = datosFinancieros.value.cicloEfectivo[datosFinancieros.value.cicloEfectivo.length - 1];
  return lastMonth[key] ?? '-';
};


// Función para cargar datos
const handleLoadData = async () => {
  loading.value = true;
  error.value = null;

  try {
    if (!startDate.value || !endDate.value) {
      push.error("Error al cargar datos: ", {
        title: "Error",
        message:
          "Por favor, selecciona una fecha de inicio y una fecha de fin.",
      });
    }

   datosFinancieros.value = await procesarData(startDate.value, endDate.value);
   console.log('Datos procesados:', datosFinancieros.value);
  } catch (err) {
    push.error("Error al cargar datos: ", {
      title: "Error",
      message: error.message || "Ocurrió un error al cargar los datos.",
    });
  } finally {
    loading.value = false;
  }
};



// Manejar redimensionamiento de la ventana
const handleResize = () => {
  resizeAllCharts();
};

// Limpiar al desmontar el componente
onBeforeUnmount(() => {
  window.removeEventListener("resize", handleResize);
  disposeAllCharts();
});

// Inicializar fechas por defecto
onMounted(() => {
  setDefaultDates();
});
</script>

<style scoped>
body {
  font-family: "Inter", system-ui, sans-serif;
}

.chart-container {
  position: relative;
}

.chart-container > div {
  width: 100% !important;
  height: 100% !important;
}

.cards-container {
  display: grid;
  grid-template-columns: repeat(auto-fit, minmax(260px, 1fr));
  gap: 1.2rem;
  padding: 0.8rem;
  font-family: "Segoe UI", system-ui, sans-serif;
}

.data-card {
  border-radius: 10px;
  padding: 0.8rem;
  box-shadow: 0 1px 2px rgba(0, 0, 0, 0.05);
  min-height: 90px;
  display: flex;
  flex-direction: column;
  justify-content: space-between;
  border-left: 5px solid;
  border-image: linear-gradient(to right, currentColor 50%, transparent 50%) 1;
  background: white;
  background-clip: padding-box;
  gap: 0.2rem;
  overflow: hidden;
  position: relative;
  transition: all 0.2s cubic-bezier(0.4, 0, 0.2, 1);
  flex: 1; /* Ocupa espacio disponible */
  min-width: 200px; /* Ancho mínimo consistente */
  border-radius: 0.75rem;
}

.data-card:hover {
  transform: translateY(-3px);
  box-shadow: 0 4px 16px rgba(0, 0, 0, 0.8);
}

.data-card:hover::after {
  content: "";
  position: absolute;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  background: rgba(255, 255, 255, 0.1);
  pointer-events: none;
}

.data-card.ingresos,
.data-card.ingresos .card-main-value {
  color: #3b82f6;
}

.data-card.ingresos {
  border-color: #3b82f6; /* Azul corporativo */
  background: linear-gradient(to right, #eff6ff 85%, #2563eb15);
}

.data-card.egresos,
.data-card.egresos .card-main-value {
  color: #dc2626;
}

.data-card.egresos {
  border-color: #dc2626;
  background: linear-gradient(to right, #fee2e2 85%, #dc262630);
}

.data-card.utilidad,
.data-card.utilidad .card-main-value {
  color: #10b981;
}

.data-card.utilidad {
  border-color: #10b981; /* Verde financiero */
  background: linear-gradient(to right, #d1fae5 85%, #05966915);
}

.data-card.patrimonio,
.data-card.patrimonio .card-main-value {
  color: #4f46e5;
}

.data-card.patrimonio {
  border-color: #4f46e5;
  background: linear-gradient(to right, #eef2ff 85%, #4f46e515);
}

.data-card.ingresos .card-divider {
  background: #3b82f6;
}
.data-card.egresos .card-divider {
  background: #dc2626;
}
.data-card.utilidad .card-divider {
  background: #059669;
}
.data-card.patrimonio .card-divider {
  background: #4f46e5;
}

.card-header {
  margin-bottom: 0.2rem;
  align-items: center;
  display: flex;
  justify-content: space-between;
}

.card-title {
  font-size: 0.75rem;
  font-family: "Segoe UI", system-ui, sans-serif;
  font-weight: 800;
  letter-spacing: 0.05em;
  text-transform: uppercase;
  margin-bottom: 0.25rem;
  color: #475569;
}

.card-main-value {
  font-size: 1.2rem;
  font-weight: 600;
  margin: 0.1rem 0;
}

.card-acumulado {
  font-size: 0.8rem;
  color: #64748b;
  margin-top: 0.25rem;
}

.card-divider {
  height: 1px;
  background: rgba(100, 116, 139, 0.2);
  margin: 0.25rem 0;
  border: none;
}

/* Nuevos estilos para variación */
.card-variacion {
  font-size: 0.75rem;
  font-weight: 600;
  padding: 0.15rem 0.35rem;
  border-radius: 4px;
  display: inline-flex;
  align-items: center;
  gap: 0.2rem;
}

.card-variacion::before {
  content: "▲";
  font-size: 0.6rem;
}

.card-variacion.negative::before {
  content: "▼";
}

.card-variacion.positive {
  background: #dcfce7;
  color: #166534;
}

.card-variacion.negative {
  background: #fee2e2;
  color: #991b1b;
}

.card-secondary-info {
  display: flex;
  justify-content: space-between;
  align-items: center;
}

.data-card.ingresos .card-divider {
  background: #3b82f6;
}

.data-card.egresos .card-divider {
  background: #ef4444;
}

.data-card.utilidad .card-divider {
  background: #10b981;
}

.data-card.capital .card-divider {
  background: #64748b;
}

.card-meta {
  display: flex;
  justify-content: space-between;
  font-size: 0.85rem;
  color: #64748b;
}

.card-year {
  font-weight: 600;
  color: #334155;
}

/* Nuevas clases para los indicadores */
.data-card.margen,
.data-card.margen .card-main-value {
  color: #059669;
}

.data-card.margen {
  border-color: #059669;
  background: linear-gradient(to right, #d1fae5 85%, #05966915);
}

.data-card.liquidez,
.data-card.liquidez .card-main-value {
  color: #d97706;
}

.data-card.liquidez {
  border-color: #d97706;
  background: linear-gradient(to right, #ffedd5 85%, #d9770615);
}

.data-card.endeudamiento,
.data-card.endeudamiento .card-main-value {
  color: #dc2626;
}

.data-card.endeudamiento {
  border-color: #dc2626;
  background: linear-gradient(to right, #fee2e2 85%, #dc262615);
}

.data-card.eficiencia,
.data-card.eficiencia .card-main-value {
  color: #4f46e5;
}

.data-card.eficiencia {
  border-color: #4f46e5;
  background: linear-gradient(to right, #eef2ff 85%, #4f46e515);
}

.data-card.rentabilidad,
.data-card.rentabilidad .card-main-value {
  color: #d97706;
}

.data-card.rentabilidad {
  border-color: #d97706;
  background: linear-gradient(to right, #fef3c7 85%, #d9770615);
}

/* Divisores específicos */
.data-card.margen .card-divider {
  background: #059669;
}
.data-card.liquidez .card-divider {
  background: #d97706;
}
.data-card.endeudamiento .card-divider {
  background: #dc2626;
}
.data-card.eficiencia .card-divider {
  background: #4f46e5;
}
.data-card.rentabilidad .card-divider {
  background: #d97706;
}

@media (min-width: 1024px) {
  .cards-container {
    grid-template-columns: repeat(4, minmax(0, 1fr)); /* Grid simétrico */
    gap: 2rem;
  }
}
</style>
