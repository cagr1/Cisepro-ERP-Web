import api from '@/api';
import { push } from 'notivue';

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
            push.error({
                title: 'Error fetching historial personal',
                message: error.message || 'No se pudo cargar el historial personal.'
            })
            
            throw error;
        }

    }

};