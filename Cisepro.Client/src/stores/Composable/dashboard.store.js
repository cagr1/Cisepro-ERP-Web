
import { defineStore } from "pinia";


export const useDashboardStore = defineStore("masterData/dashboard", {
state: () => ({
    partidasData: null,
    cicloEfectivoData: null,
    analisisData: null,
    timestamp: null,
    
  }),

  actions: {
    setAll(data) {
      this.partidasData = data.partidas;
      this.cicloEfectivoData = data.cicloEfectivo;
      this.analisisData = data.analisis;
      this.timestamp = Date.now();
    }
  }
});