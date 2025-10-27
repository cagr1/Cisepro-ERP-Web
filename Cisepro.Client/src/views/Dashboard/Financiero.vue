<template>
    <div class="flex-1 flex flex-col  transition-all duration-300 w-full" id="mainContent">
      <!-- <div class="w-full transition-all" id="mainContent"> -->
        <main class="w-full">
            <div class="mb-8 bg-white p-2 rounded-lg shadow-sm ">
                <div class="flex flex-col lg:flex-row md:items-center lg:justify-between gap-6">
                    <div class="md:flex-1 ml-10">
                        <h1 class="text-xl font-bold text-gray-900">Panel Financiero</h1>
                         <p class="text-gray-600 mt-1">Análisis mensual de partidas financieras</p>
                    </div>
                    <div class="flex flex-col md:flex-row gap-4 md:items-center md:flex-[2]">
                        <div class="flex-1 flex flex-col md:flex-row gap-3 items-start md:items-center">
                            <!-- Input Fecha Inicio -->
                            <div class="w-full md:w-auto">
                                <label class="block text-sm font-medium text-gray-700 mb-1">Fecha Inicial</label>
                                <input 
                                    type="date" 
                                    v-model="startDate"
                                    class="w-full md:w-[160px] p-1.5 border rounded-md focus:ring-2 focus:ring-blue-500 text-sm" 
                                />
                            </div>

                            <!-- Input Fecha Fin -->
                            <div class="w-full md:w-auto">
                                <label class="block text-sm font-medium text-gray-700 mb-1">Fecha Final</label>
                                <input 
                                    type="date" 
                                    v-model="endDate"
                                    class="w-full md:w-[160px] p-1.5 border rounded-md focus:ring-2 focus:ring-blue-500 text-sm" 
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
                                    style="display: block; transform: translateY(1px);"
                                >
                                    <path 
                                        fill-rule="evenodd" 
                                        clip-rule="evenodd" 
                                        d="M1.85 7.5C1.85 4.66 4.06 1.85 7.5 1.85c2.78 0 4.15 2.06 4.74 3.15H10.5a.5.5 0 0 0 0 1h3a.5.5 0 0 0 .5-.5v-3a.5.5 0 0 0-1 0v1.81C12.3 3.07 10.67.85 7.5.85 3.44.85.85 4.19.85 7.5S3.44 14.15 7.5 14.15c1.94 0 3.56-.77 4.71-1.94.62-.63 1.1-1.37 1.43-2.17.1-.25-.02-.55-.27-.66-.25-.1-.54.02-.65.27-.28.68-.69 1.31-1.21 1.84-.97.99-2.34 1.65-4 1.65-3.44 0-5.65-2.81-5.65-5.65z"
                                    />
                                </svg>
                                {{ loading ? 'Cargando...' : 'Actualizar' }}
                            </button>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Estado de carga -->
            <div v-if="loading" class="text-center py-4">
                <div class="inline-block animate-spin rounded-full h-8 w-8 border-t-2 border-b-2 border-blue-500"></div>
                <p class="mt-2 text-gray-600">Cargando datos...</p>
            </div>

            <!-- Error -->
            <div v-if="error" class="bg-red-100 border-l-4 border-red-500 text-red-700 p-4 mb-4" role="alert">
                <p class="font-bold">Error</p>
                <p>{{ error }}</p>
            </div>

            <!-- Contenido principal -->
            <div v-show="!loading && !error">
                <div class="cards-container">
                    <!-- Card Ventas Netas -->
                    <div class="data-card ingresos">
                        <div class="card-title">Venta Actual</div>
                        <div class="card-main-value">{{ formatCurrency(dashboardData.ventas.actual) }}</div>
                        <div class="card-secondary-info">
                            <div class="card-acumulado">{{ formatCurrency(dashboardData.ventas.acumulado) }} acumulado</div>
                            <div 
                                :class="['card-variacion', dashboardData.ventas.porcentajeActual >= 0 ? 'positive' : 'negative']"
                            >
                                {{ formatVariation(dashboardData.ventas.porcentajeActual) }}
                            </div>
                        </div>
                        <div class="card-divider"></div>
                        <div class="card-meta">
                            <span class="card-year card-year-actual">{{ currentYear }}</span>
                        </div>
                    </div>
                    
                    <div class="data-card ingresos">
                        <div class="card-title">Venta Anterior</div>
                        <div class="card-main-value">{{ formatCurrency(dashboardData.ventas.anterior) }}</div>
                        <div class="card-secondary-info">
                            <div class="card-acumulado">{{ formatCurrency(dashboardData.ventas.anteriorAcumulado) }} acumulado</div>
                            <div 
                                :class="['card-variacion', dashboardData.ventas.porcentajeAnterior >= 0 ? 'positive' : 'negative']"
                            >
                                {{ formatVariation(dashboardData.ventas.porcentajeAnterior) }}
                            </div>
                        </div>
                        <div class="card-divider"></div>
                        <div class="card-meta">
                            <span class="card-year card-year-previous">{{ previousYear }}</span>
                        </div>
                    </div>
                    
                    <!-- Utilidad -->
                    <div class="data-card patrimonio">
                        <div class="card-title">Utilidades</div>
                        <div class="card-main-value">{{ formatCurrency(dashboardData.utilidades.actuales) }}</div>
                        <div class="card-secondary-info">
                            <div class="card-acumulado">{{ formatCurrency(dashboardData.utilidades.acumuladas) }} acumulado</div>
                            <div 
                                :class="['card-variacion', dashboardData.utilidades.porcentaje >= 0 ? 'positive' : 'negative']"
                            >
                                {{ formatVariation(dashboardData.utilidades.porcentaje) }}
                            </div>
                        </div>
                        <div class="card-divider"></div>
                        <div class="card-meta">
                            <span class="card-year card-year-actual">{{ currentYear }}</span>
                        </div>
                    </div>

                    <div class="data-card margen">
                        <div class="card-title">Margen Neto</div>
                        <div class="card-main-value">{{ dashboardData.utilidades.margenNeto }}%</div>
                        <div class="card-secondary-info">
                            <div class="card-acumulado">Meta: 50.00%</div>
                            <div 
                                :class="['card-variacion', dashboardData.utilidades.variacionMargen >= 0 ? 'positive' : 'negative']"
                            >
                                {{ formatVariation(dashboardData.utilidades.variacionMargen) }}
                            </div>
                        </div>
                        <div class="card-divider"></div>
                        <div class="card-meta">
                            <span class="card-year card-year-actual">{{ currentYear }}</span>
                        </div>
                    </div>
                </div>

                <!-- Sección de Gráficos -->
                <div class="grid grid-cols-1 md:grid-cols-2 gap-4 mt-8">
                    <!-- Contenedor Gráfico Financiero -->
                    <div class="bg-white p-4 rounded-lg shadow-sm">
                        <h3 class="text-lg font-semibold mb-4 text-center">Ingresos, Egresos y Utilidades</h3>
                        <div class="chart-container" ref="financialChartRef" style="width: 100%; height: 400px;"></div>
                    </div>

                    <!-- Contenedor para otro gráfico -->
                    <div class="bg-white p-4 rounded-lg shadow-sm">
                        <h3 class="text-lg font-semibold mb-4 text-center">Ventas por Categoria</h3>
                        <div class="chart-container" ref="salesChartRef" style="width: 100%; height: 400px;"></div>
                    </div>
                </div>

                <div class="mt-8"></div>

                <div class="cards-container mb-8">
                    <div class="data-card liquidez">
                        <div class="card-title">LIQUIDEZ</div>
                        <div class="card-main-value">{{ dashboardData.utilidades.liquidez }}x</div>
                        <div class="card-secondary-info">
                            <div class="card-acumulado">Óptimo: 1.5</div>
                            <div 
                                :class="['card-variacion', dashboardData.utilidades.variacionLiquidez >= 0 ? 'positive' : 'negative']"
                            >
                                {{ formatVariation(dashboardData.utilidades.variacionLiquidez) }}
                            </div>
                        </div>
                        <div class="card-divider"></div>
                        <div class="card-meta">
                            <span class="card-year card-year-actual">{{ currentYear }}</span>
                        </div>
                    </div>
                    
                    <!-- Endeudamiento -->
                    <div class="data-card endeudamiento">
                        <div class="card-title">ENDEUDAMIENTO</div>
                        <div class="card-main-value" id="endeudamiento">38%</div>
                        <div class="card-secondary-info">
                            <div class="card-acumulado">Límite: 40%</div>
                            <div class="card-variacion positive">-2%</div>
                        </div>
                        <div class="card-divider"></div>
                        <div class="card-meta">
                            <span class="card-year card-year-actual">{{ currentYear }}</span>
                        </div>
                    </div>
                    
                    <!-- Eficiencia Operativa -->
                    <div class="data-card eficiencia">
                        <div class="card-title">EFICIENCIA OP.</div>
                        <div class="card-main-value" id="eficienciaOperativa">65%</div>
                        <div class="card-secondary-info">
                            <div class="card-acumulado">Mejora: 5%</div>
                            <div class="card-variacion positive">+3%</div>
                        </div>
                        <div class="card-divider"></div>
                        <div class="card-meta">
                            <span class="card-year card-year-actual">{{ currentYear }}</span>
                        </div>
                    </div>
                    
                    <!-- Rentabilidad Patrimonio -->
                    <div class="data-card rentabilidad">
                        <div class="card-title">RENTAB. PATRIM.</div>
                        <div class="card-main-value" id="rentabilidadPatrimonio">22%</div>
                        <div class="card-secondary-info">
                            <div class="card-acumulado">Sector: 18%</div>
                            <div class="card-variacion positive">+4%</div>
                        </div>
                        <div class="card-divider"></div>
                        <div class="card-meta">
                            <span class="card-year card-year-actual">{{ currentYear }}</span>
                        </div>
                    </div>
                </div>
            </div>
        </main>
    </div>
</template>
  

<script setup>
import { useAuthStore } from "@/stores/auth.store";
import { ref, onMounted, computed,watch, nextTick, onBeforeUnmount } from "vue";
import { getDefaultDates, formatDateWithTime } from '@/utils/dateUtils';
import {renderFinancialChart, renderSalesCategoryChart, resizeAllCharts, disposeAllCharts } from '@/utils/chart';
import api from "@/api"; // Importar la instancia de axios
import { push } from "notivue";

const authStore = useAuthStore();
const tipoConexion = computed(() => authStore.selectedCompany || "Cisepro");

// Estados reactivos
const loading = ref(false);
const error = ref(null);
const startDate = ref('');
const endDate = ref('');
const currentYear = ref(new Date().getFullYear());
const previousYear = ref(currentYear.value - 1);
const financialChartRef = ref(null);
const salesChartRef = ref(null);
const financialData = ref([]);
const salesData = ref([]);

// Actualizar años cuando cambia startDate
watch(startDate, (newDate) => {
  if (newDate) {
    const date = new Date(newDate + 'T00:00:00Z');
    currentYear.value = date.getUTCFullYear();
    previousYear.value = currentYear.value - 1;
  }
});


// Inicializar dashboardData con valores por defecto
const dashboardData = ref({
  ventas: {
    rangoActual: 0,
    acumuladoActual: 0,
    rangoAnterior: 0,
    acumuladoAnterior: 0,
    porcentajeActual: 0,
    porcentajeAnterior: 0
  },
  utilidades: {
    actuales: 0,
    acumuladas: 0,
    porcentaje: 0,
    margenNeto: 0,
    liquidez: 0,
    variacionMargen: 0,
    variacionLiquidez: 0
  }
});

// Formateador de moneda
const formatCurrency = (value) => {
  return new Intl.NumberFormat('en-US', {
    style: 'currency',
    currency: 'USD'
  }).format(value);
};

// Formateador de variación porcentual
const formatVariation = (value) => {
  return `${value >= 0 ? '+' : ''}${value.toFixed(2)}%`;
};


// Configurar fechas iniciales
const setDefaultDates = () => {
    const { startDate: defaultStart, endDate: defaultEnd } = getDefaultDates();
    startDate.value = defaultStart;
    endDate.value = defaultEnd;
     
};

// Función para validar y normalizar datos de la API
const normalizeApiData = (response, defaultValue = 0) => {
  if (!response || !response.data) return defaultValue;
  
  // Algunas respuestas tienen { data: { success: true, data: {...} } }
  if (response.data.success !== undefined && response.data.data) {
    return response.data.data;
  }
  
  // Otras tienen { data: {...} } directamente
  return response.data;
};

// Función para cargar datos de los gráficos
const loadChartData = async (startDateFormatted, endDateFormatted) => {
  try {
    
     // Extraer el año de startDate (formato YYYY-MM-DD)
    const year = startDate.value.substring(0, 4);
    
    // Cargar datos para el gráfico financiero
    const financialResponse = await api.get(
      `/Dashboard/profit-loss-byMonth/?tipoConexion=${tipoConexion.value}&year=${year}`,
    );
    financialData.value = normalizeApiData(financialResponse, []);

    // Cargar datos para el gráfico de ventas por categoría
    const salesResponse = await api.get(
      `/Dashboard/sales-by-category?tipoConexion=${tipoConexion.value}&startDate=${encodeURIComponent(startDateFormatted)}&endDate=${encodeURIComponent(endDateFormatted)}`,
    );
    salesData.value = normalizeApiData(salesResponse, []);

    // Renderizar gráficos después de que los datos estén disponibles y el DOM se haya actualizado
   
  await nextTick();

     // Esperar hasta que el contenedor tenga dimensiones

     


    if (financialChartRef.value && financialData.value.length > 0) {  
      
     renderFinancialChart(financialChartRef.value, financialData.value);      
      
      
    }
    if ( salesChartRef.value && salesData.value.length > 0) {
       
      renderSalesCategoryChart(salesChartRef.value, salesData.value);    
     
  }} catch (err) {
    console.error('Error al cargar datos de gráficos:', err);
    push.error({
      title: "Error",
      message: "Ocurrió un error al cargar los gráficos."
    });
  }
};

// Función para cargar datos
const handleLoadData = async () => {
    loading.value = true;
    error.value = null;

    try {
        
        if (!startDate.value || !endDate.value) {
        push.error('Error al cargar datos: ', {
        title: 'Error',
        message: 'Por favor, selecciona una fecha de inicio y una fecha de fin.'
      });
      }
      
        // Formatear fechas para la API con manejo seguro
            const formatDateSafe = (dateStr, isEndDate = false, subtractYear = false) => {
            const formatted = formatDateWithTime(dateStr, isEndDate, subtractYear);
            if (!formatted) throw new Error(`Formato de fecha inválido: ${dateStr}`);
            return formatted;
            };

            const startDateFormatted = formatDateSafe(startDate.value);
            const endDateFormatted = formatDateSafe(endDate.value, true);
            const previousStartDate = formatDateSafe(startDate.value, false, true);
            const previousEndDate = formatDateSafe(endDate.value, true, true);
       
             await Promise.all([
            loadMainData(startDateFormatted, endDateFormatted, previousStartDate, previousEndDate),
            
            ]);     

            loading.value = false;
            await nextTick();
            await loadChartData(startDateFormatted, endDateFormatted);
            
        }            

     catch (err) {
    push.error("Error al cargar servicios: ", {
      title: "Error",
      message: error.message || "Ocurrió un error al cargar servicios.",
    });
    } finally {
        loading.value = false;
    }
};

// Función para cargar los datos principales del dashboard
const loadMainData = async (startDateFormatted, endDateFormatted, previousStartDate, previousEndDate) => {
  // Grupo Ventas
  const [ventasResponse, acumuladoResponse] = await Promise.all([
    api.get(`/Dashboard/sales/by-date?tipoConexion=${tipoConexion.value}&startDate=${encodeURIComponent(startDateFormatted)}&endDate=${encodeURIComponent(endDateFormatted)}`),
    api.get(`/Dashboard/sales/accumulated?tipoConexion=${tipoConexion.value}&endDate=${encodeURIComponent(endDateFormatted)}`)
  ]);

  // Grupos ventas anteriores
  const [ventasPreviousResponse, acumuladoPreviousResponse] = await Promise.all([
    api.get(`/Dashboard/sales/by-date?tipoConexion=${tipoConexion.value}&startDate=${encodeURIComponent(previousStartDate)}&endDate=${encodeURIComponent(previousEndDate)}`),
    api.get(`/Dashboard/sales/accumulated?tipoConexion=${tipoConexion.value}&endDate=${encodeURIComponent(previousEndDate)}`)
  ]);

  // Grupo Porcentaje Ventas
  const [porcentajeVentasActualResponse, porcentajeVentasPreviousResponse] = await Promise.all([
    api.get(`/Dashboard/variation/income?tipoConexion=${tipoConexion.value}&startDate=${encodeURIComponent(startDateFormatted)}&endDate=${encodeURIComponent(endDateFormatted)}`),
    api.get(`/Dashboard/variation/income?tipoConexion=${tipoConexion.value}&startDate=${encodeURIComponent(previousStartDate)}&endDate=${encodeURIComponent(previousEndDate)}`)
  ]);

  // Grupo Utilidades
  const [utilidadesResponse, utilidadesAcumuladasResponse, porcentajeUtilidadesResponse] = await Promise.all([
    api.get(`/Dashboard/annual-earnings?tipoConexion=${tipoConexion.value}&startDate=${encodeURIComponent(startDateFormatted)}&endDate=${encodeURIComponent(endDateFormatted)}`),
    api.get(`/Dashboard/accumulated-earnings?tipoConexion=${tipoConexion.value}&endDate=${encodeURIComponent(endDateFormatted)}`),
    api.get(`/Dashboard/variation/profit?tipoConexion=${tipoConexion.value}&startDate=${encodeURIComponent(startDateFormatted)}&endDate=${encodeURIComponent(endDateFormatted)}`)
  ]);

  // Grupo Financial
  const [marginEarningsResponse, liquidezResponse] = await Promise.all([
    api.get(`/Dashboard/margin-earnings?tipoConexion=${tipoConexion.value}&startDate=${encodeURIComponent(startDateFormatted)}&endDate=${encodeURIComponent(endDateFormatted)}`),
    api.get(`/Dashboard/liquidity-ratio?tipoConexion=${tipoConexion.value}&startDate=${encodeURIComponent(startDateFormatted)}&endDate=${encodeURIComponent(endDateFormatted)}`)
  ]);

  // Normalizar datos
  const ventasData = normalizeApiData(ventasResponse, { totalSales: 0 });
  const acumuladoData = normalizeApiData(acumuladoResponse, { totalSales: 0 });
  const ventasPreviousData = normalizeApiData(ventasPreviousResponse, { totalSales: 0 });
  const acumuladoPreviousData = normalizeApiData(acumuladoPreviousResponse, { totalSales: 0 });
  const porcentajeVentasActual = normalizeApiData(porcentajeVentasActualResponse, { variationPercentage: 0 });
  const porcentajeVentasPrevious = normalizeApiData(porcentajeVentasPreviousResponse, { variationPercentage: 0 });
  const utilidadesData = normalizeApiData(utilidadesResponse, { totalEarnings: 0 });
  const utilidadesAcumuladasData = normalizeApiData(utilidadesAcumuladasResponse, { totalEarnings: 0 });
  const porcentajeUtilidades = normalizeApiData(porcentajeUtilidadesResponse, { variationPercentage: 0 });
  const marginEarningsData = normalizeApiData(marginEarningsResponse, { totalEarnings: 0 });
  const liquidezData = normalizeApiData(liquidezResponse, { liquidityLevel: 0 });

  // Calcular métricas
  const margenNetoPorcentaje = parseFloat((marginEarningsData.totalEarnings * 100).toFixed(2));
  const metaMargenNetoUtilidades = 50.00;
  const variacionMargenNetoUtilidades = parseFloat((margenNetoPorcentaje - metaMargenNetoUtilidades).toFixed(2));
  const metaLiquidez = 1.5;
  const variacionliquidez = parseFloat((liquidezData.liquidityLevel - metaLiquidez).toFixed(2));

  // Actualizar la UI con los datos
  dashboardData.value = {
    ventas: {
      actual: ventasData.totalSales,
      acumulado: acumuladoData.totalSales,
      anterior: ventasPreviousData.totalSales,
      anteriorAcumulado: acumuladoPreviousData.totalSales,
      porcentajeActual: porcentajeVentasActual.variationPercentage,
      porcentajeAnterior: porcentajeVentasPrevious.variationPercentage
    },
    utilidades: {
      actuales: utilidadesData.totalEarnings,
      acumuladas: utilidadesAcumuladasData.totalEarnings,
      porcentaje: porcentajeUtilidades.variationPercentage,
      margenNeto: margenNetoPorcentaje,
      liquidez: liquidezData.liquidityLevel,
      variacionMargen: variacionMargenNetoUtilidades,
      variacionLiquidez: variacionliquidez
    }
  };
};


// Manejar redimensionamiento de la ventana
const handleResize = () => {
  resizeAllCharts();
};

// Limpiar al desmontar el componente
onBeforeUnmount(() => {
  window.removeEventListener('resize', handleResize);
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
