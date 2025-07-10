import { defineStore } from "pinia";
import { areaService } from "@/api/EstructuraEmpresa/area.js";

import { push } from "notivue";


export const useAreaStore = defineStore("masterData/area", {
  state: () => ({
    data: [],
    loading: false,
    error: null,
    lastUpdate: null,
    cacheDuration: 300000, // 5 minutes
  }),
  getters: {
    areas: (state) => state.data,
    areasOptions: (state) => state.areas.map(area => ({
        id: area.idAreaGeneral,
        nombre: area.nombreArea,
      })),
      shouldRefresh: (state) => {          
        return !state.lastUpdate || 
          (Date.now() - state.lastUpdate) > state.cacheDuration;
      }
  },
  actions: {
    async fetchAreas(tipoConexion, forceRefresh = false) {
      

        if (!tipoConexion) {
          throw new Error("Tipo de conexión no proporcionado");
        }

        if (!forceRefresh && !this.shouldRefresh) {
          return;
        }
        
        this.loading = true;

      try {
        const response = await areaService.getAreas(tipoConexion);
        this.data = response.data;
        this.error = null;
        this.lastUpdate = Date.now(); // Update the last update time
      } catch (error) {
        push.error({
          title: "Error al cargar las áreas",
          message: error.message || "No se pudieron cargar las áreas.",
        });
      } finally {
        this.loading = false;
      }
    }
  }
});
