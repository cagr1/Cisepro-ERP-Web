import api from '@/api';
import { getTransitionRawChildren } from 'vue';

export const areaService = {
    async getAreas(tipoConexion) {
        try{
            const params = {
                tipoConexion: tipoConexion
            };

            const response = await api.get('/Area/Get-Area', { 
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