<template>
  <div class="flex-1 flex flex-col transition-all duration-300 w-full">
    <main class="w-full p-4">
      <!-- Header con controles -->
      <div class="mb-6 bg-white p-4 rounded-xl shadow-sm border border-gray-100">
        <div class="flex flex-col lg:flex-row md:items-center lg:justify-between gap-6">
          <div class="md:flex-1">
            <h1 class="text-2xl font-bold text-gray-900">Análisis de Partidas Operativas</h1>
            <p class="text-gray-500 mt-1">Indicadores de productividad y desempeño económico</p>
          </div>
          
          <div class="flex flex-col md:flex-row gap-4 md:items-center">
            <div class="flex gap-3 items-center">
              <!-- Fecha Inicio -->
              <div class="flex flex-col">
                <label class="text-xs font-semibold text-gray-600 mb-1.5">Fecha Inicial</label>
                <input 
                  type="date" 
                  v-model="startDate"
                  class="px-3 py-2 rounded-lg border border-gray-300 text-sm focus:ring-2 focus:ring-blue-500 focus:border-transparent transition-all"
                />
              </div>
              
              <!-- Fecha Fin -->
              <div class="flex flex-col">
                <label class="text-xs font-semibold text-gray-600 mb-1.5">Fecha Final</label>
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
                <svg class="w-4 h-4" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                  <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M4 4v5h.582m15.356 2A8.001 8.001 0 004.582 9m0 0H9m11 11v-5h-.581m0 0a8.003 8.003 0 01-15.357-2m15.357 2H15" />
                </svg>
                {{ isLoading ? 'Cargando...' : 'Actualizar' }}
              </button>
            </div>
          </div>
        </div>
      </div>

      <!-- Estado de carga -->
      <div v-if="isLoading" class="flex flex-col items-center justify-center py-12">
        <div class="animate-spin rounded-full h-12 w-12 border-b-2 border-blue-600"></div>
        <p class="mt-4 text-gray-600 font-medium">Procesando datos financieros...</p>
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

      <!-- Contenido Principal -->
      <div v-show="!isLoading && !error && datosFinancieros">
        
        <!-- Sección: Indicadores del Último Mes -->
        <div class="mb-8">
          <div class="flex items-center gap-3 mb-4">
            <div class="h-8 w-1 bg-blue-600 rounded-full"></div>
            <h2 class="text-xl font-bold text-gray-800">
              Indicadores del Último Mes
              <span v-if="datosFinancieros?.partidas?.ultimoMes" class="text-blue-600 ml-2 capitalize">
                ({{ datosFinancieros.partidas.ultimoMes.mes }})
              </span>
            </h2>
          </div>

          <div class="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-5">
            <!-- Ventas -->
            <div class="stat-card border-l-4 border-blue-500">
              <div class="flex justify-between items-start mb-3">
                <div>
                  <p class="text-xs font-bold text-gray-500 uppercase tracking-wider">Ventas</p>
                  <p class="text-2xl font-bold text-blue-600 mt-1">
                    {{ formatCurrency(datosFinancieros?.partidas?.ultimoMes?.ventas) }}
                  </p>
                </div>
                <div class="bg-blue-100 p-2 rounded-lg">
                  <svg class="w-6 h-6 text-blue-600" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M12 8c-1.657 0-3 .895-3 2s1.343 2 3 2 3 .895 3 2-1.343 2-3 2m0-8c1.11 0 2.08.402 2.599 1M12 8V7m0 1v8m0 0v1m0-1c-1.11 0-2.08-.402-2.599-1M21 12a9 9 0 11-18 0 9 9 0 0118 0z" />
                  </svg>
                </div>
              </div>
              <div class="text-xs text-gray-500">Ingresos del período</div>
            </div>

            <!-- Costo -->
            <div class="stat-card border-l-4 border-red-500">
              <div class="flex justify-between items-start mb-3">
                <div>
                  <p class="text-xs font-bold text-gray-500 uppercase tracking-wider">Costo</p>
                  <p class="text-2xl font-bold text-red-600 mt-1">
                    {{ formatCurrency(datosFinancieros?.partidas?.ultimoMes?.costo) }}
                  </p>
                </div>
                <div class="bg-red-100 p-2 rounded-lg">
                  <svg class="w-6 h-6 text-red-600" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 14l6-6m-5.5.5h.01m4.99 5h.01M19 21V5a2 2 0 00-2-2H7a2 2 0 00-2 2v16l3.5-2 3.5 2 3.5-2 3.5 2z" />
                  </svg>
                </div>
              </div>
              <div class="text-xs text-gray-500">Costo de ventas</div>
            </div>

            <!-- Gastos -->
            <div class="stat-card border-l-4 border-orange-500">
              <div class="flex justify-between items-start mb-3">
                <div>
                  <p class="text-xs font-bold text-gray-500 uppercase tracking-wider">Gastos</p>
                  <p class="text-2xl font-bold text-orange-600 mt-1">
                    {{ formatCurrency(datosFinancieros?.partidas?.ultimoMes?.gastos) }}
                  </p>
                </div>
                <div class="bg-orange-100 p-2 rounded-lg">
                  <svg class="w-6 h-6 text-orange-600" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M17 9V7a2 2 0 00-2-2H5a2 2 0 00-2 2v6a2 2 0 002 2h2m2 4h10a2 2 0 002-2v-6a2 2 0 00-2-2H9a2 2 0 00-2 2v6a2 2 0 002 2zm7-5a2 2 0 11-4 0 2 2 0 014 0z" />
                  </svg>
                </div>
              </div>
              <div class="text-xs text-gray-500">Gastos operativos</div>
            </div>

            <!-- Margen Bruto -->
            <div class="stat-card border-l-4 border-emerald-500">
              <div class="flex justify-between items-start mb-3">
                <div>
                  <p class="text-xs font-bold text-gray-500 uppercase tracking-wider">Margen Bruto</p>
                  <p class="text-2xl font-bold text-emerald-600 mt-1">
                    {{ formatCurrency(datosFinancieros?.partidas?.ultimoMes?.margenBruto) }}
                  </p>
                </div>
                <div class="bg-emerald-100 p-2 rounded-lg">
                  <svg class="w-6 h-6 text-emerald-600" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 19v-6a2 2 0 00-2-2H5a2 2 0 00-2 2v6a2 2 0 002 2h2a2 2 0 002-2zm0 0V9a2 2 0 012-2h2a2 2 0 012 2v10m-6 0a2 2 0 002 2h2a2 2 0 002-2m0 0V5a2 2 0 012-2h2a2 2 0 012 2v14a2 2 0 01-2 2h-2a2 2 0 01-2-2z" />
                  </svg>
                </div>
              </div>
              <div class="flex items-center gap-2">
                <span class="percentage-badge bg-emerald-100 text-emerald-700">
                  {{ formatPercentage(datosFinancieros?.partidas?.ultimoMes?.porcentajeMargenBruto) }}
                </span>
                <span class="text-xs text-gray-500">de las ventas</span>
              </div>
            </div>

            <!-- Utilidad Operativa -->
            <div class="stat-card border-l-4 border-purple-500">
              <div class="flex justify-between items-start mb-3">
                <div>
                  <p class="text-xs font-bold text-gray-500 uppercase tracking-wider">Utilidad Operativa</p>
                  <p class="text-2xl font-bold text-purple-600 mt-1">
                    {{ formatCurrency(datosFinancieros?.partidas?.ultimoMes?.utilidadOperativa) }}
                  </p>
                </div>
                <div class="bg-purple-100 p-2 rounded-lg">
                  <svg class="w-6 h-6 text-purple-600" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M13 7h8m0 0v8m0-8l-8 8-4-4-6 6" />
                  </svg>
                </div>
              </div>
              <div class="flex items-center gap-2">
                <span class="percentage-badge bg-purple-100 text-purple-700">
                  {{ formatPercentage(datosFinancieros?.partidas?.ultimoMes?.porcentajeUtilidadOperativa) }}
                </span>
                <span class="text-xs text-gray-500">de las ventas</span>
              </div>
            </div>
          </div>
        </div>

        <!-- Sección: Promedios del Período -->
        <div class="mb-8">
          <div class="flex items-center gap-3 mb-4">
            <div class="h-8 w-1 bg-indigo-600 rounded-full"></div>
            <h2 class="text-xl font-bold text-gray-800">
              Promedios del Período
              <span v-if="datosFinancieros?.partidas?.promedios" class="text-indigo-600 ml-2">
                ({{ datosFinancieros.partidas.promedios.numeroMeses }} meses)
              </span>
            </h2>
          </div>

          <div class="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-5">
            <!-- Venta Promedio -->
            <div class="stat-card border-l-4 border-cyan-500">
              <div class="flex justify-between items-start mb-3">
                <div>
                  <p class="text-xs font-bold text-gray-500 uppercase tracking-wider">Venta Promedio</p>
                  <p class="text-2xl font-bold text-cyan-600 mt-1">
                    {{ formatCurrency(datosFinancieros?.partidas?.promedios?.ventaPromedio) }}
                  </p>
                </div>
                <div class="bg-cyan-100 p-2 rounded-lg">
                  <svg class="w-6 h-6 text-cyan-600" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M7 12l3-3 3 3 4-4M8 21l4-4 4 4M3 4h18M4 4h16v12a1 1 0 01-1 1H5a1 1 0 01-1-1V4z" />
                  </svg>
                </div>
              </div>
              <div class="text-xs text-gray-500">Promedio mensual</div>
            </div>

            <!-- Costo Promedio -->
            <div class="stat-card border-l-4 border-rose-500">
              <div class="flex justify-between items-start mb-3">
                <div>
                  <p class="text-xs font-bold text-gray-500 uppercase tracking-wider">Costo Promedio</p>
                  <p class="text-2xl font-bold text-rose-600 mt-1">
                    {{ formatCurrency(datosFinancieros?.partidas?.promedios?.costoPromedio) }}
                  </p>
                </div>
                <div class="bg-rose-100 p-2 rounded-lg">
                  <svg class="w-6 h-6 text-rose-600" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 8h6m-5 0a3 3 0 110 6H9l3 3m-3-6h6m6 1a9 9 0 11-18 0 9 9 0 0118 0z" />
                  </svg>
                </div>
              </div>
              <div class="text-xs text-gray-500">Promedio mensual</div>
            </div>

            <!-- Gasto Promedio -->
            <div class="stat-card border-l-4 border-amber-500">
              <div class="flex justify-between items-start mb-3">
                <div>
                  <p class="text-xs font-bold text-gray-500 uppercase tracking-wider">Gasto Promedio</p>
                  <p class="text-2xl font-bold text-amber-600 mt-1">
                    {{ formatCurrency(datosFinancieros?.partidas?.promedios?.gastoPromedio) }}
                  </p>
                </div>
                <div class="bg-amber-100 p-2 rounded-lg">
                  <svg class="w-6 h-6 text-amber-600" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M12 8c-1.657 0-3 .895-3 2s1.343 2 3 2 3 .895 3 2-1.343 2-3 2m0-8c1.11 0 2.08.402 2.599 1M12 8V7m0 1v8m0 0v1m0-1c-1.11 0-2.08-.402-2.599-1M21 12a9 9 0 11-18 0 9 9 0 0118 0z" />
                  </svg>
                </div>
              </div>
              <div class="text-xs text-gray-500">Promedio mensual</div>
            </div>

            <!-- Utilidad Bruta Promedio -->
            <div class="stat-card border-l-4 border-teal-500">
              <div class="flex justify-between items-start mb-3">
                <div>
                  <p class="text-xs font-bold text-gray-500 uppercase tracking-wider">Utilidad Bruta Prom.</p>
                  <p class="text-2xl font-bold text-teal-600 mt-1">
                    {{ formatCurrency(datosFinancieros?.partidas?.promedios?.utilidadBrutaPromedio) }}
                  </p>
                </div>
                <div class="bg-teal-100 p-2 rounded-lg">
                  <svg class="w-6 h-6 text-teal-600" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M13 10V3L4 14h7v7l9-11h-7z" />
                  </svg>
                </div>
              </div>
              <div class="text-xs text-gray-500">Margen bruto mensual</div>
            </div>

            <!-- Utilidad Operativa Promedio -->
            <div class="stat-card border-l-4 border-violet-500">
              <div class="flex justify-between items-start mb-3">
                <div>
                  <p class="text-xs font-bold text-gray-500 uppercase tracking-wider">Util. Operativa Prom.</p>
                  <p class="text-2xl font-bold text-violet-600 mt-1">
                    {{ formatCurrency(datosFinancieros?.partidas?.promedios?.utilidadOperativaPromedio) }}
                  </p>
                </div>
                <div class="bg-violet-100 p-2 rounded-lg">
                  <svg class="w-6 h-6 text-violet-600" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 19v-6a2 2 0 00-2-2H5a2 2 0 00-2 2v6a2 2 0 002 2h2a2 2 0 002-2zm0 0V9a2 2 0 012-2h2a2 2 0 012 2v10m-6 0a2 2 0 002 2h2a2 2 0 002-2m0 0V5a2 2 0 012-2h2a2 2 0 012 2v14a2 2 0 01-2 2h-2a2 2 0 01-2-2z" />
                  </svg>
                </div>
              </div>
              <div class="flex items-center gap-2">
                <span class="percentage-badge bg-violet-100 text-violet-700">
                  {{ formatPercentage(datosFinancieros?.partidas?.promedios?.porcentajeUtilidadOperativaPromedio) }}
                </span>
                <span class="text-xs text-gray-500">de las ventas</span>
              </div>
            </div>
          </div>
        </div>

        <!-- Tarjeta Resumen Destacada -->
        <div class="bg-gradient-to-br from-slate-800 to-slate-900 rounded-2xl p-8 shadow-2xl">
          <div class="grid grid-cols-1 md:grid-cols-3 gap-8">
            <!-- Total Acumulado -->
            <div class="text-center border-r border-slate-700 last:border-r-0">
              <p class="text-slate-400 text-sm font-semibold uppercase tracking-wider mb-2">Ventas Acumuladas</p>
              <p class="text-white text-3xl font-bold">
                {{ formatCurrency(datosFinancieros?.partidas?.acumulados?.ventas) }}
              </p>
            </div>

            <div class="text-center border-r border-slate-700 last:border-r-0">
              <p class="text-slate-400 text-sm font-semibold uppercase tracking-wider mb-2">Utilidad Bruta Acum.</p>
              <p class="text-emerald-400 text-3xl font-bold">
                {{ formatCurrency(datosFinancieros?.partidas?.acumulados?.margenBruto) }}
              </p>
            </div>

            <div class="text-center">
              <p class="text-slate-400 text-sm font-semibold uppercase tracking-wider mb-2">Utilidad Operativa Acum.</p>
              <p class="text-purple-400 text-3xl font-bold">
                {{ formatCurrency(datosFinancieros?.partidas?.acumulados?.utilidadOperativa) }}
              </p>
            </div>
          </div>
        </div>
      </div>
    </main>
  </div>
</template>

<script setup>
import { ref, onMounted } from 'vue';
import { usePartidaCalculations } from '@/api/Dashboard/partidaCalculations';

const {
  procesarData,
  isLoading,
  error,
  formatearMoneda
} = usePartidaCalculations();

const datosFinancieros = ref(null);
const startDate = ref('');
const endDate = ref('');

// Inicializar fechas
const initializeDates = () => {
  const now = new Date();
  const firstDayOfYear = new Date(now.getFullYear(), 0, 1);
  
  startDate.value = firstDayOfYear.toISOString().split('T')[0];
  endDate.value = now.toISOString().split('T')[0];
};

// Formatear moneda
const formatCurrency = (value) => {
  if (value === null || value === undefined || value === '-') return '-';
  return formatearMoneda(value);
};

// Formatear porcentaje
const formatPercentage = (value) => {
  if (value === null || value === undefined) return '-';
  return `${value.toFixed(2)}%`;
};

// Cargar datos
const handleLoadData = async () => {
  try {
    datosFinancieros.value = await procesarData(startDate.value, endDate.value);
    console.log('Datos procesados:', datosFinancieros.value);
  } catch (err) {
    console.error('Error al cargar datos:', err);
  }
};

onMounted(() => {
  initializeDates();
  handleLoadData();
});
</script>

<style scoped>
.stat-card {
  @apply bg-white rounded-xl p-5 shadow-sm hover:shadow-lg transition-all duration-300 border border-gray-100;
}

.stat-card:hover {
  @apply transform -translate-y-1;
}

.percentage-badge {
  @apply px-3 py-1 rounded-full text-xs font-bold;
}
</style>