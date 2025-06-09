<template>
  <div class="min-h-screen flex">
    <!-- Sidebar -->
    <aside
      class="w-64 fixed left-0 top-0 h-screen shadow-xl transition-all duration-300 z-40 border-r"
      :class="{'ml-[-16rem]': !sidebarOpen}"
      :style="sidebarStyle"
    >
      <div class="h-full flex flex-col">
        <!-- Logo -->
        <div class="p-4 border-b border-gray-200 flex items-center gap-3">
          <div
            v-if="selectedCompany === 'Cisepro'"
            class="flex items-center gap-3"
          >
            <img
              src="../assets/images/cisepro.png"
              alt="Cispero"
              class="h-10 w-auto"
            />
            <span class="text-white font-semibold text-lg">CISEPRO</span>
          </div>
          <div v-else class="flex items-center gap-3">
            <img
              src="../assets/images/seportpac.png"
              alt="Seportpac"
              class="h-10 w-auto"
            />
            <span class="text-white font-semibold text-lg">SEPORTPAC</span>
          </div>
        </div>

        <!-- Menu Items -->
        <nav class="flex-1 overflow-y-auto px-2 py-4">
          <ul class="space-y-1">
            <li v-for="item in menuItems" :key="item.name">
              <template v-if="item.children">
                <button
                  @click="toggleSubmenu(item)"
                  class="w-full flex items-center justify-between p-2 text-white hover:bg-blue-600 rounded-lg transition-colors"
                >
                  <div class="flex items-center">
                    <i :class="`${item.icon} text-white text-lg mr-3`"></i>
                    <span class="text-sm font-medium">{{ item.name }}</span>
                  </div>
                  <i
                    :class="`ri-arrow-down-s-line transition-transform ${
                      openSubmenus[item.name] ? 'rotate-180' : ''
                    }`"
                  ></i>
                </button>
                <transition
                  enter-active-class="transition-all duration-300 ease-out"
                  leave-active-class="transition-all duration-300 ease-in"
                  enter-from-class="max-h-0 opacity-0"
                  enter-to-class="max-h-96 opacity-100"
                  leave-from-class="max-h-96 opacity-100"
                  leave-to-class="max-h-0 opacity-0"
                >
                  <ul v-show="openSubmenus[item.name]" class="ml-8 space-y-1">
                    <li v-for="child in item.children" :key="child.name">
                      <RouterLink
                        :to="child.path"
                        custom
                        v-slot="{ navigate, isActive }"
                      >
                        <!-- class="flex items-center p-2 text-white hover:bg-blue-500 rounded-lg text-sm" -->
                        <a
                          @click="navigate"
                          :href="child.path"
                          :class="[
                            'flex items-center p-2 text-white hover:bg-[var(--hover-color)] rounded-lg text-sm',
                            { 'bg-blue-600': isActive },
                          ]"
                        >
                          <i
                            :class="`${child.icon} text-white text-base mr-3`"
                          ></i>
                          {{ child.name }}
                        </a>
                      </RouterLink>
                    </li>
                  </ul>
                </transition>
              </template>
              <RouterLink
                v-else
                :to="item.path"
                class="flex items-center p-2 text-white hover:bg-[var(--hover-color)] rounded-lg transition-colors"
              >
                <i :class="`${item.icon} text-white text-lg mr-3`"></i>
                <span class="text-sm font-medium">{{ item.name }}</span>
              </RouterLink>
            </li>
          </ul>
        </nav>
      </div>
    </aside>

    <!-- Main Content -->
    <div class="flex-1 transition-all duration-300" :class="{'ml-0': !sidebarOpen, 'ml-64': sidebarOpen}">
      <!-- Navbar -->
      <header class="bg-white border-b border-gray-200">
        <div class="flex justify-between items-center px-6 py-3">
          
          <button 
            @click="toggleSidebar"
            class="p-2 rounded-full hover:bg-gray-100 text-gray-600 hover:text-gray-800 transition-colors"
          >
            <i :class="sidebarOpen ? 'ri-menu-fold-line' : 'ri-menu-unfold-line'" class="text-lg"></i>
          </button>
          <!-- User Profile -->
          <div class="flex items-center gap-4">
            <div class="flex items-center gap-2">
              <img
                :src="user.photo || 'https://via.placeholder.com/40'"
                class="w-10 h-10 rounded-full object-cover"
                alt="User photo"
              />
              <div class="text-right">
                <p class="text-sm font-medium text-gray-700">
                  {{ user.datos }}
                </p>
                <p class="text-xs text-gray-500">{{ rolNombre }}</p>
              </div>
            </div>
            <button
              @click="logout"
              class="p-2 hover:bg-gray-100 rounded-full text-gray-600 hover:text-red-600 transition-colors"
            >
              <i class="ri-logout-box-r-line text-lg"></i>
            </button>
          </div>
        </div>
      </header>

      <!-- Content -->
      <div class="p-6">
        <router-view />
      </div>
    </div>
  </div>
</template>

<script setup>
import { computed, ref } from "vue";
import { useRouter } from "vue-router";
import { useAuthStore } from "@/stores/auth.store";
import { storeToRefs } from "pinia";

const authStore = useAuthStore();
const router = useRouter();
const openSubmenus = ref({});
const sidebarOpen = ref(true);
const { selectedCompany } = storeToRefs(authStore);



const menuItems = [
  {
    name: "Dashboard",
    path: "/dashboard",
    icon: "ri-dashboard-line",
  },
  {
    name: "Administración",
    icon: "ri-settings-5-line",
    children: [
      { name: "Usuarios", path: "/admin/users", icon: "ri-user-line" },
      { name: "Roles", path: "/admin/roles", icon: "ri-shield-keyhole-line" },
    ],
  },
  {
    name: "Contabilidad",
    icon: "ri-calculator-line",
    children: [
      {
        name: "Balance General",
        path: "/contabilidad/balance",
        icon: "ri-line-chart-line",
      },
      {
        name: "Estado de Resultados",
        path: "/contabilidad/resultados",
        icon: "ri-bar-chart-2-line",
      },
    ],
  },
  {
    name: "RRHH",
    icon: "ri-group-line",
    children: [
      {
        name: "Personal",
        path: "/rrhh/personal",
        icon: "ri-user-3-line",
      },
    ],
  },
];

const toggleSidebar = () => {
  sidebarOpen.value = !sidebarOpen.value;
};

const toggleSubmenu = (item) => {
  openSubmenus.value[item.name] = !openSubmenus.value[item.name];
};

const sidebarStyle = computed(() => {
  const company = selectedCompany.value;
  const colors = {
    Seportpac: {
      background: "rgb(38, 50, 56)",
      hover: "rgba(255, 255, 255, 0.1)",
    },
    Cisepro: {
      background: "rgb(13, 71, 161)",
      hover: "rgba(255, 255, 255, 0.1)",
    },
  };

  return {
    backgroundColor: colors[company]?.background,
    "--hover-color": colors[company]?.hover,
  };
});

const user = computed(() => ({
  datos: authStore.user?.datos || "Usuario",
  rol: authStore.user?.rol || "Rol",
}));

const rolNombre = computed(() => {
  switch (user.value?.rol) {
    case 1:
      return "Administrador";
    case 2:
      return "Usuario";
    default:
      return "Invitado";
  }
});

const logout = () => {
  authStore.logout();
  router.push("/login");
};
</script>

<style scoped>
button.rounded-full {
  border-radius: 9999px;
  width: 2.5rem;
  height: 2.5rem;
  display: flex;
  align-items: center;
  justify-content: center;
}

/* Transición suave para el sidebar */
.aside {
  transition: transform 0.3s ease-in-out;
}

/* Estilos adicionales existentes */
.aside {
  background: linear-gradient(
    135deg,
    rgba(var(--sidebar-bg-rgb), 0.95) 0%,
    rgba(var(--sidebar-bg-rgb), 0.95) 100%
  );
  backdrop-filter: blur(10px);
  -webkit-backdrop-filter: blur(10px);
}

.slide-enter-active,
.slide-leave-active {
  transition: all 0.3s ease;
}

.slide-enter-from,
.slide-leave-to {
  transform: translateX(-20px);
  opacity: 0;
}
</style>
