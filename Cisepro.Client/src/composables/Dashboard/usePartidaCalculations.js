
import { obtenerMesesActivos,
          obtenerValorPartida,
          calcularValoresMensuales,
          calcularAcumulados,
          
 } from "./shared/calculoBase";
  /**
   * Función principal que procesa toda la data desde la API
   */
  export const usePartidaCalculations = (tabla) => {
  
   const tablaPrimaria = Array.isArray(tabla)
    ? tabla
    : (tabla && Array.isArray(tabla.tablaPrimaria) ? tabla.tablaPrimaria : []); ; 

  if (!tablaPrimaria || tablaPrimaria.length === 0) {
      return {
        mesesActivos: [],
        mensual: {},
        acumulados: {},
        partidas: {},        
      };
    }

    const mesesActivos = obtenerMesesActivos(tablaPrimaria);
    const mensual = calcularValoresMensuales(tablaPrimaria, mesesActivos);
    const acumulados = calcularAcumulados(tablaPrimaria, mesesActivos);
    const partidas = calcularPartidas(tablaPrimaria,mesesActivos,acumulados);


    return {
      mesesActivos,
      mensual,
      acumulados,
      partidas,      
    };
  };

  
  //Calcular Partidas
  const calcularPartidas = (tablaPrimaria,meses,acumulados) => {
    if (meses.length === 0) {
      return null;
    }
    
    const ultimoMes = meses[meses.length - 1];
    const numeroMeses = meses.length;

    const ventasUltimoMes = obtenerValorPartida(tablaPrimaria,"Ventas", ultimoMes)*-1;
    const costoUltimoMes = obtenerValorPartida(tablaPrimaria, "Costo", ultimoMes);
    const gastosUltimoMes = obtenerValorPartida(tablaPrimaria,"Gastos", ultimoMes);

    // Utilidad Operativa del último mes
    const utilidadOperativa =
      ventasUltimoMes - costoUltimoMes - gastosUltimoMes;
    const porcentajeUtilidadOperativa =
      ventasUltimoMes !== 0 ? (utilidadOperativa / ventasUltimoMes) * 100 : 0;

    // Margen Bruto del último mes
    const margenBruto = ventasUltimoMes - costoUltimoMes;
    const porcentajeMargenBruto =
      ventasUltimoMes !== 0 ? (margenBruto / ventasUltimoMes) * 100 : 0;

    // ===== CÁLCULOS DE PROMEDIOS (ACUMULADOS) =====
    const ventasAcumuladas = acumulados.Ventas[ultimoMes];
    const costosAcumulados = acumulados.Costo[ultimoMes];
    const gastosAcumulados = acumulados.Gastos[ultimoMes];
    const utilidadOperativaAcumulada = acumulados.UtilidadOperativa[ultimoMes];
    const margenBrutoAcumulado = acumulados.MargenBruto[ultimoMes];

    // Promedios
    const ventaPromedio = ventasAcumuladas / numeroMeses;
    const costoPromedio = costosAcumulados / numeroMeses;
    const gastoPromedio = gastosAcumulados / numeroMeses;
    const utilidadBrutaPromedio = margenBrutoAcumulado / numeroMeses;
    const utilidadOperativaPromedio = utilidadOperativaAcumulada / numeroMeses;

    // Porcentaje de Utilidad Operativa Promedio
    const porcentajeUtilidadOperativaPromedio =
      ventasAcumuladas !== 0
        ? (utilidadOperativaAcumulada / ventasAcumuladas) * 100
        : 0;

    return {
      ultimoMes: {
        mes: ultimoMes,
        ventas: ventasUltimoMes,
        costo: costoUltimoMes,
        gastos: gastosUltimoMes,
        utilidadOperativa: utilidadOperativa,
        porcentajeUtilidadOperativa: porcentajeUtilidadOperativa,
        margenBruto: margenBruto,
        porcentajeMargenBruto: porcentajeMargenBruto,
      },
      promedios: {
        numeroMeses: numeroMeses,
        ventaPromedio: ventaPromedio,
        costoPromedio: costoPromedio,
        gastoPromedio: gastoPromedio,
        utilidadBrutaPromedio: utilidadBrutaPromedio,
        utilidadOperativaPromedio: utilidadOperativaPromedio,
        porcentajeUtilidadOperativaPromedio:
          porcentajeUtilidadOperativaPromedio,
      },
      acumulados: {
        ventas: ventasAcumuladas,
        costos: costosAcumulados,
        gastos: gastosAcumulados,
        utilidadOperativa: utilidadOperativaAcumulada,
        margenBruto: margenBrutoAcumulado,
      },
    };
  };

  
  
