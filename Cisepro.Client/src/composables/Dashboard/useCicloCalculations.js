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
     const ciclosMensual = calcularCicloMensual(tablaPrimaria,mesesActivos,acumulados);
     const cicloFinal = calcularCicloFinal(tablaPrimaria,mesesActivos,acumulados);
 
 
     return {
       mesesActivos,
       mensual,
       acumulados,
       ciclosMensual,
       cicloFinal,      
     };
   };
 

   const calcularDiasTranscurridos = (indiceMes) => {
    return (indiceMes + 1) * 30;
    }

    //redondear a 2 decimales
    const round2 = (num) => Number(num.toFixed(2));
    
    //redondear entero
    const round0 = (num) => Math.round(Number(num) || 0);

//calcular dias transcurridos, dias CXC, dias CXP, ciclo efectivo, costo+gasto por mes

const calcularCicloMensual = (tablaPrimaria,meses,acumulados) => {
    const resultados = [];

    meses.forEach((mes, index) => {
      const diasTranscurridos = calcularDiasTranscurridos(Number(index));

      const clientesAcum = acumulados.Clientes[mes];
      const proveedoresAcum = Math.abs(acumulados.Proveedores[mes]);
      const ventasAcum = acumulados.Ventas[mes];
      const costoAcum = acumulados.Costo[mes];
      const gastosAcum = acumulados.Gastos[mes];

      const ventasCredito = Math.abs(ventasAcum) * 0.9;

      // Cálculo de días CXC
      const diasCxc =
        ventasCredito !== 0
          ? round0((clientesAcum / ventasCredito) * diasTranscurridos)
          : 0;

      // Cálculo de días CXP
      const diasCxp =
        costoAcum !== 0 ? round0((proveedoresAcum / costoAcum )* diasTranscurridos) : 0;

      // Ciclo efectivo
      const cicloEfectivo = diasCxc - diasCxp;

      //costo + gasto por día
      const costoGastoPorDia = round2((costoAcum + gastosAcum) / diasTranscurridos);

      //capitlal de trabajo en circulación
      const capitalTrabajo = round2(cicloEfectivo * costoGastoPorDia);

      //caja minima requerida
      const cajaMinimaRequerida = round2(capitalTrabajo * 0.50);

      //saldo banco 
      const saldoBanco = obtenerValorPartida(tablaPrimaria, "Bancos", mes);

      //capacidad de pago
      const capacidadPago = round2(saldoBanco / capitalTrabajo);

      resultados[mes]={
        dias: diasTranscurridos,
        diasCxc,
        diasCxp,
        cicloEfectivo,
        costoGastoPorDia,
        capitalTrabajo,
        cajaMinimaRequerida,
        saldoBanco,
        capacidadPago

      };

    });
    return resultados;
}
 // Calculo ciclo final ultimo mes
   const calcularCicloFinal = (tablaPrimaria,meses,acumulados) => {
    
     if (meses.length === 0) {
      return null;
    }
    
    const ultimoMes = meses[meses.length - 1];
    const numeroMeses = meses.length;
    
    const dias = calcularDiasTranscurridos(numeroMeses);

    const clientesAcum = acumulados.Clientes[ultimoMes];
    const proveedoresAcum = Math.abs(acumulados.Proveedores[ultimoMes]);
    const ventasAcum = acumulados.Ventas[ultimoMes];
    const costoAcum = acumulados.Costo[ultimoMes];
    const gastosAcum = acumulados.Gastos[ultimoMes];
    const bancoPromedio = round2(acumulados.Bancos[ultimoMes] / numeroMeses);
    const ventasCredito = Math.abs(ventasAcum) * 0.9;

    // Cálculo de días CXC
    const diasCXC =
      ventasCredito !== 0
        ? round0((clientesAcum / ventasCredito) * dias)
        : 0;

    // Cálculo de días CXP redondeado a 0 decimales
    

    const diasCXP =
      costoAcum !== 0 ? round0((proveedoresAcum / costoAcum) * dias) : 0;
    
      // Ciclo efectivo
    const cicloEfectivo = diasCXC - diasCXP;

    //costo + gasto por día
    const costoGastoPorDia = round2((costoAcum + gastosAcum) / dias);

    //capitlal de trabajo en circulación
    const capitalTrabajo = round2(cicloEfectivo * costoGastoPorDia);
    
    //caja minima requerida
    const cajaMinimaRequerida = capitalTrabajo * 0.50;

    //saldo banco 
    const saldoBanco = obtenerValorPartida(tablaPrimaria, "Bancos", ultimoMes);
    //capacidad de pago
    const capacidadPago = round2(saldoBanco / capitalTrabajo);
    return {
      ultimoMes,
      diasCXC,
      diasCXP,
      cicloEfectivo,
      costoGastoPorDia,
      capitalTrabajo,
      cajaMinimaRequerida,
      saldoBanco,
      capacidadPago,
      bancoPromedio
    };
  };

  
  
