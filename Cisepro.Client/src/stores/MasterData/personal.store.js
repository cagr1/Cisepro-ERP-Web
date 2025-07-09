import { defineStore } from "pinia";
import { personalService } from "@/api/RRHH/personal";
import { push } from "notivue";
import{ toDateInputFormat } from "@/utils/dateUtils";
import { blobToDataURL } from "@/utils/fileUtils";


export const usePersonalStore = defineStore("MasterData/personal", {
    state: () => ({
        
        isLoading: false,
        loadingHistorial: false,

        //Datos pricipales
        list: [],
        currentEmployee: null,
        searchResults: [],
        historialLaboral: [],

        //Paginacion
        pagination: {
            currentPage: 1,
            pageSize: 20,
            totalItems: 0,
            totalPages: 0
        },

        //Filtros de busqueda
        
    })

})
