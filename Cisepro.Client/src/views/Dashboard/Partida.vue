<template>
  
    <div class="w-full ">
      <!-- Header con controles -->
      
        <div
          class="flex flex-col lg:flex-row md:items-center lg:justify-between gap-6"
        >
          <div class="md:flex-1">
            <h1 class="text-2xl font-bold text-gray-900">
              Análisis de Partidas Operativas
            </h1>
            
            <h2 class="text-sm font-bold text-gray-500">
              Indicadores de productividad y desempeño económico 
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
      <div
        v-if="error"
        class="bg-red-50 border-l-4 border-red-500 text-red-800 p-4 mb-6 rounded-lg shadow-sm"
        role="alert"
      >
        <div class="flex items-center">
          <svg class="w-5 h-5 mr-2" fill="currentColor" viewBox="0 0 20 20">
            <path
              fill-rule="evenodd"
              d="M10 18a8 8 0 100-16 8 8 0 000 16zM8.707 7.293a1 1 0 00-1.414 1.414L8.586 10l-1.293 1.293a1 1 0 101.414 1.414L10 11.414l1.293 1.293a1 1 0 001.414-1.414L11.414 10l1.293-1.293a1 1 0 00-1.414-1.414L10 8.586 8.707 7.293z"
              clip-rule="evenodd"
            />
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
        <div class="mb-8 mt-8">
          

          <div class="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-5 gap-5">
            <!-- Ventas -->
            <div class="stat-card border-l-4 border-blue-500">
              <div class="flex justify-between items-start mb-3">
                <div>
                  <p
                    class="text-xs font-bold text-gray-500 uppercase tracking-wider"
                  >
                    Ventas
                  </p>
                  <p class="text-xl font-bold text-blue-600 mt-1">
                    {{
                      formatCurrency(
                        datosFinancieros?.partidas?.ultimoMes?.ventas
                      )
                    }}
                  </p>
                </div>
                <div class="bg-blue-100 p-1 rounded-lg">
                  <!-- <Icon icon="solar:money-bag-bold-duotone" class="w-6 h-6 text-blue-600" /> -->
                  <Icon
                    icon="fluent:money-24-regular"
                    class="w-6 h-6 text-blue-600"
                  />
                </div>
              </div>
              <div class="text-xs text-gray-500">Ingresos del período</div>
            </div>

            <!-- Costo -->
            <div class="stat-card border-l-4 border-red-500">
              <div class="flex justify-between items-start mb-3">
                <div>
                  <p
                    class="text-xs font-bold text-gray-500 uppercase tracking-wider"
                  >
                    Costos
                  </p>
                  <p class="text-xl font-bold text-red-600 mt-1">
                    {{
                      formatCurrency(
                        datosFinancieros?.partidas?.ultimoMes?.costo
                      )
                    }}
                  </p>
                </div>
                <div class="bg-red-100 p-1 rounded-lg">
                  <Icon
                    icon="fluent:shopping-bag-dismiss-20-regular"
                    class="w-6 h-6 text-red-600"
                  />
                </div>
              </div>
              <div class="text-xs text-gray-500">Costo de ventas</div>
            </div>

            <!-- Gastos -->
            <div class="stat-card border-l-4 border-orange-500">
              <div class="flex justify-between items-start mb-3">
                <div>
                  <p
                    class="text-xs font-bold text-gray-500 uppercase tracking-wider"
                  >
                    Gastos
                  </p>
                  <p class="text-xl font-bold text-orange-600 mt-1">
                    {{
                      formatCurrency(
                        datosFinancieros?.partidas?.ultimoMes?.gastos
                      )
                    }}
                  </p>
                </div>
                <div class="bg-orange-100 p-1 rounded-lg">
                  <Icon
                    icon="fluent:wallet-credit-card-28-regular"
                    class="w-6 h-6 text-orange-600"
                  />
                </div>
              </div>
              <div class="text-xs text-gray-500">Gastos operativos</div>
            </div>

            <!-- Margen Bruto -->
            <div class="stat-card border-l-4 border-emerald-500">
              <div class="flex justify-between items-start mb-3">
                <div>
                  <p
                    class="text-xs font-bold text-gray-500 uppercase tracking-wider"
                  >
                    Margen Bruto
                  </p>
                  <p class="text-xl font-bold text-emerald-600 mt-1">
                    {{
                      formatCurrency(
                        datosFinancieros?.partidas?.ultimoMes?.margenBruto
                      )
                    }}
                  </p>
                </div>
                <div class="bg-emerald-100 p-1 rounded-lg">
                  <Icon
                    icon="fluent:chart-multiple-24-regular"
                    class="w-6 h-6 text-emerald-600"
                  />
                </div>
              </div>
              <div class="flex items-center gap-2">
                <span class="percentage-badge bg-emerald-100 text-emerald-700">
                  {{
                    formatPercentage(
                      datosFinancieros?.partidas?.ultimoMes
                        ?.porcentajeMargenBruto
                    )
                  }}
                </span>
                <span class="text-xs text-gray-500">de las ventas</span>
              </div>
            </div>

            <!-- Utilidad Operativa -->
            <div class="stat-card border-l-4 border-purple-500">
              <div class="flex justify-between items-start mb-3">
                <div>
                  <p
                    class="text-xs font-bold text-gray-500 uppercase tracking-wider"
                  >
                    Utilidad Operativa
                  </p>
                  <p class="text-xl font-bold text-purple-600 mt-1">
                    {{
                      formatCurrency(
                        datosFinancieros?.partidas?.ultimoMes?.utilidadOperativa
                      )
                    }}
                  </p>
                </div>
                <div class="bg-purple-100 p-1 rounded-lg">
                  <Icon
                    icon="fluent:data-trending-24-filled"
                    class="w-6 h-6 text-purple-600"
                  />
                </div>
              </div>
              <div class="flex items-center gap-2">
                <span class="percentage-badge bg-purple-100 text-purple-700">
                  {{
                    formatPercentage(
                      datosFinancieros?.partidas?.ultimoMes
                        ?.porcentajeUtilidadOperativa
                    )
                  }}
                </span>
                <span class="text-xs text-gray-500">de las ventas</span>
              </div>
            </div>
          </div>
        </div>

        <!-- Seccion Charts -->

        <div class="grid grid-cols-1 md:grid-cols-2 gap-2 mt-5 mb-8">
          <div class="bg-white p-4 rounded-xl shadow-sm">
            <h3 class="text-lg font-semibold mb-4 text-center">Ventas</h3>
            <div ref="chartVentasRef" class="w-full h-[350px]"></div>
          </div>

          <div class="bg-white p-4 rounded-xl shadow-sm">
            <h3 class="text-lg font-semibold mb-4 text-center">Utilidad</h3>
            <div ref="chartUtilidadRef" class="w-full h-[350px]"></div>
          </div>
        </div>

        <!-- Sección: Promedios del Período -->
        <div class="mb-8">
          <div class="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-5 gap-5">
            <!-- Venta Promedio -->
            <div class="stat-card border-l-4 border-blue-500">
              <div class="flex justify-between items-start mb-3">
                <div>
                  <p
                    class="text-xs font-bold text-gray-500 uppercase tracking-wider"
                  >
                    Venta Promedio
                  </p>
                  <p class="text-xl font-bold text-blue-600 mt-1">
                    {{
                      formatCurrency(
                        datosFinancieros?.partidas?.promedios?.ventaPromedio
                      )
                    }}
                  </p>
                </div>
                <div class="bg-cyan-100 p-1 rounded-lg">
                  <Icon
                    icon="fluent:briefcase-24-regular"
                    class="w-6 h-6 text-blue-600"
                  />
                </div>
              </div>
              <div class="text-xs text-gray-500">Promedio mensual</div>
            </div>

            <!-- Costo Promedio -->
            <div class="stat-card border-l-4 border-rose-500">
              <div class="flex justify-between items-start mb-3">
                <div>
                  <p
                    class="text-xs font-bold text-gray-500 uppercase tracking-wider"
                  >
                    Costo Promedio
                  </p>
                  <p class="text-xl font-bold text-rose-600 mt-1">
                    {{
                      formatCurrency(
                        datosFinancieros?.partidas?.promedios?.costoPromedio
                      )
                    }}
                  </p>
                </div>
                <div class="bg-rose-100 p-1 rounded-lg">
                  <Icon
                    icon="fluent:money-calculator-24-filled"
                    class="w-6 h-6 text-rose-600"
                  />
                </div>
              </div>
              <div class="text-xs text-gray-500">Promedio mensual</div>
            </div>

            <!-- Gasto Promedio -->
            <div class="stat-card border-l-4 border-amber-500">
              <div class="flex justify-between items-start mb-3">
                <div>
                  <p
                    class="text-xs font-bold text-gray-500 uppercase tracking-wider"
                  >
                    Gasto Promedio
                  </p>
                  <p class="text-xl font-bold text-amber-600 mt-1">
                    {{
                      formatCurrency(
                        datosFinancieros?.partidas?.promedios?.gastoPromedio
                      )
                    }}
                  </p>
                </div>
                <div class="bg-amber-100 p-1 rounded-lg">
                  <Icon
                    icon="fluent:arrow-trending-down-24-filled"
                    class="w-6 h-6 text-amber-600"
                  />
                </div>
              </div>
              <div class="text-xs text-gray-500">Promedio mensual</div>
            </div>

            <!-- Utilidad Bruta Promedio -->
            <div class="stat-card border-l-4 border-teal-500">
              <div class="flex justify-between items-start mb-3">
                <div>
                  <p
                    class="text-xs font-bold text-gray-500 uppercase tracking-wider"
                  >
                    Utilidad Bruta Prom.
                  </p>
                  <p class="text-xl font-bold text-teal-600 mt-1">
                    {{
                      formatCurrency(
                        datosFinancieros?.partidas?.promedios
                          ?.utilidadBrutaPromedio
                      )
                    }}
                  </p>
                </div>
                <div class="bg-teal-100 p-1 rounded-lg">
                  <Icon
                    icon="fluent:arrow-trending-lines-24-regular"
                    class="w-6 h-6 text-teal-600"
                  />
                </div>
              </div>
              <div class="text-xs text-gray-500">Margen bruto mensual</div>
            </div>

            <!-- Utilidad Operativa Promedio -->
            <div class="stat-card border-l-4 border-violet-500">
              <div class="flex justify-between items-start mb-3">
                <div>
                  <p
                    class="text-xs font-bold text-gray-500 uppercase tracking-wider"
                  >
                    Util. Operativa Prom.
                  </p>
                  <p class="text-xl font-bold text-violet-600 mt-1">
                    {{
                      formatCurrency(
                        datosFinancieros?.partidas?.promedios
                          ?.utilidadOperativaPromedio
                      )
                    }}
                  </p>
                </div>
                <div class="bg-violet-100 p-1 rounded-lg">
                  <Icon
                    icon="fluent:data-bar-vertical-24-filled"
                    class="w-6 h-6 text-violet-600"
                  />
                </div>
              </div>
              <div class="flex items-center gap-2">
                <span class="percentage-badge bg-violet-100 text-violet-700">
                  {{
                    formatPercentage(
                      datosFinancieros?.partidas?.promedios
                        ?.porcentajeUtilidadOperativaPromedio
                    )
                  }}
                </span>
                <span class="text-xs text-gray-500">de las ventas</span>
              </div>
            </div>
          </div>
        </div>

        <!-- Tarjeta Resumen Destacada -->
        <div
          class="backdrop-blur-xl bg-white/5 border border-white/10 
         rounded-2xl p-8 shadow-xl"
        >
          <div class="grid grid-cols-1 md:grid-cols-3 gap-8">
            <!-- Total Acumulado -->
            <div class="text-center border-r border-slate-700 last:border-r-0">
              <p
                class="text-slate-400 text-sm font-semibold uppercase tracking-wider mb-2"
              >
                Ventas Acumuladas
              </p>
              <p class="text-blue-400 text-2xl font-bold">
                {{
                  formatCurrency(datosFinancieros?.partidas?.acumulados?.ventas)
                }}
              </p>
            </div>

            <div class="text-center border-r border-slate-700 last:border-r-0">
              <p
                class="text-slate-400 text-sm font-semibold uppercase tracking-wider mb-2"
              >
                Utilidad Bruta Acum.
              </p>
              <p class="text-emerald-400 text-2xl font-bold">
                {{
                  formatCurrency(
                    datosFinancieros?.partidas?.acumulados?.margenBruto
                  )
                }}
              </p>
            </div>

            <div class="text-center">
              <p
                class="text-slate-400 text-sm font-semibold uppercase tracking-wider mb-2"
              >
                Utilidad Operativa Acum.
              </p>
              <p class="text-purple-400 text-2xl font-bold">
                {{
                  formatCurrency(
                    datosFinancieros?.partidas?.acumulados?.utilidadOperativa
                  )
                }}
              </p>
            </div>
          </div>
        </div>
      </div>
    </div>
  
</template>

<script setup>
import { ref, onMounted, nextTick } from "vue";
import { useFinancialData } from "@/api/Dashboard/useFinancialData";
import { useDashboardStore } from "@/stores/Composable/Dashboard.store";
import { usePartidaCalculations } from "@/composables/Dashboard/usePartidaCalculations";
import { useCicloCalculations } from "@/composables/Dashboard/useCicloCalculations";
import { buildPartidaCharts } from "@/composables/Dashboard/Charts/partidaCharts";
import { formatearMoneda } from "@/utils/formatters";
import { Icon } from "@iconify/vue";
import { push } from "notivue";





const store = useDashboardStore();

const { fetchTablaFinanciera , isLoading, error} = useFinancialData();

const datosFinancieros = ref(null);
const partidas = ref(null);
const startDate = ref("");
const endDate = ref("");
const chartVentasRef = ref(null);
const chartUtilidadRef = ref(null);

// Inicializar fechas
const initializeDates = () => {
  
  
    const now = new Date();
    const firstDayOfYear = new Date(now.getFullYear(), 0, 1);
    startDate.value = firstDayOfYear.toISOString().split("T")[0];
    endDate.value = now.toISOString().split("T")[0];
  
  
};

// Formatear moneda
const formatCurrency = (value) => {
  if (value === null || value === undefined || value === "-") return "-";
  return formatearMoneda(value);
};

// Formatear porcentaje
const formatPercentage = (value) => {
  if (value === null || value === undefined) return "-";
  return `${value.toFixed(2)}%`;
};

// Cargar datos
const handleLoadData = async () => {
  try {
    
    isLoading.value = true;
    
    const { tablaPrimaria }  = await fetchTablaFinanciera(
      startDate.value,
      endDate.value
    );  
     
    datosFinancieros.value = usePartidaCalculations(tablaPrimaria);
    
    partidas.value = useCicloCalculations(tablaPrimaria);
    
    console.log("Partidas calculadas:", partidas.value);
    
    store.setAll({
      partidas: datosFinancieros.value,
      cicloEfectivo: partidas.value,
      analisis: null,
    });
    
    const { mesesActivos, mensual } = datosFinancieros.value;
    
    await nextTick();

    buildPartidaCharts({
      mesesActivos,
      mensual ,
      chartVentasRef,
      chartUtilidadRef,
    });

    
  } catch (err) 
  
  {
    console.error(err);
    push.error({
      type: "error",
      title: "Error al cargar datos financieros",
      message: err.message || "Ocurrió un error al cargar partidas operativas.",
      duration: 5000,
    });
    
  } finally {
    isLoading.value = false;
  }
};

onMounted(async () => {
  initializeDates();
  
  if (store.isCacheValid && store.partidasData) {
    datosFinancieros.value = store.partidasData;
    partidas.value = store.cicloEfectivoData;

    await nextTick();

    const { mesesActivos, mensual } = datosFinancieros.value;

    buildPartidaCharts({
      mesesActivos,
      mensual,
      chartVentasRef,
      chartUtilidadRef,
    });

    return; // 👈 evita ejecutar handleLoadData()
  }

  // cache expirada → recalcular
  await handleLoadData();
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
