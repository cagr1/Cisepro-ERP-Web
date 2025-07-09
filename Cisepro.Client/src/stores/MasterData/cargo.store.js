import { defineStore } from "pinia";
import { cargoService } from "@/api/EstructuraEmpresa/cargo.js";

import { push } from "notivue";

export const useCargoStore = defineStore("masterDataCargo", {
  state: () => ({
    data: [],
    loading: false,
    error: null,
    lastUpdate: null,
    cacheDuration: 300000, // 5 minutes
  }),
  getters: {
    cargos: (state) => state.data,
    cargoOptions: (state) => state.data.map((cargo) => ({
        id: cargo.idCargoOcupacional,
        nombre: cargo.descripcion,
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
        const response = await cargoService.getCargos(tipoConexion);
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
