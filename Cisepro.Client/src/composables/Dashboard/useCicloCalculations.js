import { obtenerMesesActivos,
          obtenerValorPartida,
          calcularValoresMensuales,
          calcularAcumulados,
          
 } from "./shared/calculoBase";


 export const useCicloCalculations = (tabla) => {
   
    const tablaPrimaria = Array.isArray(tabla)
     ? tabla
     : (tabla && Array.isArray(tabla.tablaPrimaria) ? tabla.tablaPrimaria : []); ; 
 
   if (!tablaPrimaria || tablaPrimaria.length === 0) {
       return {
         mesesActivos: [],
         mensual: {},
         acumulados: {},
         diasTranscurridos: {},
         ciclosMensual: {},
         cicloFinal: {},        
       };
     }
 
     const mesesActivos = obtenerMesesActivos(tablaPrimaria);
     const mensual = calcularValoresMensuales(tablaPrimaria, mesesActivos);
     const acumulados = calcularAcumulados(tablaPrimaria, mesesActivos);
     const ciclosMensual = calcularCicloEfectivo(tablaPrimaria,mesesActivos,acumulados);
 
 
     return {
       mesesActivos,
       mensual,
       acumulados,
       ciclos,      
     };
   };
 
    
//calcular dias transcurridos, dias CXC, dias CXP, ciclo efectivo, costo+gasto por dia

const diasTranscurridos = (acumulados,meses) => {


};

 
   const calcularCicloEfectivo = (tablaPrimaria,mesesActivos,acumulados) => {
    
     if (meses.length === 0) {
      return null;
    }
    
    const ultimoMes = meses[meses.length - 1];
    const numeroMeses = meses.length;
    

    mesesActivos.forEach((mes, index) => {
      const diasTranscurridos = calcularDiasTranscurridos(index);

      const clientesAcum = acumulados.Clientes[mes];
      const proveedoresAcum = acumulados.Proveedores[mes];
      const ventasAcum = acumulados.Ventas[mes];
      const costoAcum = acumulados.Costo[mes];
      const gastosAcum = acumulados.Gastos[mes];

      //Calculos Ciclo Efectivo
      // Cálculo de días CXC - DINÁMICO según días transcurridos
      const diasCxc =
        ventasAcum !== 0
          ? (clientesAcum / (ventasAcum * 0.9)) * diasTranscurridos
          : 0;

      // Cálculo de días CXP - DINÁMICO según días transcurridos
      const diasCxp =
        costoAcum !== 0 ? (proveedoresAcum / costoAcum) * diasTranscurridos : 0;

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
          gastos: gastosAcum,
        },
      });
    });

    return resultados;
  };

  /**
   * Calcula los días transcurridos según el índice del mes (30, 60, 90, 120...)
   */
  const calcularDiasTranscurridos = (indiceMes) => {
    return (indiceMes + 1) * 30;
  };
