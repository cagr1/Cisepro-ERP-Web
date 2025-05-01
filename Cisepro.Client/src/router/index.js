import { createRouter, createWebHistory } from "vue-router";    
import Login from "../views/Auth/Login.vue";


const routes = [
    {
        path: '/login',
        name: 'Login',
        component: Login,
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
    const isAuthenticated = localStorage.getItem('token') !== null; // Check if the user is authenticated

    if (to.path !== '/login' && !isAuthenticated) {
        // If the user is not authenticated and trying to access a protected route, redirect to login
        next({ path: '/login' });
    }
    else
    {
        next(); // Proceed to the route
    }
});
export default router