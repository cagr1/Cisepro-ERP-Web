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
// Debounce simple (evitar resize spam)
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


export const buildAnalisisCharts = async ({

    chartRef,
    clienteUltimoMes,
    proveedorUltimoMes,
    ventasUltimoMes,
    costoUltimoMes,
    gastoUltimoMes,
    utilidadOperativa  
}) => {
  
 const initChartCapital = await createChart(chartRef);
  if (!chart) return;

  chart.setOption({
    backgroundColor: "transparent",

    tooltip: {
      trigger: "item",
      formatter: ({ name, value }) =>
        `<strong>${name}:</strong> ${Number(value).toLocaleString("en-US")}`,
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
        rotate: 20,
      },
      axisLine: { show: false },
      axisTick: { show: false },
    },

    yAxis: {
      type: "value",
      axisLabel: { color: "#94a3b8" },
      splitLine: {
        show: true,
        lineStyle: { color: "#e5e7eb" },
      },
    },

    series: [
      {
        type: "bar",
        barWidth: 45,
        itemStyle: {
          color: "#6366f1",
          borderRadius: [6, 6, 0, 0],
        },
        data: [
          clienteUltimoMes,
          proveedorUltimoMes,
          ventasUltimoMes,
          costoUltimoMes,
          gastoUltimoMes,
          utilidadOperativa,
        ],
      },
    ],
  });
 window.addEventListener("resize", () => chart.resize());
  
};
