import api from '@/api';


export const historialService = {
    async getHistorialPersonal(tipoConexion, idPersonal) {
        try{
            const params = {
                tipoConexion: tipoConexion,
                idPersonal: idPersonal
            };

            const response = await api.get('/Historial/get-historialPersonal', { 
                params: params,
                paramsSerializer: {
                    indexes: null // Evita que se agreguen índices a arrays
                }
            });

            return response.data;
        }
        catch (error) {
            console.error('Error fetching areas:', error);
            throw error;
        }

    }

};