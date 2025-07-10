import { defineStore } from "pinia";
import { contratoService } from "@/api/EstructuraEmpresa/contrato.js";
import { push } from "notivue";

export const useContratoStore = defineStore("masterData/contrato", {
  state: () => ({
    data: [],
    loading: false,
    error: null,
    lastUpdate: null,
    cacheDuration: 300000, // 5 minutes
  }),
  getters: {
    contratos: (state) => state.data,
    contratoOptions: (state) => state.data.map((contrato) => ({
        id: contrato.idProyecto,
        nombre: contrato.nombreProyecto,
      })),
    shouldRefresh: (state) => {
      return (
        !state.lastUpdate || Date.now() - state.lastUpdate > state.cacheDuration
      );
    },
  },
  actions: {
    async fetchContratos(tipoConexion, forceRefresh = false) {



      if (!forceRefresh && !this.shouldRefresh) {
        return;
      }
      this.loading = true;
      try {
        const response = await contratoService.getProyectos( tipoConexion, true);
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
