

export function updateVariacion(elementId, value) {
  const element = document.getElementById(elementId);
  if (!element) return;
  const isPositive = value >= 0;
  element.className = `card-variacion ${isPositive ? 'positive' : 'negative'}`;
  element.textContent = `${isPositive ? '+' : ''}${value.toFixed(2)}%`;
}

export function updateCardYears() {
  const dateInput = document.getElementById('startDate').value;
  if (dateInput) {
    const date = new Date(dateInput + 'T00:00:00Z');
    const currentYear = date.getUTCFullYear();
    const previousYear = currentYear - 1;
    document.querySelectorAll('.card-year-actual').forEach(el => el.textContent = currentYear);
    document.querySelectorAll('.card-year-previous').forEach(el => el.textContent = previousYear);
  }
}

export function setDefaultDates() {
  const currentYear = new Date().getFullYear();
  document.getElementById('startDate').value = `${currentYear}-01-01`;
  document.getElementById('endDate').value = `${currentYear}-12-31`;
}

export function updateStats(ventas, acumulado, ventasPrevious, acumuladoPrevious, porcentajeActual, porcentajePrevious, utilidadesData, utilidadesAcumuladasData, porcentajeUtilidades, marginEarningsData, liquidezData) {
    const formatter = new Intl.NumberFormat('en-US', {
        style: 'currency',
        currency: 'USD'
    });

    const margenNetoPorcentaje = parseFloat((marginEarningsData.totalEarnings * 100).toFixed(2));
    const metaMargenNetoUtilidades = 50.00;
    const variacionMargenNetoUtilidades = parseFloat((margenNetoPorcentaje - metaMargenNetoUtilidades).toFixed(2));
    const metaLiquidez = 1.5;
    const variacionliquidez = parseFloat((liquidezData.liquidityLevel - metaLiquidez).toFixed(2));

    document.getElementById('ventasRango').textContent = formatter.format(ventas.totalSales);
    document.getElementById('ventasAcumuladas').textContent = formatter.format(acumulado.totalSales) + ' acumulado';
    document.getElementById('ventasRangoPrevious').textContent = formatter.format(ventasPrevious.totalSales);
    document.getElementById('ventasAcumuladasPrevious').textContent = formatter.format(acumuladoPrevious.totalSales) + ' acumulado';
    document.getElementById('porcentajeVentasActual').textContent = `${porcentajeActual}%`;
    document.getElementById('porcentajeVentasPrevio').textContent = `${porcentajePrevious}%`;
    document.getElementById('utilidadesActuales').textContent = formatter.format(utilidadesData.totalEarnings);
    document.getElementById('utilidadesAcumuladas').textContent = formatter.format(utilidadesAcumuladasData.totalEarnings) + ' acumulado';
    document.getElementById('porcentajeUtilidades').textContent = `${porcentajeUtilidades}%`;
    document.getElementById('margenUtilidadNeta').textContent = `${margenNetoPorcentaje}%`;
    document.getElementById('liquidezCorriente').textContent = `${liquidezData.liquidityLevel}%`;

    updateVariacion('porcentajeVentasActual', porcentajeActual.variationPercentage);
    updateVariacion('porcentajeVentasPrevio', porcentajePrevious.variationPercentage);
    updateVariacion('porcentajeUtilidades', porcentajeUtilidades.variationPercentage);
    updateVariacion('variacionMargen', variacionMargenNetoUtilidades);
    updateVariacion('variacionLiquidez', variacionliquidez);
}