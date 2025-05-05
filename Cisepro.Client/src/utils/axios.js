import axios from 'axios';
import { useAuthStore } from '../stores/auth.store';

const api = axios.create({
    baseURL: 'http://localhost:5000/api',
    timeout: 10000,
});

api.interceptors.request.use(config => {
    const authStore = useAuthStore()
    if (authStore.token) {
      config.headers.Authorization = `Bearer ${authStore.token}`
    }
    return config
  }, error => {
    return Promise.reject(error)
  })
  
  api.interceptors.response.use(response => response, error => {
    if (error.response?.status === 401) {
      const authStore = useAuthStore()
      authStore.logout()
    }
    return Promise.reject(error)
  })
  
  export default api