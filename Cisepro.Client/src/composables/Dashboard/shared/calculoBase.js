


   //Obtiene los meses que tienen datos (valores diferentes de 0)


export  const obtenerMesesActivos = (tabla) => {
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

//Obtener valor de una partida en un mes específico
export const obtenerValorPartida = (tablaPrimaria, nombrePartida, mes) => {
    const partida = tablaPrimaria.find((p) => p.partidas === nombrePartida);
    return partida ? partida[mes] || 0 : 0;
  };

  //valores mes a mes 
 export const calcularValoresMensuales = (tablaPrimaria, meses) => {
    const mensual = {
      Clientes: {},
      Proveedores: {},
      Ventas: {},
      Costo: {},
      Gastos: {},
      Bancos: {},
      UtilidadOperativa: {},
      MargenBruto: {},
    };

    meses.forEach((mes) => {
      const ventasMes = obtenerValorPartida(tablaPrimaria, "Ventas", mes) * -1;
      const costoMes = obtenerValorPartida(tablaPrimaria, "Costo", mes);
      const gastosMes = obtenerValorPartida(tablaPrimaria, "Gastos", mes);
      const bancoMes = obtenerValorPartida(tablaPrimaria, "Bancos", mes) ;

      mensual.Clientes[mes] = obtenerValorPartida(tablaPrimaria,"Clientes", mes);
      mensual.Proveedores[mes] = obtenerValorPartida(tablaPrimaria,"Proveedores", mes)*-1;
      mensual.Ventas[mes] = ventasMes;
      mensual.Costo[mes] = costoMes;
      mensual.Gastos[mes] = gastosMes;
      mensual.Bancos[mes] = bancoMes;
      mensual.UtilidadOperativa[mes] = ventasMes - costoMes - gastosMes;
      mensual.MargenBruto[mes] = ventasMes - costoMes;
    });

    return mensual;

  };

  // Calcula los valores acumulados para cada partida y mes
   
  export const calcularAcumulados = (tablaPrimaria,meses) => {
    const acumulados = {
      Clientes: {},
      Proveedores: {},
      Ventas: {},
      Costo: {},
      Gastos: {},
      Bancos: {},
      UtilidadOperativa: {},
      MargenBruto: {},
    };

    let acumuladoClientes = 0;
    let acumuladoProveedores = 0;
    let acumuladoVentas = 0;
    let acumuladoCosto = 0;
    let acumuladoGastos = 0;
    let acumuladoBancos = 0;
    let acumuladoUtilidadOperativa = 0;
    let acumuladoMargenBruto = 0;

    meses.forEach((mes) => {
      

      //calcular valores derivados del mes actual
      const clienteMes = obtenerValorPartida(tablaPrimaria,"Clientes", mes);
      const proveedorMes = obtenerValorPartida(tablaPrimaria,"Proveedores", mes)*-1;
      const ventasMes = obtenerValorPartida(tablaPrimaria,"Ventas", mes)*-1;
      const costoMes = obtenerValorPartida(tablaPrimaria,"Costo", mes);
      const gastosMes = obtenerValorPartida(tablaPrimaria,"Gastos", mes);
      const bancoMes = obtenerValorPartida(tablaPrimaria,"Bancos", mes);
      const utilidadOperativaMes = ventasMes - costoMes - gastosMes;
      const margenBrutoMes = ventasMes - costoMes;

      acumuladoClientes += clienteMes;
      acumuladoProveedores += proveedorMes;
      acumuladoVentas += ventasMes;
      acumuladoCosto += costoMes;
      acumuladoGastos += gastosMes;
      acumuladoBancos += bancoMes;
      acumuladoUtilidadOperativa += utilidadOperativaMes;
      acumuladoMargenBruto += margenBrutoMes;

      acumulados.Clientes[mes] = acumuladoClientes;
      acumulados.Proveedores[mes] = acumuladoProveedores;
      acumulados.Ventas[mes] = acumuladoVentas;
      acumulados.Costo[mes] =   acumuladoCosto;
      acumulados.Gastos[mes] = acumuladoGastos;
      acumulados.Bancos[mes] = acumuladoBancos;
      acumulados.UtilidadOperativa[mes] = acumuladoUtilidadOperativa;
      acumulados.MargenBruto[mes] = acumuladoMargenBruto;
    });

    return acumulados;
    
  };

 