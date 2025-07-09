import api from "@/api";

export const sitiosService = {
  async getSitios(tipoConexion) {
    try {
      const params = {
        tipoConexion: tipoConexion,
      };

      const response = await api.get("/Sitio/get-sitios-min", {
        params: params,
        paramsSerializer: {
          indexes: null, // Evita que se agreguen índices a arrays
        },
      });

      return response.data;
    } catch (error) {
      console.error("Error fetching sitios:", error);
      throw error;
    }
  },
};
