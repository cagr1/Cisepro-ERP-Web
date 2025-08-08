import * as echarts from 'echarts';

const chartInstances = {
    financialChart: null,
    salesChart:null
};

// Función para limpiar y renderizar el gráfico financiero
export function renderFinancialChart(chartDom, data) {
  try {
    if (!data || data.length === 0) {
      console.warn('Datos financieros vacíos');
      return;
    }

if (!chartDom || chartDom.clientWidth === 0 || chartDom.clientHeight === 0) {
  console.warn('El contenedor del gráfico no tiene dimensiones todavía.');
  return;
}

    // Limpiar instancia anterior si existe
    if (chartInstances.financialChart) {
      chartInstances.financialChart.dispose();
    }




    // Inicializar el gráfico
    chartInstances.financialChart = echarts.init(chartDom);

    // Configuración del gráfico
    const option = {
      tooltip: {
        trigger: 'axis',
        axisPointer: {
          type: 'cross',
          label: {
            backgroundColor: '#6a7985'
          }
        },
        formatter: function(params) {
          let result = `<strong>${params[0].axisValue}</strong><br/>`;
          params.forEach(param => {
            const value = param.value >= 0 
              ? `$${param.value.toLocaleString()}` 
              : `-$${Math.abs(param.value).toLocaleString()}`;
            result += `${param.marker} ${param.seriesName}: ${value}<br/>`;
          });
          return result;
        }
      },
      legend: {
        data: ['Ingresos', 'Egresos', 'Utilidad'],
        textStyle: {
          fontWeight: 'bold'
        }
      },
      grid: {
        left: '3%',
        right: '4%',
        bottom: '3%',
        containLabel: true
      },
      xAxis: {
        type: 'category',
        boundaryGap: false,
        data: data.map(d => d.nameMonth),
        axisLabel: {
          rotate: 30,
          fontWeight: 'bold'
        }
      },
      yAxis: {
        type: 'value',
        axisLabel: {
          formatter: '${value}',
          fontWeight: 'bold'
        },
        axisLine: {
          show: true
        },
        splitLine: {
          lineStyle: {
            type: 'dashed'
          }
        }
      },
      series: [
        {
          name: 'Ingresos',
          type: 'line',
          stack: 'total',
          smooth: true,
          lineStyle: {
            width: 2,
            color: '#5470C6'
          },
          areaStyle: {
            color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [
              { offset: 0, color: 'rgba(37, 99, 235, 0.5)' },
              { offset: 1, color: 'rgba(37, 99, 235, 0.1)' }
            ])
          },
          emphasis: {
            focus: 'series'
          },
          symbol: 'circle',
          symbolSize: 3,
          itemStyle: {
            color: '#5470C6'
          },
          data: data.map(d => d.totalIncome)
        },
        {
          name: 'Egresos',
          type: 'line',
          stack: 'total',
          smooth: true,
          lineStyle: {
            width: 2,
            color: '#EE6666'
          },
          areaStyle: {
            color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [
              { offset: 0, color: 'rgba(238, 102, 102, 0.5)' },
              { offset: 1, color: 'rgba(238, 102, 102, 0.1)' }
            ])
          },
          emphasis: {
            focus: 'series'
          },
          symbol: 'circle',
          symbolSize: 3,
          itemStyle: {
            color: '#EE6666'
          },
          data: data.map(d => -Math.abs(d.totalExpenses))
        },
        {
          name: 'Utilidad',
          type: 'line',
          smooth: true,
          lineStyle: {
            width: 3,
            color: '#91CC75'
          },
          emphasis: {
            focus: 'series'
          },
          symbol: 'diamond',
          symbolSize: 7,
          itemStyle: {
            color: '#91CC75'
          },
          markLine: {
            silent: true,
            lineStyle: {
              color: '#91CC75',
              type: 'dashed'
            },
            data: [{
              yAxis: 0
            }]
          },
          data: data.map(d => d.totalEarnings)
        }
      ]
    };

    // Aplicar la configuración
    chartInstances.financialChart.setOption(option);

    // Retornar la instancia para manejo externo
    return chartInstances.financialChart;
  } catch (error) {
    console.error('Error al renderizar el gráfico financiero:', error);
    return null;
  }
}

// Función para limpiar y renderizar el gráfico de ventas por categoría
export function renderSalesCategoryChart(chartDom, data) {
  try {
    if (!data || data.length === 0) {
      console.warn('Datos de ventas por categoría vacíos');
      return;
    }

    // Limpiar instancia anterior si existe
    if (chartInstances.salesChart) {
      chartInstances.salesChart.dispose();
    }

    

    // Inicializar el gráfico
    chartInstances.salesChart = echarts.init(chartDom);

    // Ordenar datos
    const sortedData = [...data].sort((a, b) => b.saldo - a.saldo);

    // Preparar datos
    const categories = sortedData.map(item => item.description);
    const values = sortedData.map(item => item.saldo);
    const colors = ['#5470C6', '#91CC75', '#FAC858', '#EE6666', '#73C0DE', '#3BA272'];

    // Configuración del gráfico
    const option = {
      tooltip: {
        trigger: 'axis',
        formatter: (params) => {
          const item = params[0];
          return `${item.name}<br/>Ventas: $${item.value.toLocaleString()}`;
        }
      },
      xAxis: {
        type: 'category',
        data: categories,
        axisLabel: {
          rotate: 45,
          formatter: (value) => 
            value.length > 20 ? value.substring(0, 15) + '...' : value,
          fontSize: 12
        }
      },
      yAxis: {
        type: 'value',
        axisLabel: {
          formatter: (value) => `$${value.toLocaleString()}`
        },
        splitLine: { show: false }
      },
      series: [{
        name: 'Ventas',
        type: 'bar',
        data: values.map((value, index) => ({
          value: value,
          itemStyle: { color: colors[index % colors.length] }
        })),
        label: {
          show: true,
          position: 'inside',
          formatter: (params) => `$${params.value.toLocaleString()}`
        }
      }],
      grid: {
        bottom: '25%',
        top: '20%'
      },
      dataZoom: [{
        type: 'slider',
        yAxisIndex: 0,
        start: 95,
        end: 100
      }]
    };

    

    // Aplicar la configuración
    chartInstances.salesChart.setOption(option);

    // Retornar la instancia para manejo externo
    return chartInstances.salesChart;
  } catch (error) {
    console.error('Error al renderizar el gráfico de ventas por categoría:', error);
    return null;
  }
}

// Función para limpiar todos los gráficos
export function disposeAllCharts() {
  if (chartInstances.financialChart) {
    chartInstances.financialChart.dispose();
    chartInstances.financialChart = null;
  }
  if (chartInstances.salesChart) {
    chartInstances.salesChart.dispose();
    chartInstances.salesChart = null;
  }
}

// Función para redimensionar todos los gráficos
export function resizeAllCharts() {
  if (chartInstances.financialChart) {
    chartInstances.financialChart.resize();
  }
  if (chartInstances.salesChart) {
    chartInstances.salesChart.resize();
  }
}