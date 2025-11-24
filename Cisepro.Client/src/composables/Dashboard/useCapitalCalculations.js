import { obtenerMesesActivos,
          obtenerValorPartida,
          calcularValoresMensuales,
          calcularAcumulados,
          
 } from "./shared/calculoBase";


 export const useCapitalCalculations = (tabla) => {
   
    const tablaPrimaria = Array.isArray(tabla)
     ? tabla
     : (tabla && Array.isArray(tabla.tablaPrimaria) ? tabla.tablaPrimaria : []); ; 
 
   if (!tablaPrimaria || tablaPrimaria.length === 0) {
       return {
         mesesActivos: [],
         mensual: {},
         acumulados: {},
         analisisFinal: {},        
       };
     }
 
     const mesesActivos = obtenerMesesActivos(tablaPrimaria);
     const mensual = calcularValoresMensuales(tablaPrimaria, mesesActivos);     
    const acumulados = calcularAcumulados(tablaPrimaria, mesesActivos);
     const analisisFinal = calcularCapitalFinal(tablaPrimaria,mesesActivos,acumulados);
 
 
     return {
       mesesActivos,
       mensual,
       acumulados,     
       analisisFinal,      
     };
   };
 



 //redondear a 2 decimales
    const round2 = (num) => Number(num.toFixed(2));
    
    //redondear entero
    const round0 = (num) => Math.round(Number(num) || 0);


 // Calculo analisis final ultimo mes
   const calcularCapitalFinal = (tablaPrimaria,meses,acumulados) => {
    
     if (meses.length === 0) {
      return null;
    }
    
    const ultimoMes = meses[meses.length - 1];
    const numeroMeses = meses.length;
      

    // ultimo mes 
    
    const clientesUltimoMes = obtenerValorPartida(tablaPrimaria, "Clientes", ultimoMes); 
    const proveedoresUltimoMes = obtenerValorPartida(tablaPrimaria, "Proveedores", ultimoMes) * -1;
    const ventasUltimoMes = obtenerValorPartida(tablaPrimaria,"Ventas", ultimoMes)*-1;
    const costoUltimoMes = obtenerValorPartida(tablaPrimaria, "Costo", ultimoMes);
    const gastosUltimoMes = obtenerValorPartida(tablaPrimaria,"Gastos", ultimoMes);
    const bancoUltimoMes = obtenerValorPartida(tablaPrimaria, "Bancos", ultimoMes) ;
   

    // Utilidad Operativa del último mes
    const utilidadOperativa =
      ventasUltimoMes - costoUltimoMes - gastosUltimoMes;
    
     // Acumulados
     
    const clientesAcum = acumulados.Clientes[ultimoMes];
    const proveedoresAcum = Math.abs(acumulados.Proveedores[ultimoMes]);
    const bancoAcum = acumulados.Bancos[ultimoMes];

    //promedios 

    const clientesPromedio = round2(clientesAcum / numeroMeses);
    const proveedoresPromedio = round2(proveedoresAcum / numeroMeses);
    const bancoPromedio = round2(bancoAcum / numeroMeses);

    
    //saldo banco 
    const saldoBanco = obtenerValorPartida(tablaPrimaria, "Bancos", ultimoMes);
    //capacidad de pago
    
    return {
      ultimoMes,
      clientesUltimoMes,
      proveedoresUltimoMes,
      ventasUltimoMes,
      costoUltimoMes,
      gastosUltimoMes,
      bancoUltimoMes,
      utilidadOperativa,
      clientesPromedio,
      proveedoresPromedio,
      bancoPromedio,
      saldoBanco
    };
  };




 
   
    
  
  
