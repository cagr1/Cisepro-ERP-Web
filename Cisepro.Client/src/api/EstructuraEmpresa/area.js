import api from "@/api";

export const areaService = {
  async getAreas(tipoConexion) {
    try {
      const params = {
        tipoConexion: tipoConexion,
      };

      const response = await api.get("/Area/Get-Area", {
        params: params,
        paramsSerializer: {
          indexes: null, // Evita que se agreguen índices a arrays
        },
      });

      return response.data;
    } catch (error) {
      console.error("Error fetching areas:", error);
      throw error; // Re-lanzar el error para que pueda ser manejado por el llamador
    }
  },
};
