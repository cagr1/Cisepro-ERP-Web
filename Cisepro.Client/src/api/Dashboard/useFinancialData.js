import { ref, computed } from "vue";
import api from "@/api";
import { formatDateWithTime } from "@/utils/dateUtils";
import { useAuthStore } from "@/stores/auth.store";


export const useFinancialData = () => {
  
  const authStore = useAuthStore();
  const tipoConexion = authStore.selectedCompany;
  
  const tablaPrimaria = ref([]);
  const isLoading = ref(false);
  const error = ref(null);

  const fetchTablaFinanciera = async (startDateInput, endDateInput) => {
    try {
      const startDate = formatDateWithTime(startDateInput);
      const endDate = formatDateWithTime(endDateInput, true);

      const params = {
        tipoConexion,
        startDate,
        endDate,
      };

      const response = await api.get("/Dashboard/financial-table", {
        params,
        paramsSerializer: { indexes: null },
      });

      return response.data;
    } catch (err) {
      console.error("Error al obtener tabla financiera:", err);
      throw err;
    }
  };

  return {
    isLoading,
    error,
    tablaPrimaria,
    fetchTablaFinanciera
  };
};