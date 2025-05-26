import axios from "axios";

const api = axios.create({
  baseURL: "http://localhost:5206/api",
  
});

//Interceptor para agregar el token de autenticación
api.interceptors.request.use(
  (config) => {
    const token = localStorage.getItem("token");
    if (token) {
      config.headers.Authorization = `Bearer ${token}`;
    }
    return config;
});

//Interceptor para manejar errores globales
api.interceptors.response.use(
  (response) => response,
  (error) => {
    if (error.response && error.response.status === 401) {
      // Aquí puedes manejar el error de autenticación, por ejemplo, redirigir al login
      window.location.href = "/login";
      console.error("Error de autenticación:", error);
    } else {
      console.error("Error en la solicitud:", error);
    }
    return Promise.reject(error);
  }
);

export default api;
