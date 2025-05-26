import { get } from '@vueuse/core';
import api from '@/api';

export const personalService = {
    async getPersonal(tipoConexion, filtro = '') {
        try {
            const response = await api.get('/Personal/Get-Personal',
                {
                    params: {
                        tipoConexion,
                        filtro
                    }
                }
            );
            return response.data;
        } catch (error) {
            console.error('Error fetching personal data:', error);
            throw error;
        }
    }

};