import api from "@/api";

export const cuentaPersonalService = {
  async getCuentaPersonal(tipoConexion, idPersonal) {
    try {
      const params = {
        tipoConexion: tipoConexion,
        idPersonal: idPersonal,
      };

      const response = await api.get("/CuentaPersonal/get-cuenta-personal", {
        params: params,
        paramsSerializer: {
          indexes: null, // Evita que se agreguen índices a arrays
        },
      });

      return response.data;
    } catch (error) {
      console.error("Error fetching cuenta personal:", error);

      throw error;
    }
  },
};
