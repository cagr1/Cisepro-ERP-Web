

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

    
  
  /**
   * Obtiene los meses que tienen datos (valores diferentes de 0)
   */

  const obtenerMesesActivos = (tabla) => {
  const meses = [
    "enero",
    "febrero",
    "marzo",
    "abril",
    "mayo",
    "junio",
    "julio",
    "agosto",
    "septiembre",
    "octubre",
    "noviembre",
    "diciembre",
  ];

  return meses.filter((mes) =>
    tabla.some((row) => row[mes] && row[mes] !== 0)
  );
};

  /**
   * Obtiene el valor de una partida específica en un mes
   */
   const obtenerValorPartida = (tablaPrimaria, nombrePartida, mes) => {
    const partida = tablaPrimaria.find((p) => p.partidas === nombrePartida);
    return partida ? partida[mes] || 0 : 0;
  };


  //Valores mes a mes

  const calcularValoresMensuales = (tablaPrimaria, meses) => {
    const mensual = {
      Clientes: {},
      Proveedores: {},
      Ventas: {},
      Costo: {},
      Gastos: {},
      UtilidadOperativa: {},
      MargenBruto: {},
    };

    meses.forEach((mes) => {
      const ventasMes = obtenerValorPartida(tablaPrimaria, "Ventas", mes);
      const costoMes = obtenerValorPartida(tablaPrimaria, "Costo", mes);
      const gastosMes = obtenerValorPartida(tablaPrimaria, "Gastos", mes);

      mensual.Clientes[mes] = obtenerValorPartida(tablaPrimaria,"Clientes", mes);
      mensual.Proveedores[mes] = obtenerValorPartida(tablaPrimaria,"Proveedores", mes);
      mensual.Ventas[mes] = ventasMes;
      mensual.Costo[mes] = costoMes;
      mensual.Gastos[mes] = gastosMes;
      mensual.UtilidadOperativa[mes] = ventasMes - costoMes - gastosMes;
      mensual.MargenBruto[mes] = ventasMes - costoMes;
    });

    return mensual;



  };



  /**
   * Calcula los valores acumulados para cada partida y mes
   */
  const calcularAcumulados = (tablaPrimaria,meses) => {
    const acumulados = {
      Clientes: {},
      Proveedores: {},
      Ventas: {},
      Costo: {},
      Gastos: {},
      UtilidadOperativa: {},
      MargenBruto: {},
    };

    let acumuladoClientes = 0;
    let acumuladoProveedores = 0;
    let acumuladoVentas = 0;
    let acumuladoCosto = 0;
    let acumuladoGastos = 0;
    let acumuladoUtilidadOperativa = 0;
    let acumuladoMargenBruto = 0;

    meses.forEach((mes) => {
      acumuladoClientes += obtenerValorPartida(tablaPrimaria,"Clientes", mes);
      acumuladoProveedores += obtenerValorPartida(tablaPrimaria,"Proveedores", mes);
      acumuladoVentas += obtenerValorPartida(tablaPrimaria,"Ventas", mes);
      acumuladoCosto += obtenerValorPartida(tablaPrimaria,"Costo", mes);
      acumuladoGastos += obtenerValorPartida(tablaPrimaria,"Gastos", mes);

      //calcular valores derivados del mes actual
      const ventasMes = obtenerValorPartida(tablaPrimaria,"Ventas", mes);
      const costoMes = obtenerValorPartida(tablaPrimaria,"Costo", mes);
      const gastosMes = obtenerValorPartida(tablaPrimaria,"Gastos", mes);
      const utilidadOperativaMes = ventasMes - costoMes - gastosMes;
      const margenBrutoMes = ventasMes - costoMes;

      acumuladoUtilidadOperativa += utilidadOperativaMes;
      acumuladoMargenBruto += margenBrutoMes;

      acumulados.Clientes[mes] = acumuladoClientes;
      acumulados.Proveedores[mes] = acumuladoProveedores;
      acumulados.Ventas[mes] = acumuladoVentas;
      acumulados.Costo[mes] = acumuladoCosto;
      acumulados.Gastos[mes] = acumuladoGastos;
      acumulados.UtilidadOperativa[mes] = acumuladoUtilidadOperativa;
      acumulados.MargenBruto[mes] = acumuladoMargenBruto;
    });

    return acumulados;
  };

  

  
  

  //Calcular Partidas
  const calcularPartidas = (tablaPrimaria,meses,acumulados) => {
    if (meses.length === 0) {
      return null;
    }
    
    const ultimoMes = meses[meses.length - 1];
    const numeroMeses = meses.length;

    const ventasUltimoMes = obtenerValorPartida(tablaPrimaria,"Ventas", ultimoMes);
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

  
  
