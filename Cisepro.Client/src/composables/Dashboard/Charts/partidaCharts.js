// src/api/Dashboard/PartidaCharts.js
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

/* -------------------------------------------------------
   CHART FACTORY
------------------------------------------------------- */

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


export const buildPartidaCharts = ({
  mesesActivos,
  mensual,
  chartVentasRef,
  chartUtilidadRef,
}) => {
  if (!mesesActivos || mesesActivos.length === 0) return;

  const palette = {
    ventas: "#4F9BFF",
    costo: "#FF6A6A",
    gastos: "#F7C04A",
    margenBruto: "#56D364",
    utilidadOperativa: "#9B7FFF",
  };

  // ============================
  //   CHART 1: Ventas, Costo, Gastos
  // ============================
  const initChartVentas = async () => {
    if (!chartVentasRef.value) return;

    const meses = mesesActivos.map((m) => m.toUpperCase());

    const chart = await createChart(chartVentasRef);
    

    chart.setOption({
      backgroundColor: "transparent",
      tooltip: {
        trigger: "axis",
        axisPointer: {
          type: "line",
          lineStyle: {
            color: "#94a3b8",
            width: 1,
            type: "dashed",
          },
        },
        formatter: (params) => {
          let html = `<strong>${params[0].axisValue}</strong><br>`;
          params.forEach((p) => {
            const val = Number(p.value).toLocaleString("en-US");
            html += `${p.marker} ${p.seriesName}: $${val}<br>`;
          });
          return html;
        },
      },

      legend: {
        data: ["Ventas", "Costo", "Gastos"],
        top: 0,
        textStyle: { color: "#666666", fontWeight: "600" },
      },

      grid: {
        top: 50,
        left: 50,
        right: 30,
        bottom: 40,
      },

      xAxis: {
        type: "category",
        data: meses,
        axisLabel: { color: "#666666", fontWeight: "600" },
        axisLine: { lineStyle: { color: "#666666" }, show: false },
        axisTick: { show: false },
        splitLine: {
          show: false,
        },
      },

      yAxis: {
        type: "value",
        axisLabel: {
          color: "#cbd5e1",
          fontWeight: "100",
          formatter: (value) => {
            // Formateador para mostrar K en miles
            if (value >= 1000) {
              return `$${(value / 1000).toFixed(0)}K`;
            }
            return `$${value}`;
          },
        },
        axisLine: { show: false },
        splitLine: {
          show: true,
          lineStyle: {
            color: "#e5e7eb", // Gris claro para las líneas de fondo
            width: 1,
            type: "solid",
          },
        },
      },

      series: [
        {
          name: "Ventas",
          type: "line",
          smooth: true,
          symbol: "circle",
          symbolSize: 6,

          lineStyle: {
            width: 3,
            color: palette.ventas,
            shadowColor: palette.ventas + "55",
            shadowBlur: 10,
          },
          areaStyle: {
            opacity: 1,
            color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [
              { offset: 0, color: palette.ventas + "aa" },
              { offset: 1, color: palette.ventas + "11" },
            ]),
          },
          data: mesesActivos.map((m) => mensual.Ventas[m]),
          emphasis: {
            focus: "series",
            lineStyle: { width: 4 },
            itemStyle: { borderWidth: 2, borderColor: "#fff" },
          },
        },
        {
          name: "Costo",
          type: "line",
          smooth: true,
          symbol: "circle",
          symbolSize: 6,
          itemStyle: { color: palette.costo },
          lineStyle: {
            width: 3,
            color: palette.costo,
            shadowColor: palette.costo + "55",
            shadowBlur: 10,
          },
          areaStyle: {
            opacity: 1,
            color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [
              { offset: 0, color: palette.costo + "aa" },
              { offset: 1, color: palette.costo + "22" },
            ]),
          },
          data: mesesActivos.map((m) => mensual.Costo[m]),
          emphasis: {
            focus: "series",
            lineStyle: { width: 4 },
            itemStyle: { borderWidth: 2, borderColor: "#fff" },
          },
        },
        {
          name: "Gastos",
          type: "line",
          smooth: true,
          symbol: "circle",
          symbolSize: 6,
          data: mesesActivos.map((m) => mensual.Gastos[m]),
          itemStyle: { color: palette.gastos },
          lineStyle: {
            width: 3,
            color: palette.gastos,
            shadowColor: palette.gastos + "55",
            shadowBlur: 10,
          },
          areaStyle: {
            opacity: 1,
            color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [
              { offset: 0, color: palette.gastos + "aa" },
              { offset: 1, color: palette.gastos + "22" },
            ]),
          },
          emphasis: {
            focus: "series",
            lineStyle: { width: 4 },
            itemStyle: { borderWidth: 2, borderColor: "#fff" },
          },
        },
      ],
    });

    window.addEventListener("resize", chart.resize);
  };

  

  // ============================
  //   CHART 2: Margen Bruto / Utilidad Operativa
  // ============================
  const initChartUtilidad = async () => {
  if (!chartUtilidadRef.value) return;

  await waitForElementSize(chartUtilidadRef.value);

  const chart = await createChart(chartUtilidadRef);
  const meses = mesesActivos.map((m) => m.toUpperCase());

  chart.setOption({
    backgroundColor: "transparent",

    tooltip: {
      trigger: "axis",
      axisPointer: {
        type: "line",
        lineStyle: {
          color: "#94a3b8",
          width: 1,
          type: "dashed",
        },
      },
      formatter: (params) => {
        let html = `<strong>${params[0].axisValue}</strong><br>`;
        params.forEach((p) => {
          const val = Number(p.value).toLocaleString("en-US");
          html += `${p.marker} ${p.seriesName}: $${val}<br>`;
        });
        return html;
      },
    },

    legend: {
      data: ["Margen Bruto", "Utilidad Operativa"],
      top: 0,
      textStyle: { color: "#666666", fontWeight: "600" },
    },

    // Igual al chartVentas
    grid: {
      top: 50,
      left: 50,
      right: 30,
      bottom: 40,
    },

    xAxis: {
      type: "category",
      data: meses,
      axisLabel: { color: "#666666", fontWeight: "600" },
      axisLine: { show: false },
      axisTick: { show: false },
      splitLine: { show: false },
    },

    yAxis: {
      type: "value",
      axisLabel: {
        color: "#cbd5e1",
        fontWeight: "100",
         formatter: (value) => {
            // Formateador para mostrar K en miles
            if (value >= 1000 || value < 0) {
              return `$${(value / 1000).toFixed(0)}K`;
            }
            return `$${value}`;
          },
      },
      axisLine: { show: false },
      splitLine: {
        show: true,
        lineStyle: {
          color: "#e5e7eb",
          width: 1,
          type: "solid",
        },
      },
    },

    series: [
      {
        name: "Margen Bruto",
        type: "bar",
        barWidth: 12, 
        itemStyle: {
          color: palette.margenBruto,
          borderRadius: [6, 6, 0, 0],
          shadowBlur: 8,
          shadowColor: palette.margenBruto + "44",
        },
        emphasis: {
          focus: "series",
          itemStyle: {
            shadowBlur: 15,
            shadowColor: palette.margenBruto + "66",
          },
        },
        data: mesesActivos.map((m) => mensual.MargenBruto[m]),
      },
      {
        name: "Utilidad Operativa",
        type: "bar",
        barWidth: 12,
        itemStyle: {
          color: palette.utilidadOperativa,
          borderRadius: [6, 6, 0, 0],
          shadowBlur: 8,
          shadowColor: palette.utilidadOperativa + "44",
        },
        emphasis: {
          focus: "series",
          itemStyle: {
            shadowBlur: 15,
            shadowColor: palette.utilidadOperativa + "66",
          },
        },
        data: mesesActivos.map((m) => mensual.UtilidadOperativa[m]),
      },
    ],
  });

  window.addEventListener("resize", chart.resize);
};

  // Inicializar ambos charts
  initChartVentas();
  initChartUtilidad();
};
