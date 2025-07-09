import { defineStore } from "pinia";
import { sitiosService } from "@/api/DivisionGeografica/sitios.js";
import { push } from "notivue";

export const useSitioStore = defineStore("masterDataSitio", {
  state: () => ({
    data: [],
    loading: false,
    error: null,
    lastUpdate: null,
    cacheDuration: 300000, // 5 minutes
  }),
  getters: {
    sitios: (state) => state.data,
    sitioOptions: (state) => state.data.map((sitio) => ({
        id: sitio.id_Sitio_trabajo,
      nombre: sitio.nombre_Sitio_trabajo,
      })),
    shouldRefresh: (state) => {
      return (
        !state.lastUpdate || Date.now() - state.lastUpdate > state.cacheDuration
      );
    },
  },
  actions: {
    async fetchCargos(tipoConexion) {
      


      if (!forceRefresh && !this.shouldRefresh) {
        return;
      }
      this.loading = true;
      try {
        const response = await sitiosService.getSitios( tipoConexion);
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
