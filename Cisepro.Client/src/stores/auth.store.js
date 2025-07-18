import { defineStore } from "pinia";
import api from "@/api/index.js";
import { useRouter } from 'vue-router';
import { ref } from "vue";
import  {jwtDecode}  from 'jwt-decode';


export const useAuthStore = defineStore('auth', () => {
    
    const router = useRouter();
    const user = ref(null);
    const token = ref(null);
    const returnUrl = ref(null);
    const selectedCompany = ref(localStorage.getItem('selectedCompany') || 'Cisepro');
    const isAuthenticated = ref(false);

    const login = async (credentials) => {
      try {
        const response = await api.post('/Auth/Login', credentials);
        // Guardar token y usuario
        const userData = {          
          datos: response.data.usuario.datos,
          rol: response.data.usuario.rol
        };
        selectedCompany.value = credentials.tipoConexion;              
        token.value = response.data.token;
        user.value = userData;
        isAuthenticated.value = true;
        
        // Guardar en localStorage
        localStorage.setItem('token', token.value);
        localStorage.setItem('user', JSON.stringify(user.value));
        
        localStorage.setItem('selectedCompany', selectedCompany.value);
        
        // Redirigir
        
        router.push(returnUrl.value || '/')
        
      } catch (error) {
        
        throw new Error(error.response?.data?.message || 'Error de autenticación')
      }
    };

    const validateToken = async () => {
      if(!token.value)  return false;
      try {
        const decoded = jwtDecode(token.value);
        const now = Date.now() / 1000;
        if (decoded.exp < now) {
          throw new Error('Token expirado');          
        }

        await api.get('/Auth/ValidateToken');

        return true;
    }
      catch (error) {
      logout();
        return false;
      }
    };

     const initialize = async () => {
      const storedToken = localStorage.getItem('token')
      const storedUser = localStorage.getItem('user')
      
      if (storedUser && storedToken ) {
      
        user.value = JSON.parse(storedUser)
        token.value = storedToken
        
        try {
          const decoded = jwtDecode(token.value);
          isAuthenticated.value = decoded.exp > Date.now() / 1000;
        } catch (error) {
         logout();
        }       
      }    
    };
  
    const logout = () => {
      user.value = null;
      token.value = null;
      isAuthenticated.value = false;
      selectedCompany.value = null;
      localStorage.removeItem('token');
      localStorage.removeItem('user');
      localStorage.removeItem('isAuthenticated');
      localStorage.removeItem('selectedCompany');
      localStorage.removeItem('rememberedUsername');
      localStorage.removeItem('rememberedPassword');

      
      router.push('/login');
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
      user,
      token,
      returnUrl,
      selectedCompany,
      isAuthenticated,
      login,
      logout,
      initialize,
      validateToken,
      clearAuthData 
    };
  });