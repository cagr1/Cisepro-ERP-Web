import { defineStore } from "pinia";
import axios from "axios";
import router from "../router";
import { ref } from "vue";

export const useAuthStore = defineStore('auth', () => {
    const user = ref(null)
    const token = ref(localStorage.getItem('token') || null)
    const returnUrl = ref(null)
  
    const login = async (credentials) => {
      try {
        const response = await axios.post('http://localhost:5000/api/auth/login', credentials)
        
        // Guardar token y usuario
        token.value = response.data.token
        user.value = response.data.usuario
        
        // Guardar en localStorage
        localStorage.setItem('token', token.value)
        localStorage.setItem('user', JSON.stringify(user.value))
        
        // Redirigir
        router.push(returnUrl.value || '/dashboard')
      } catch (error) {
        console.error('Error de autenticación:', error)
        throw error
      }
    }
  
    const logout = () => {
      user.value = null
      token.value = null
      localStorage.removeItem('token')
      localStorage.removeItem('user')
      router.push('/login')
    }
  
    // Verificar autenticación al cargar
    const initialize = () => {
      const storedUser = localStorage.getItem('user')
      if (storedUser) {
        user.value = JSON.parse(storedUser)
      }
    }
  
    return { user, token, returnUrl, login, logout, initialize }
  })