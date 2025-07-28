import api from "@/api";
import { formatDateWithTime} from "@/utils/dateUtils";
import { updateStats, updateVariacion, updateCardYears} from "@/utils/uiHelpers";
import { useAuthStore } from "@/stores/auth.store";


const authStore = useAuthStore();
const tipoConexion = authStore.selectedCompany;


export async function loadData() {
     // Obtener fechas de los inputs        
    const startDateInput = document.getElementById('startDate').value;
    const endDateInput = document.getElementById('endDate').value;
    
    // Agregar tiempos automáticamente
    const startDate = formatDateWithTime(startDateInput);
    const endDate = formatDateWithTime(endDateInput, true);
    const year = startDateInput ? new Date(startDateInput).getUTCFullYear() : new Date().getUTCFullYear();
    const previousStartDate = formatDateWithTime(startDateInput, false, true);
    const previousEndDate = formatDateWithTime(endDateInput, true, true);

    
    
    try {

     // Grupo Ventas
        const [ventasData, acumuladoData] = await Promise.all([
            fetchData(`/Dashboard/sales/by-date?tipoConexion=${tipoConexion}&startDate=${encodeURIComponent(startDate)}&endDate=${encodeURIComponent(endDate)}`),
            fetchData(`/Dashboard/sales/accumulated?tipoConexion=${tipoConexion}&endDate=${encodeURIComponent(endDate)}`)
        ]);
        
        // Grupos ventas anteriores
        const [ventasPreviousData, acumuladoPreviousData] = await Promise.all([
            fetchData(`/Dashboard/sales/by-date?tipoConexion=${tipoConexion}&startDate=${encodeURIComponent(previousStartDate)}&endDate=${encodeURIComponent(previousEndDate)}`),
            fetchData(`/Dashboard/sales/accumulated?tipoConexion=${tipoConexion}&endDate=${encodeURIComponent(previousEndDate)}`)
        ]);
        
        // Grupo Porcentaje Ventas
        const [porcentajeVentasActual, porcentajeVentasPrevious] = await Promise.all([
            fetchData(`/Dashboard/variation/income?tipoConexion=${tipoConexion}&startDate=${encodeURIComponent(startDate)}&endDate=${encodeURIComponent(endDate)}`),
            fetchData(`/Dashboard/variation/income?tipoConexion=${tipoConexion}&startDate=${encodeURIComponent(previousStartDate)}&endDate=${encodeURIComponent(previousEndDate)}`)
        ]);

        // Grupo Utilidades
        const [utilidadesData, utilidadesAcumuladasData, porcentajeUtilidades] = await Promise.all([
            fetchData(`/Dashboard/annual-earnings?tipoConexion=${tipoConexion}&startDate=${encodeURIComponent(startDate)}&endDate=${encodeURIComponent(endDate)}`),
            fetchData(`/Dashboard/accumulated-earnings?tipoConexion=${tipoConexion}&endDate=${encodeURIComponent(endDate)}`),
            fetchData(`/Dashboard/variation/profit?tipoConexion=${tipoConexion}&startDate=${encodeURIComponent(startDate)}&endDate=${encodeURIComponent(endDate)}`)
        ]);
        
        // Grupo Financial
        const [financialData, salesCategoryData, marginEarningsData, liquidezData] = await Promise.all([
            fetchData(`/Dashboard/profit-loss-byMonth/${year}?tipoConexion=${tipoConexion}`),
            fetchData(`/Dashboard/sales-by-category?tipoConexion=${tipoConexion}&startDate=${encodeURIComponent(startDate)}&endDate=${encodeURIComponent(endDate)}`),
            fetchData(`/Dashboard/margin-earnings?tipoConexion=${tipoConexion}&startDate=${encodeURIComponent(startDate)}&endDate=${encodeURIComponent(endDate)}`),
            fetchData(`/Dashboard/liquidity-ratio?tipoConexion=${tipoConexion}&startDate=${encodeURIComponent(startDate)}&endDate=${encodeURIComponent(endDate)}`)
        ]);

        // Actualizar la UI con los datos
        updateStats(
            ventasData, 
            acumuladoData, 
            ventasPreviousData, 
            acumuladoPreviousData, 
            porcentajeVentasActual, 
            porcentajeVentasPrevious, 
            utilidadesData, 
            utilidadesAcumuladasData, 
            porcentajeUtilidades, 
            marginEarningsData, 
            liquidezData
        ); 
        
        // Renderizar gráficos (se implementarán después)
        // renderFinancialChart(financialData);
        // renderSalesCategoryChart(salesCategoryData);
        
    } catch (error) {
        console.error('Error:', error);
        alert('Error al cargar los datos');
    }
}

async function fetchData(url) {
    try {
        const response = await api.get(url);
        return response.data;
    } catch (error) {
        console.error('Error fetching:', url, error);
        return null;
    }
}

// Inicialización
document.addEventListener('DOMContentLoaded', () => {
    setDefaultDates();
    loadData();
    document.getElementById('startDate').addEventListener('change', () => {
        updateCardYears();
        loadData();
    });
    document.getElementById('endDate').addEventListener('change', loadData);
});