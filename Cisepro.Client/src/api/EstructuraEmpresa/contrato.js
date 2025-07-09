import api from "@/api";

export const contratoService = {
  async getProyectos(tipoConexion, soloActivos = false) {
    try {
      const params = {
        tipoConexion: tipoConexion,
        estado: soloActivos,
      };

      const response = await api.get("/Contrato/get-Personal-Contrato", {
        params: params,
        paramsSerializer: {
          indexes: null, // Evita que se agreguen índices a arrays
        },
      });

      return response.data;
    } catch (error) {
      console.error("Error fetching proyectos:", error);
      throw error;
    }
  },
};
