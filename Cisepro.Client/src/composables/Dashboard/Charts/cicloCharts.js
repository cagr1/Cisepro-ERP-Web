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


export const buildCicloCharts = ({
  mesesActivos,
  mensual,
  chartCicloRef,
  chartCapitalTrabajoRef,
}) => {
  if (!mesesActivos || mesesActivos.length === 0) return;

  

//Chart Ciclo efectivo
const initChartCiclo = async () => {
  if (!chartCicloRef.value) return;

  const meses = mesesActivos.map((m) => m.toUpperCase());
  const chart = await createChart(chartCicloRef);

  chart.setOption({
    backgroundColor: "transparent",
    tooltip: {
      trigger: "axis",
      axisPointer: { type: "shadow" },
      formatter: (params) => {
        let html = `<strong>${params[0].axisValue}</strong><br>`;
        params.forEach(p => {
          const val = Number(p.value).toLocaleString("en-US");
          html += `${p.marker} ${p.seriesName}: ${val} días<br>`;
        });
        return html;
      }
    },

    legend: {
      top: 0,
      textStyle: { color: "#64748b", fontWeight: 600 }
    },

    grid: { top: 50, left: 50, right: 50, bottom: 40 },

    xAxis: {
      type: "category",
      data: meses,
      axisLabel: { color: "#64748b", fontWeight: 600 },
      axisTick: { show: false },
      axisLine: { show: false }
    },

    yAxis: {
      type: "value",
      axisLabel: { color: "#94a3b8" },
      splitLine: {
        show: true,
        lineStyle: { color: "#e5e7eb" }
      }
    },

    series: [
      // --- STACKED BARS ---
      
      {
        name: "Días Cartera",
        type: "bar",
        stack: "ciclo",
        barWidth: 40,
        itemStyle: { color: "#4F9BFF" },
        data: mesesActivos.map(m => mensual[m].diasCxc ?? 0)
      },
      {
        name: "Días Proveedores",
        type: "bar",
        stack: "ciclo",
        barWidth: 40,
        itemStyle: { color: "#56D364" },
        
        data: mesesActivos.map(m => mensual[m]?.diasCxp )
      },

      // --- LINEA CICLO EFECTIVO ---
      {
        name: "Ciclo Efectivo",
        type: "line",
        smooth: true,
        symbol: "circle",
        symbolSize: 8,
        yAxisIndex: 0,
        itemStyle: { color: "#F7C04A" },
        lineStyle: {
          width: 3,
          color: "#F7C04A"
        },
        data: mesesActivos.map(m => mensual[m].cicloEfectivo)
      }
    ]
  });

  window.addEventListener("resize", chart.resize);
};

const initChartCapitalTrabajo = async () => {
  if (!chartCapitalTrabajoRef.value) return;

  const meses = mesesActivos.map((m) => m.toUpperCase());
  const chart = await createChart(chartCapitalTrabajoRef);

  chart.setOption({
    backgroundColor: "transparent",
    tooltip: {
      trigger: "axis",
      axisPointer: { type: "line" },
      formatter: (params) => {
        let html = `<strong>${params[0].axisValue}</strong><br>`;
        params.forEach(p => {
          const val = Number(p.value).toLocaleString("en-US");
          html += `${p.marker} ${p.seriesName}: $${val}<br>`;
        });
        return html;
      }
    },

    legend: {
      top: 0,
      textStyle: { color: "#64748b", fontWeight: 600 }
    },

    grid: { top: 50, left: 50, right: 50, bottom: 40 },

    xAxis: {
      type: "category",
      data: meses,
      axisLabel: { 
        color: "#64748b", 
        fontWeight: 600,
        
       },
      axisTick: { show: false },
      axisLine: { show: false }
    },

    yAxis: {
      type: "value",
      axisLabel: { 
        color: "#94a3b8",
        formatter: (value) => {
            // Formateador para mostrar K en miles
            if (value >= 1000 || value < 0) {
              return `$${(value / 1000).toFixed(0)}K`;
            }
            return `$${value}`;
          },

       },
      splitLine: {
        show: true,
        lineStyle: { color: "#e5e7eb" }
      }
    },

    series: [
      {
        name: "Capital Trabajo",
        type: "line",
        smooth: true,
        symbol: "circle",
        symbolSize: 8,
        yAxisIndex: 0,
        itemStyle: { color: "#4F46E5" },
        lineStyle: {
          width: 3,
          color: "#4F46E5"
        },
        data: mesesActivos.map(m => mensual[m]?.capitalTrabajo)
      },

      {
        name: "Saldo Banco",
        type: "line",
        smooth: true,
        symbol: "circle",
        symbolSize: 8,
        yAxisIndex: 0,
        itemStyle: { color: "#0EA5E9" },
        lineStyle: {
          width: 3,
          color: "#0EA5E9",
          type: "dashed"
        },
        data: mesesActivos.map(m => mensual[m].saldoBanco)
      },

       {
        name: "Caja mínima requerida",
        type: "line",
        smooth: true,
        symbol: "circle",
        symbolSize: 8,
        lineStyle: {
          width: 3,
          color: "#F43F5E" // Rose
        },
        itemStyle: { color: "#F43F5E" },
        data: mesesActivos.map(m => mensual[m]?.cajaMinimaRequerida ?? 0)
      }

    ]

  });

  window.addEventListener("resize", chart.resize);

}
  

initChartCiclo();
initChartCapitalTrabajo();
}


