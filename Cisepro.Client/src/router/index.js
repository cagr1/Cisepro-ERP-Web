import { createRouter, createWebHistory } from "vue-router";    
import Login from "../views/Auth/Login.vue";
import { useAuthStore } from "../stores/auth.store";

const routes = [
    {
        path: '/login',
        name: 'Login',
        component: () => import('../views/Auth/Login.vue'),
        meta: {
            requiresAuth: false
        }
    }
    ];

    const router = createRouter({
        history: createWebHistory(),
        routes
    });
router.beforeEach((to, from, next) => {
    const authStore = useAuthStore()
  
  // Inicializar el store
  authStore.initialize()
  
  if (to.meta.requiresAuth && !authStore.token) {
    authStore.returnUrl = to.fullPath
    next('/login')
  } else {
    next()
  }
});
export default router