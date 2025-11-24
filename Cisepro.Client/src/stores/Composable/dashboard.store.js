
import { defineStore } from "pinia";


export const useDashboardStore = defineStore("masterData/dashboard", {
state: () => ({
    partidasData: null,
    cicloEfectivoData: null,
    analisisData: null,
    timestamp: null,
    
  }),

   getters: {
    isCacheValid: (state) => {
      if (!state.timestamp) return false;
      const MAX_TIME = 1000 * 60 * 3; // 3 minutos
      return (Date.now() - state.timestamp) < MAX_TIME;
    }
  },

  actions: {
    setAll(data) {
      this.partidasData = data.partidas;
      this.cicloEfectivoData = data.cicloEfectivo;
      this.analisisData = data.analisis;
      this.timestamp = Date.now();
    }
  }
});