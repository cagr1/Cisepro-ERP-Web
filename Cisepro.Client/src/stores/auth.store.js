import { defineStore } from "pinia";
import axios from "axios";
import router from "../router";
import { ref } from "vue";

export const useAuthStore = defineStore('auth', () => {
    const user = ref(null);
    const token = ref(null);
    const returnUrl = ref(null);
    const selectedCompany = ref(localStorage.getItem('selectedCompany') || 'Cisepro');
    const isAuthenticated = ref(false);

    const login = async (credentials) => {
      try {
        const response = await axios.post('http://localhost:5206/api/Auth/Login', credentials)
        // Guardar token y usuario
        const userData = {          
          datos: response.data.usuario.datos,
          rol: response.data.usuario.rol
        }
        selectedCompany.value = credentials.TipoConexion;
        localStorage.setItem('selectedCompany', selectedCompany.value);
        
        token.value = response.data.token
        user.value = userData
        isAuthenticated.value = true;
        
        // Guardar en localStorage
        localStorage.setItem('token', token.value);
        localStorage.setItem('user', JSON.stringify(user.value));
        localStorage.setItem('isAuthenticated', 'true');
        
        
        // Redirigir
        router.push(returnUrl.value || '/dashboard')
      } catch (error) {
        isAuthenticated.value = false;
        throw new Error(error.response?.data?.message || 'Error de autenticación')
      }
    };
  
    const logout = () => {
      user.value = null;
      token.value = null;
      localStorage.removeItem('token');
      localStorage.removeItem('user');
      localStorage.removeItem('isAuthenticated');
      router.push('/login');
    };
  
    // Verificar autenticación al cargar
    const initialize = () => {
      const storedToken = localStorage.getItem('token')
      const storedUser = localStorage.getItem('user')
      const storedIsAuthenticated = localStorage.getItem('isAuthenticated')
      if (storedUser && storedToken && storedIsAuthenticated === 'true') {
        user.value = JSON.parse(storedUser)
        token.value = storedToken
        isAuthenticated.value = true;
      }
      else {
        clearAuthData();  
      }
    };
      
    const clearAuthData = () => {
      user.value = null;
      token.value = null;
      isAuthenticated.value = false;
      localStorage.removeItem('token');
      localStorage.removeItem('user');
      localStorage.removeItem('isAuthenticated');
    };
  
    return { 
      user, token, returnUrl, selectedCompany, isAuthenticated, login, logout, initialize 
    };
  });