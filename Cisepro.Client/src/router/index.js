import { createRouter, createWebHistory } from "vue-router";
import { useAuthStore } from "../stores/auth.store";


const routes = [
  {
    path: "/login",
    name: "Login",
    component: () => import("../views/Auth/Login.vue"),
    meta: { requiresAuth: false, isLoginPage: true },
  },
  {
    path: "/",
    component: () => import("@/layouts/MainLayout.vue"),
    meta: { requiresAuth: true },
    children: [
      {
        path: "",
        redirect: "/Dashboard/partida",
      },
      {
        path: "/dashboard",
        name: "Dashboard",
        redirect: "/dashboard/partida",
        component: () => import("../views/DashboardContainer.vue"),
        children: [
          {
            path: "partida",
            name: "FinancieroPartida",
            component: () => import("../views/Dashboard/Partida.vue"),
          },
          {
            path: "ciclo-efectivo",
            name: "FinancieroCicloEfectivo",
            component: () => import("../views/Dashboard/CicloEfectivo.vue"),
          },
          {
            path: "analisis",
            name: "FinancieroAnalisis",
            component: () => import("../views/Dashboard/Analisis.vue"),
          },
        ]

      },
      
      {
        path: "administration",
        name: "Administración",
        component: () =>
          import("../views/Administracion/EstructuraAdministrativa.vue"),
      },
      {
        path: "/contabilidad",
        name: "Contabilidad",
        component: () => import("../views/Contabilidad/LibroDiario.vue"),
      },
      {
        path: "rrhh/personal",
        name: "Personal",
        component: () => import("../views/rrhh/Personal.vue"),
      },
    ],
  },
 
  {
    path: "/:pathMatch(.*)*",
    redirect: "/dashboard",
  },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

const secureNavigation = async (to, from, next) => {
  const authStore = useAuthStore();
  
  authStore.initialize();

  await authStore.initialize();

  if (to.meta.isLoginPage && authStore.isAuthenticated) {
    next("/dashboard");
    return;
  }

  if (to.meta.requiresAuth) {
    if (!authStore.isAuthenticated) {
      authStore.returnUrl = to.fullPath;
       next("/login");
    }
   
    if (to.meta.requiresTokenValidation) {
      try {
        await authStore.validateToken();
      } catch (error) {
        authStore.clearAuthData();
        next("/login");
      }
    }


    // try {
    //   await authStore.validateToken();
    //   return next();
    // } catch (error) {
    //   authStore.clearAuthData();
    //   return next("/login");
    // }
  }
next();
}


router.beforeEach((to, from, next) => {
    secureNavigation(to, from, next).catch(() => {
    next("/login");
  });
  
    
  
});
export default router;
