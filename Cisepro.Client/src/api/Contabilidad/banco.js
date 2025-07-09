import api from "@/api";

export const bancoService = {
  async getBancos(tipoConexion) {
    try {
      const params = {
        tipoConexion: tipoConexion,
      };

      const response = await api.get("/Banco/get-bancos", {
        params: params,
        paramsSerializer: {
          indexes: null, // Evita que se agreguen índices a arrays
        },
      });

      return response.data;
    } catch (error) {
      console.error("Error fetching bancos:", error);
      throw error; // Re-throw the error for further handling if needed
    }
  },
};
