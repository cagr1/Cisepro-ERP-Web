<template>
  <div class="min-h-screen flex">
    <!-- Sidebar -->
    <aside
      class="fixed left-0 top-0 h-screen shadow-2xl transition-all duration-300 z-40 border-r border-gray-200/20"
      :class="sidebarOpen ? 'w-64' : 'w-16'"
      :style="sidebarStyle"
    >
      <div class="h-full flex flex-col">
        <!-- Logo -->
        <div class="p-4 border-b border-white/10 flex items-center justify-center relative  min-h-[72px]">
           <!-- Logo expandido -->
          <div v-if="sidebarOpen" class="flex items-center gap-3 transition-all duration-300 opacity-100">
            <div v-if="selectedCompany === 'Cisepro'" class="flex items-center gap-3">
              <img
                src="../assets/images/cisepro.png"
                alt="Cisepro"
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
          
          <!-- Logo minimizado -->
          <div v-else class="flex items-center w-full transition-all  duration-300 opacity-100">
            <img
              :src="selectedCompany === 'Cisepro' ? ciseproLogo : seportpacLogo "
              
              class="h-7 w-auto flex-shrink-0"
            />
          </div>
        </div>

        <!-- Menu Items -->
        <nav class="flex-1 overflow-y-auto px-2 py-4">
          <ul class="space-y-1">
            <li v-for="item in menuItems" :key="item.name">
              <!-- Items con submenú -->
              <template v-if="item.children">
                <div class="relative group">
                  <button
                    @click="toggleSubmenu(item)"
                    @mouseenter="!sidebarOpen ? showTooltip(item.name, $event) : null"
                    @mouseleave="!sidebarOpen ? hideTooltip() : null"
                    :class="[
                      'w-full flex items-center p-2 text-white hover:bg-white/10 rounded-xl transition-all duration-200',
                      sidebarOpen ? 'justify-between' : 'justify-center'
                    ]"
                  >
                    <div class="flex items-center">
                      <Icon :icon="item.icon" class="text-white/90 hover:text-white text-xl" :style="{minWidth: '20px'}"/>
                      <span 
                        v-if="sidebarOpen" 
                        class="text-sm font-medium ml-3 transition-opacity duration-300"
                      >
                        {{ item.name }}
                      </span>
                    </div>
                    <Icon
                      v-if="sidebarOpen"
                      icon="ri:arrow-down-s-line"
                      class="transition-transform duration-200"
                      :class="{'rotate-180': openSubmenus[item.name]}"
                      
                    />
                  </button>
                  
                  <!-- Submenu expandido -->
                  <transition
                    enter-active-class="transition-all duration-300 ease-out"
                    leave-active-class="transition-all duration-300 ease-in"
                    enter-from-class="max-h-0 opacity-0"
                    enter-to-class="max-h-96 opacity-100"
                    leave-from-class="max-h-96 opacity-100"
                    leave-to-class="max-h-0 opacity-0"
                  >
                    <ul v-show="openSubmenus[item.name] && sidebarOpen" class="ml-8 space-y-1 overflow-hidden">
                      <li v-for="child in item.children" :key="child.name">
                        <RouterLink
                          :to="child.path"
                          custom
                          v-slot="{ navigate, isActive }"
                        >
                          <a
                            @click="navigate"
                            :href="child.path"
                            :class="[
                              'flex items-center p-2 text-white/80 hover:text-white hover:bg-white/10 rounded-lg text-sm transition-all duration-200',
                              { 'bg-white/20 text-white': isActive },
                            ]"
                          >
                            <Icon :icon="child.icon" class="text-base mr-3" style="min-width: 16px;"/>
                            
                            {{ child.name }}
                          </a>
                        </RouterLink>
                      </li>
                    </ul>
                  </transition>
                </div>
              </template>
              
              <!-- Items simples -->
              <div v-else class="relative group">
                <RouterLink
                  :to="item.path"
                  custom
                  v-slot="{ navigate, isActive }"
                >
                  <a
                    @click="navigate"
                    @mouseenter="!sidebarOpen ? showTooltip(item.name, $event) : null"
                    @mouseleave="!sidebarOpen ? hideTooltip() : null"
                    :href="item.path"
                    :class="[
                      'flex items-center p-3 text-white hover:bg-white/10 rounded-xl transition-all duration-200',
                      sidebarOpen ? 'justify-start' : 'justify-center',
                      { 'bg-white/20': isActive }
                    ]"
                  >
                    <Icon :icon="item.icon" class="text-xl "  style="min-Width: 20px;"/>
                    <span 
                      v-if="sidebarOpen" 
                      class="text-sm font-medium ml-3 transition-opacity duration-300"
                    >
                      {{ item.name }}
                    </span>
                  </a>
                </RouterLink>
              </div>
            </li>
          </ul>
        </nav>
      </div>
    </aside>

    <!-- Toggle Button -->
    <button 
      @click="toggleSidebar"
      :class="[
        'fixed top-6 z-50 w-5 h-5 bg-white border border-gray-200 rounded-full shadow-lg hover:shadow-xl transition-all duration-300 flex items-center justify-center text-gray-600 hover:text-gray-800 hover:scale-105',
  ]" :style="{left: sidebarOpen ? '15.35rem' : '3.35rem'}"
  
    >
      <svg 
        :class="['w-4 h-4 transition-transform duration-300', sidebarOpen ? 'rotate-180' : '']" 
        fill="none" 
        stroke="currentColor" 
        viewBox="0 0 24 24"
      >
        <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 5l7 7-7 7" />
      </svg>
    </button>

    <!-- Main Content -->
    <div 
      class="flex-1 transition-all duration-300" 
      :class="sidebarOpen ? 'ml-64' : 'ml-16'"
    >
      <!-- Navbar -->
      <header class="bg-white border-b border-gray-200 shadow-sm">
        <div class="flex justify-end items-center px-6 py-3">
          <!-- User Profile -->
          <div class="flex items-center gap-4">
            <div class="flex items-center gap-3">
              <img
                :src="user.photo || 'https://img.icons8.com/?size=100&id=23265&format=png&color=000000'"
                class="w-10 h-10 rounded-full object-cover shadow-md"
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
              class="p-2 hover:bg-red-50 rounded-full text-gray-600 hover:text-red-600 transition-all duration-200 shadow-sm hover:shadow-md"
            >
              <i class="ri-logout-box-r-line text-lg"></i>
            </button>
          </div>
        </div>
      </header>

      <!-- Content -->
      <div class="p-1">
        <router-view />
      </div>
    </div>

    <!-- Tooltip -->
    <div
      v-if="tooltip.show && !sidebarOpen"
      :style="{ top: tooltip.y + 'px', left: tooltip.x + 'px' }"
      class="fixed z-50 px-3 py-2 bg-gray-600 text-white text-sm rounded-lg shadow-xl pointer-events-none transform transition-opacity duration-200"
    >
      {{ tooltip.text }}
      <div class="absolute left-0 top-1/2 transform -translate-y-1/2 -translate-x-1 w-0 h-0 border-t-4 border-b-4 border-r-4 border-transparent border-r-gray-900"></div>
    </div>
  </div>
</template>

<script setup>
import { computed, ref, reactive } from "vue";
import { useRouter } from "vue-router";
import { useAuthStore } from "@/stores/auth.store";
import { storeToRefs } from "pinia";
import { Icon } from "@iconify/vue";
import ciseproLogo from "@/assets/images/cisepro.png";
import seportpacLogo from "@/assets/images/seportpac.png";

const authStore = useAuthStore();
const router = useRouter();
const openSubmenus = ref({});
const sidebarOpen = ref(false); // Iniciamos minimizado
const { selectedCompany } = storeToRefs(authStore);

// Tooltip state
const tooltip = reactive({
  show: false,
  text: '',
  x: 0,
  y: 0
});

const menuItems = [
  {
    name: "Dashboard",
    path: "/dashboard",
    icon: "ri:dashboard-fill",
  },
  {
    name: "Administración",
    icon: "heroicons:users",
    children: [
      { name: "Usuarios", path: "/admin/users", icon: "ri-user-line" },
      { name: "Roles", path: "/admin/roles", icon: "ri-shield-keyhole-line" },
    ],
  },
  {
    name: "Contabilidad",
    icon: "heroicons:scale",
    children: [
      {
        name: "Balance General",
        path: "/contabilidad/balance",
        icon: "heroicons:presentation-chart-line",
      },
      {
        name: "Estado de Resultados",
        path: "/contabilidad/resultados",
        icon: "heroicons:chart-bar",
      },
    ],
  },
  {
    name: "RRHH",
    icon: "heroicons:user-group",
    children: [
      {
        name: "Personal",
        path: "/rrhh/personal",
        icon: "heroicons:users",
      },
    ],
  },
];

const toggleSidebar = () => {
  sidebarOpen.value = !sidebarOpen.value;
  // Cerrar submenus cuando se minimiza
  if (!sidebarOpen.value) {
    openSubmenus.value = {};
    hideTooltip();
  }
};

const toggleSubmenu = (item) => {
  if (!sidebarOpen.value) {
    sidebarOpen.value = true; // Abrir sidebar si está cerrado

    setTimeout(() => {
      openSubmenus.value[item.name] = true;
    }, 300);
  } else
  {
    openSubmenus.value[item.name] = !openSubmenus.value[item.name];
  }
  
};

const showTooltip = (text, event) => {
  if (sidebarOpen.value) return;
  
  const rect = event.currentTarget.getBoundingClientRect();
  tooltip.text = text;
  tooltip.x = rect.right + 10;
  tooltip.y = rect.top;
  tooltip.show = true;
};

const hideTooltip = () => {
  tooltip.show = false;
};

const sidebarStyle = computed(() => {
  const company = selectedCompany.value;
  const colors = {
    Seportpac: {
      background: "linear-gradient(135deg, rgb(38, 50, 56) 0%, rgb(55, 71, 79) 100%)",
    },
    Cisepro: {
      background: "linear-gradient(135deg, rgb(13, 71, 161) 0%, rgb(25, 118, 210) 100%)",
    },
  };

  return {
    background: colors[company]?.background || colors.Cisepro.background,
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
/* Scrollbar personalizado para el sidebar */
nav::-webkit-scrollbar {
  width: 4px;
}

nav::-webkit-scrollbar-track {
  background: transparent;
}

nav::-webkit-scrollbar-thumb {
  background: rgba(255, 255, 255, 0.2);
  border-radius: 2px;
}

nav::-webkit-scrollbar-thumb:hover {
  background: rgba(255, 255, 255, 0.3);
}

/* Mejoras en las transiciones */
.transition-all {
  transition: all 0.3s cubic-bezier(0.4, 0, 0.2, 1);
}

/* Efecto glassmorphism sutil */
aside {
  backdrop-filter: blur(10px);
  -webkit-backdrop-filter: blur(10px);
}
</style>