import * as echarts from "echarts";

const waitForElementSize = (el) => {
  return new Promise((resolve) => {
    const check = () => {
      if (el.clientWidth > 0 && el.clientHeight > 0) resolve();
      else requestAnimationFrame(check);
    };
    check();
  });
};

const debounce = (fn, delay = 200) => {
  let t;
  return (...args) => {
    clearTimeout(t);
    t = setTimeout(() => fn(...args), delay);
  };
};

const createChart = async (elRef) => {
  if (!elRef.value) return null;
  await waitForElementSize(elRef.value);

  let chart = echarts.getInstanceByDom(elRef.value);

  if (!chart) {
    chart = echarts.init(elRef.value);
    window.addEventListener("resize", debounce(() => chart.resize()));
  }

  return chart;
};

export const buildAnalisisCharts = ({
  chartRef,
  clienteUltimoMes,
  proveedorUltimoMes,
  ventasUltimoMes,
  costoUltimoMes,
  gastosUltimoMes,
  utilidadOperativa  
}) => {
  
  const initChartCapital = async () => { 
    if (!chartRef.value) return;
    const chart = await createChart(chartRef);
    if (!chart) return;

    // Colores con gradientes para cada barra
    const colorPalette = [
      new echarts.graphic.LinearGradient(0, 0, 0, 1, [
        { offset: 0, color: '#22D3EE' },
        { offset: 1, color: '#06B6D4' }
      ]),
      new echarts.graphic.LinearGradient(0, 0, 0, 1, [
        { offset: 0, color: '#34D399' },
        { offset: 1, color: '#10B981' }
      ]),
      new echarts.graphic.LinearGradient(0, 0, 0, 1, [
        { offset: 0, color: '#60A5FA' },
        { offset: 1, color: '#3B82F6' }
      ]),
      new echarts.graphic.LinearGradient(0, 0, 0, 1, [
        { offset: 0, color: '#F87171' },
        { offset: 1, color: '#EF4444' }
      ]),
      new echarts.graphic.LinearGradient(0, 0, 0, 1, [
        { offset: 0, color: '#FBBF24' },
        { offset: 1, color: '#F59E0B' }
      ]),
      new echarts.graphic.LinearGradient(0, 0, 0, 1, [
        { offset: 0, color: '#A78BFA' },
        { offset: 1, color: '#8B5CF6' }
      ])
    ];

    const data = [
      clienteUltimoMes,
      proveedorUltimoMes,
      ventasUltimoMes,
      costoUltimoMes,
      gastosUltimoMes,
      utilidadOperativa,
    ];

    chart.setOption({
      backgroundColor: "transparent",

      tooltip: {
        trigger: "axis",
        axisPointer: {
          type: "shadow",
          shadowStyle: {
            color: "rgba(0, 0, 0, 0.05)"
          }
        },
        backgroundColor: "rgba(255, 255, 255, 0.95)",
        borderColor: "#e5e7eb",
        borderWidth: 1,
        textStyle: {
          color: "#374151",
          fontSize: 13
        },
        padding: [10, 15],
        formatter: (params) => {
          const { name, value, color } = params[0];
          const formattedValue = new Intl.NumberFormat("en-US", {
            style: "currency",
            currency: "USD",
            minimumFractionDigits: 0,
            maximumFractionDigits: 0
          }).format(value);
          
          return `
            <div style="font-weight: 600; margin-bottom: 4px;">${name}</div>
            <div style="display: flex; align-items: center; gap: 8px;">
              <span style="display: inline-block; width: 10px; height: 10px; border-radius: 50%; background: ${color};"></span>
              <span style="font-size: 15px; font-weight: 700;">${formattedValue}</span>
            </div>
          `;
        }
      },

      grid: { 
        top: 40, 
        left: 60, 
        right: 40, 
        bottom: 80,
        containLabel: true
      },

      xAxis: {
        type: "category",
        data: [
          "Clientes",
          "Proveedores",
          "Ventas",
          "Costo",
          "Gastos",
          "Utilidad Op.",
        ],
        axisLabel: {
          color: "#64748b",
          fontWeight: 600,
          fontSize: 12,
          rotate: 25,
          margin: 15
        },
        axisLine: { 
          show: true,
          lineStyle: {
            color: "#e5e7eb"
          }
        },
        axisTick: { 
          show: true,
          lineStyle: {
            color: "#e5e7eb"
          }
        },
      },

      yAxis: {
        type: "value",
        axisLabel: { 
          color: "#94a3b8",
          fontSize: 11,
          fontWeight: 500,
          formatter: (value) => {
            if (Math.abs(value) >= 1000) {
              return `$${(value / 1000).toFixed(0)}K`;
            }
            return `$${value}`;
          }, 
        },
        splitLine: {
          show: true,
          lineStyle: { 
            color: "#f1f5f9",
            type: "dashed"
          },
        },
        axisLine: {
          show: false
        }
      },

      series: [
        {
          type: "bar",
          barWidth: 50,
          itemStyle: {
            borderRadius: [8, 8, 0, 0],
            shadowBlur: 10,
            shadowColor: "rgba(0, 0, 0, 0.1)",
            shadowOffsetY: 4,
          },
          emphasis: {
            itemStyle: {
              shadowBlur: 15,
              shadowColor: "rgba(0, 0, 0, 0.2)",
              shadowOffsetY: 6,
            }
          },
          data: data.map((value, index) => ({
            value,
            itemStyle: {
              color: colorPalette[index]
            }
          })),
        },
      ],

      // Animación suave
      animationDuration: 1000,
      animationEasing: "cubicOut"
    });

    window.addEventListener("resize", () => chart.resize());
  };

  initChartCapital();
};