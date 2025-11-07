import { ref, computed } from 'vue';
import api from "@/api";
import { formatDateWithTime} from "@/utils/dateUtils";
import { useAuthStore } from "@/stores/auth.store";

const authStore = useAuthStore();
const tipoConexion = authStore.selectedCompany;

export const useFinancialCalculations = () => {
  const tablaPrimaria = ref([]);
  const mesesActivos = ref([]);
  const isLoading = ref(false);
  const error = ref(null);
  
  const fetchTablaFinanciera = async (startDateInput, endDateInput) => {
    try {
      const startDate = formatDateWithTime(startDateInput);
      const endDate = formatDateWithTime(endDateInput, true);
      
      const params = {
        tipoConexion,
        startDate,
        endDate
      };
      
      const response = await api.get('/Dashboard/financial-table', { 
        params,
        paramsSerializer: { indexes: null }
      });
      
      return response.data;
    } catch (err) {
      console.error('Error al obtener tabla financiera:', err);
      throw err;
    }
  };

  /**
   * Función principal que procesa toda la data desde la API
   */
  const procesarData = async (startDate, endDate) => {
    isLoading.value = true;
    error.value = null;
    
    try {
      // Obtener datos de la API
      const data = await fetchTablaFinanciera(startDate, endDate);
      
      // Asignar tabla primaria
      tablaPrimaria.value = data.tablaPrimaria;
      
      // Obtener meses activos
      mesesActivos.value = obtenerMesesActivos(tablaPrimaria.value);
      
      // Calcular todos los valores
      const ciclo = calcularCicloEfectivo();
      const promedio = calcularPromedioCapitalTrabajo(ciclo);
      
      return {
        mesesActivos: mesesActivos.value,
        acumulados: calcularAcumulados(),
        cicloEfectivo: ciclo,
        promedioCapitalTrabajo: promedio,
        tablaPrimaria: tablaPrimaria.value
      };
    } catch (err) {
      error.value = err.message || 'Error al procesar datos financieros';
      throw err;
    } finally {
      isLoading.value = false;
    }
  };


  
  
  
  
  /**
   * Obtiene los meses que tienen datos (valores diferentes de 0)
   */
  
  const obtenerMesesActivos = (data) => {
    if (!data || data.length === 0) return [];
    
    const meses = ['enero', 'febrero', 'marzo', 'abril', 'mayo', 'junio', 
                   'julio', 'agosto', 'septiembre', 'octubre', 'noviembre', 'diciembre'];
    
    const mesesConDatos = meses.filter(mes => {
      return data.some(partida => partida[mes] && partida[mes] !== 0);
    });
    
    return mesesConDatos;
  };

  /**
   * Obtiene el valor de una partida específica en un mes
   */
  const obtenerValorPartida = (nombrePartida, mes) => {
    const partida = tablaPrimaria.value.find(p => p.partidas === nombrePartida);
    return partida ? (partida[mes] || 0) : 0;
  };

  /**
   * Calcula los valores acumulados para cada partida y mes
   */
  const calcularAcumulados = () => {
    const acumulados = {
      Clientes: {},
      Proveedores: {},
      Ventas: {},
      Costo: {},
      Gastos: {}
    };

    let acumuladoClientes = 0;
    let acumuladoProveedores = 0;
    let acumuladoVentas = 0;
    let acumuladoCosto = 0;
    let acumuladoGastos = 0;

    mesesActivos.value.forEach(mes => {
      acumuladoClientes += obtenerValorPartida('Clientes', mes);
      acumuladoProveedores += obtenerValorPartida('Proveedores', mes);
      acumuladoVentas += obtenerValorPartida('Ventas', mes);
      acumuladoCosto += obtenerValorPartida('Costo', mes);
      acumuladoGastos += obtenerValorPartida('Gastos', mes);

      acumulados.Clientes[mes] = acumuladoClientes;
      acumulados.Proveedores[mes] = acumuladoProveedores;
      acumulados.Ventas[mes] = acumuladoVentas;
      acumulados.Costo[mes] = acumuladoCosto;
      acumulados.Gastos[mes] = acumuladoGastos;
    });

    return acumulados;
  };

  /**
   * Calcula los días transcurridos según el índice del mes (30, 60, 90, 120...)
   */
  const calcularDiasTranscurridos = (indiceMes) => {
    return (indiceMes + 1) * 30;
  };

  /**
   * Calcula la tabla de ciclo efectivo
   */
  const calcularCicloEfectivo = () => {
    const acumulados = calcularAcumulados();
    const resultados = [];

    mesesActivos.value.forEach((mes, index) => {
      const diasTranscurridos = calcularDiasTranscurridos(index);
      
      const clientesAcum = acumulados.Clientes[mes];
      const proveedoresAcum = acumulados.Proveedores[mes];
      const ventasAcum = acumulados.Ventas[mes];
      const costoAcum = acumulados.Costo[mes];
      const gastosAcum = acumulados.Gastos[mes];

      // Cálculo de días CXC - DINÁMICO según días transcurridos
      const diasCxc = ventasAcum !== 0 
        ? (clientesAcum / (ventasAcum * 0.9)) * diasTranscurridos
        : 0;

      // Cálculo de días CXP - DINÁMICO según días transcurridos
      const diasCxp = costoAcum !== 0 
        ? (proveedoresAcum / costoAcum) * diasTranscurridos
        : 0;

      // Ciclo efectivo
      const cicloEfectivo = diasCxc + diasCxp;

      // Costo (+) gasto por día
      const costoGastoPorDia = (costoAcum + gastosAcum) / diasTranscurridos;

      // Capital de trabajo en circulación
      const capitalTrabajo = cicloEfectivo * costoGastoPorDia;

      resultados.push({
        mes,
        diasTranscurridos,
        diasCxc: Math.round(diasCxc),
        diasCxp: Math.round(diasCxp),
        cicloEfectivo: Math.round(cicloEfectivo),
        costoGastoPorDia: costoGastoPorDia,
        capitalTrabajo: capitalTrabajo,
        // Valores acumulados para referencia
        acumulados: {
          clientes: clientesAcum,
          proveedores: proveedoresAcum,
          ventas: ventasAcum,
          costo: costoAcum,
          gastos: gastosAcum
        }
      });
    });

    return resultados;
  };

  /**
   * Calcula el promedio del capital de trabajo
   */
  const calcularPromedioCapitalTrabajo = (resultadosCiclo) => {
    if (resultadosCiclo.length === 0) return 0;
    
    const suma = resultadosCiclo.reduce((acc, item) => acc + item.capitalTrabajo, 0);
    return suma / resultadosCiclo.length;
  };

  

  /**
   * Formatea números para display
   */
  const formatearNumero = (numero, decimales = 2) => {
    return new Intl.NumberFormat('es-EC', {
      minimumFractionDigits: decimales,
      maximumFractionDigits: decimales
    }).format(numero);
  };

  /**
   * Formatea moneda
   */
  const formatearMoneda = (numero) => {
    return new Intl.NumberFormat('es-EC', {
      style: 'currency',
      currency: 'USD',
      minimumFractionDigits: 2,
      maximumFractionDigits: 2
    }).format(numero);
  };

  return {
    //estados
    tablaPrimaria,
    mesesActivos,
    isLoading,
    error,
    //funcion principal
    procesarData,
    // funciones secundarias
    calcularAcumulados,
    calcularCicloEfectivo,
    calcularPromedioCapitalTrabajo,
    //utilidades
    formatearNumero,
    formatearMoneda
  };
};