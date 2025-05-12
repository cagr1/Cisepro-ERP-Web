import { createRouter, createWebHistory } from "vue-router";
import { useAuthStore } from "../stores/auth.store";
import { h } from "vue";

const routes = [
  {
    path: "/login",
    name: "Login",
    component: () => import("../views/Auth/Login.vue"),
    meta: { requiresAuth: false },
  },
  {
    path: "/",
    component: () => import("@/layouts/MainLayout.vue"),
    meta: { requiresAuth: true },
    children: [
      {
        path: "",
        redirect: "/dashboard",
      },
      {
        path: "/dashboard",
        name: "Dashboard",
        component: () => import("../views/Dashboard.vue"),
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
router.beforeEach((to, from, next) => {
  const authStore = useAuthStore();

  // Inicializar el store
  authStore.initialize();

  if (to.meta.requiresAuth && !authStore.token) {
    authStore.returnUrl = to.fullPath;
    next("/login");
  } else {
    next();
  }
});
export default router;
