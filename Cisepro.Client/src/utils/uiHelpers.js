

export function updateVariacion(elementId, value) {
  const element = document.getElementById(elementId);
  if (!element) return;
  const isPositive = value >= 0;
  element.className = `card-variacion ${isPositive ? 'positive' : 'negative'}`;
  element.textContent = `${isPositive ? '+' : ''}${value.toFixed(2)}%`;
}



export function updateStats(ventas, acumulado, ventasPrevious, acumuladoPrevious, porcentajeActual, porcentajePrevious, utilidadesData, utilidadesAcumuladasData, porcentajeUtilidades, marginEarningsData, liquidezData) {
    const formatter = new Intl.NumberFormat('en-US', {
        style: 'currency',
        currency: 'USD'
    });

     // Validar y normalizar datos
    const safeVentas = ventas?.data?.totalSales ? ventas.data : { totalSales: 0 };
    const safeAcumulado = acumulado?.data?.totalSales ? acumulado.data : { totalSales: 0 };
    const safeVentasPrevious = ventasPrevious?.data?.totalSales ? ventasPrevious.data : { totalSales: 0 };
    const safeAcumuladoPrevious = acumuladoPrevious?.data?.totalSales ? acumuladoPrevious.data : { totalSales: 0 };
    const safePorcentajeActual = porcentajeActual || { variationPercentage: 0 };
    const safePorcentajePrevious = porcentajePrevious || { variationPercentage: 0 };
    const safeUtilidades = utilidadesData?.data ? utilidadesData.data : { totalEarnings: 0 };
    const safeUtilidadesAcumuladas = utilidadesAcumuladasData?.data ? utilidadesAcumuladasData.data : { totalEarnings: 0 };
    const safePorcentajeUtilidades = porcentajeUtilidades || { variationPercentage: 0 };
    const safeMarginEarnings = marginEarningsData?.data ? marginEarningsData.data : { totalEarnings: 0 };
    const safeLiquidez = liquidezData?.data ? liquidezData.data : { liquidityLevel: 0 };

    // Calcular métricas
    const margenNetoPorcentaje = parseFloat((safeMarginEarnings.totalEarnings * 100).toFixed(2));
    const metaMargenNetoUtilidades = 50.00;
    const variacionMargenNetoUtilidades = parseFloat((margenNetoPorcentaje - metaMargenNetoUtilidades).toFixed(2));
    const metaLiquidez = 1.5;
    const variacionliquidez = parseFloat((safeLiquidez.liquidityLevel - metaLiquidez).toFixed(2));

    // Actualizar UI de forma segura
    const updateElement = (id, value) => {
        const element = document.getElementById(id);
        if (element) element.textContent = value;
    };

    updateElement('ventasRango', formatter.format(safeVentas.totalSales));
    updateElement('ventasAcumuladas', formatter.format(safeAcumulado.totalSales) + ' acumulado');
    updateElement('ventasRangoPrevious', formatter.format(safeVentasPrevious.totalSales));
    updateElement('ventasAcumuladasPrevious', formatter.format(safeAcumuladoPrevious.totalSales) + ' acumulado');
    updateElement('porcentajeVentasActual', `${safePorcentajeActual.variationPercentage}%`);
    updateElement('porcentajeVentasPrevio', `${safePorcentajePrevious.variationPercentage}%`);
    updateElement('utilidadesActuales', formatter.format(safeUtilidades.totalEarnings));
    updateElement('utilidadesAcumuladas', formatter.format(safeUtilidadesAcumuladas.totalEarnings) + ' acumulado');
    updateElement('porcentajeUtilidades', `${safePorcentajeUtilidades.variationPercentage}%`);
    updateElement('margenUtilidadNeta', `${margenNetoPorcentaje}%`);
    updateElement('liquidezCorriente', `${safeLiquidez.liquidityLevel}%`);

    updateVariacion('porcentajeVentasActual', safePorcentajeActual.variationPercentage);
    updateVariacion('porcentajeVentasPrevio', safePorcentajePrevious.variationPercentage);
    updateVariacion('porcentajeUtilidades', safePorcentajeUtilidades.variationPercentage);
    updateVariacion('variacionMargen', variacionMargenNetoUtilidades);
    updateVariacion('variacionLiquidez', variacionliquidez);
}
