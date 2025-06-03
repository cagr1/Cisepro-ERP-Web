import api from '@/api';


export const cargoService = {
    async getCargos(tipoConexion) {
        try{
            const params = {
                tipoConexion: tipoConexion
            };

            const response = await api.get('/Cargo/get-Cargo', { 
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