import { defineStore } from "pinia";
import { bancoService } from "@/api/Contabilidad/banco.js";
import { push } from "notivue";

export const useBancoStore = defineStore("masterDataBanco", {
  state: () => ({
    data: [],
    loading: false,
    error: null,
    lastUpdate: null,
    cacheDuration: 300000, // 5 minutes
  }),
  getters: {
    bancos: (state) => state.data,
    bancoOptions: (state) => state.data.map((banco) => ({
        id: banco.idBanco,
      nombre: banco.nombreBanco,
      })),
    shouldRefresh: (state) => {
      return (
        !state.lastUpdate || Date.now() - state.lastUpdate > state.cacheDuration
      );
    },
  },
  actions: {
    async fetchBancos(tipoConexion,forceRefresh = false) {
      


      if (!forceRefresh && !this.shouldRefresh) {
        return;
      }
      this.loading = true;
      try {
        const response = await bancoService.getBancos( tipoConexion);
        this.data = response.data;
        this.error = null;
        this.lastUpdate = Date.now(); // Update the last update time
        
      } catch (error) {
        push.error({
          title: "Error al cargar los cargos",
          message: error.message || "No se pudieron cargar los cargos.",
        });
      } finally {
        this.loading = false;
      }
    },
  },
});
