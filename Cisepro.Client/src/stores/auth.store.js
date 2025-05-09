import { defineStore } from "pinia";
import axios from "axios";
import router from "../router";
import { ref } from "vue";

export const useAuthStore = defineStore('auth', () => {
    const user = ref(null)
    const token = ref(localStorage.getItem('token') || null)
    const returnUrl = ref(null)
    const selectedCompany = ref(localStorage.getItem('selectedCompany') || 'Cisepro');
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
        console.log(userData)
        console.log(selectedCompany.value)

        token.value = response.data.token
        user.value = userData
        
        // Guardar en localStorage
        localStorage.setItem('token', token.value)
        localStorage.setItem('user', JSON.stringify(user.value))
        
        
        // Redirigir
        router.push(returnUrl.value || '/dashboard')
      } catch (error) {
        throw new Error(error.response?.data?.message || 'Error de autenticación')
      }
    }
  
    const logout = () => {
      user.value = null
      token.value = null
      localStorage.removeItem('token')
      localStorage.removeItem('user')
      router.push('/')
    }
  
    // Verificar autenticación al cargar
    const initialize = () => {
      const storedUser = localStorage.getItem('user')
      if (storedUser) {
        user.value = JSON.parse(storedUser)
      }
      
    }
  
    return { user, token, returnUrl, selectedCompany, login, logout, initialize }
  })