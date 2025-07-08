import { createApp } from "vue";
import App from "./App.vue";
import router from "./router";
import { createPinia } from "pinia";
import { createNotivue } from "notivue";
import "remixicon/fonts/remixicon.css";
import "./styles/tailwind.css";
import 'notivue/animations.css';
import 'notivue/notification.css';

const notivue = createNotivue({
  position: "top-right",
  duration: 6000,
  important: true,
  closeButton: true,
  pauseOnHover: true,
  maxNotifications: 4,
   notifications: {
    global: { // Configuración global para todos los tipos
      duration: 5000,
      closeButton: true,
    },
    success: {
      duration: 3000,
      background: '#4CAF50', // Verde para éxito
      icon: 'ri-checkbox-circle-fill', // Icono de Remix Icons
    },
    error: {
      duration: 8000,
      background: '#F44336', // Rojo para errores
      icon: 'ri-error-warning-fill',
    },
    warning: {
      duration: 6000,
      background: '#FF9800', // Naranja para advertencias
      icon: 'ri-alert-fill',
    },
    info: {
      duration: 4000,
      background: '#2196F3', // Azul para información
      icon: 'ri-information-fill',
    }
  }

});

const app = createApp(App);
app.use(router);
app.use(createPinia());
app.use(notivue);
app.mount("#app");
