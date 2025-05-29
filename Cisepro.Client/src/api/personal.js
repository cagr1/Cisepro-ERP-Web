import { get } from '@vueuse/core';
import api from '@/api';

export const personalService = {
    async getPersonal(tipoConexion, filtro = '', page = 1, itemsPerPage = 20) {
        try {
            const params = {
                tipoConexion,
                page,
                itemsPerPage
            };
            
            // Solo agregar filtro si no está vacío
            if (filtro && filtro.trim() !== '') {
                params.filtro = filtro;
            }

            const response = await api.get('/Personal/Get-Personal', { params });
            return response.data;
        } catch (error) {
            console.error('Error fetching personal data:', error);
            throw error;
        }
    }

};