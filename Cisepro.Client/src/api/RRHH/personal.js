import api from '@/api';


export const personalService = {
    async getPersonal(tipoConexion, filtro = '', page = 1, itemsPerPage = 20) {
            try {
                page = Math.max(1, Number(page) || 1); // Asegurarse de que page sea un número
                itemsPerPage = Number(itemsPerPage) || 20; // Asegurarse de que itemsPerPage sea un número
                
                const params = {
                    tipoConexion: tipoConexion,
                    page: page,
                    itemsPerPage: itemsPerPage
                };
                
                // Agregar filtro solo si no está vacío
                if (filtro && filtro.trim() !== '') {
                    params.filtro = filtro.trim();
                }

                // Realizar la solicitud con los parámetros
                const response = await api.get('/Personal/Get-Personal', { 
                    params: params,
                    paramsSerializer: {
                        indexes: null // Esto evita que se agreguen índices a arrays
                    }
                });

                return response.data;
            } catch (error) {
                if (error.response && error.response.data) {
                    return {
                        data: [],
                        pagination:{
                            totalRecords: 0, 
                            totalPages: 0,
                            page: 1,
                            itemsPerPage: itemsPerPage
                        }
                    };
            }
            console.error('Error fetching personal data:', error);
                throw error;
            }
        },
        async getPersonalContrato(tipoConexion, idPersonal) {
            try {
                const params = {
                    tipoConexion: tipoConexion,
                    id: idPersonal
                };

                const response = await api.get('/Contrato/Get-Contrato-PorPersonal', { 
                    params: params,
                    paramsSerializer: {
                        indexes: null // Esto evita que se agreguen índices a arrays
                    }
                });

                return response.data;
            } catch (error) {
                if (error.response?.status === 400) {
                  console.log('Error fetching personal data contract:', error.config.params);                   
                    return {
                            sucess: false,
                            data: null,
                            message: 'Error fetching personal data contract',
                            
                    };
            }
            console.error('Error fetching contract data:', error);
                throw error;

                }
            
        }
};