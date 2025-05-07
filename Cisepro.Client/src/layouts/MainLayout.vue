<template>
    <div class="min-h-screen flex">
      <!-- Sidebar -->
      <aside 
        class="w-64 fixed left-0 top-0 h-screen bg-white shadow-xl transition-all duration-300 z-40
        border-r border-gray-200"
        :style="sidebarStyle"
      >
        <div class="h-full flex flex-col">
          <!-- Logo -->
          <div class="p-4 border-b border-gray-200">
            <div v-if="selectedCompany === 'Cisepro'" class="text-xl font-bold">
              <img src="../assets/images/cisepro.png" alt="Seportpac" class="h-10 w-auto">
            </div>
            <div v-else class="text-xl font-bold">
              <img src="../assets/images/seportpac.png" alt="Cisepro" class="h-10 w-auto">
            </div>
          </div>
  
          <!-- Menu Items -->
          <nav class="flex-1 overflow-y-auto px-2 py-4">
          <ul class="space-y-1">
            <li v-for="item in menuItems" :key="item.name">
              <template v-if="item.children">
                <button 
                  @click="toggleSubmenu(item)"
                  class="w-full flex items-center justify-between p-2 text-gray-700 hover:bg-gray-100 rounded-lg transition-colors"
                >
                  <div class="flex items-center">
                    <i :class="`${item.icon} text-gray-500 text-lg mr-3`"></i>
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
                        class="flex items-center p-2 text-gray-600 hover:bg-gray-100 rounded-lg text-sm"
                      >
                        <i :class="`${child.icon} text-gray-400 text-base mr-3`"></i>
                        {{ child.name }}
                      </RouterLink>
                    </li>
                  </ul>
                </transition>
              </template>
              <RouterLink
                v-else
                :to="item.path"
                class="flex items-center p-2 text-gray-700 hover:bg-gray-100 rounded-lg transition-colors"
              >
                <i :class="`${item.icon} text-gray-500 text-lg mr-3`"></i>
                <span class="text-sm font-medium">{{ item.name }}</span>
              </RouterLink>
            </li>
          </ul>
        </nav>
        </div>
      </aside>
  
      <!-- Main Content -->
      <div class="flex-1 ml-64">
        <!-- Navbar -->
        <header class="bg-white border-b border-gray-200">
        <div class="flex justify-between items-center px-6 py-4">
          <div></div>
          
          <!-- User Profile -->
          <div class="flex items-center gap-4">
            <div class="flex items-center gap-2">
              <img 
                :src="user.photo || 'https://via.placeholder.com/40'" 
                class="w-10 h-10 rounded-full object-cover"
                alt="User photo"
              >
              <div class="text-right">
                <p class="text-sm font-medium text-gray-700">{{ user.name }}</p>
                <p class="text-xs text-gray-500">{{ user.role }}</p>
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
        
      </div>
    </div>
  </template>
  
  <script setup>
  import { computed } from 'vue';
  import { useRouter } from 'vue-router';
  import { useAuthStore } from '@/stores/auth.store';
  
  const authStore = useAuthStore();
  const router = useRouter();
  
  //const openSubmenus = ref({});

  const props = defineProps({
    selectedCompany: {
      type: String,
      default: 'Cisepro'
    }
  });
  
  const menuItems = [
  
  { 
    name: 'Dashboard',
    path: '/dashboard',
    icon: 'ri-dashboard-line'
  },
  { 
    name: 'Administración',
    icon: 'ri-settings-5-line',
    children: [
      { name: 'Usuarios', path: '/admin/users', icon: 'ri-user-line' },
      { name: 'Roles', path: '/admin/roles', icon: 'ri-shield-keyhole-line' }
    ]
  },
  { 
    name: 'Contabilidad',
    icon: 'ri-calculator-line',
    children: [
      { name: 'Balance General', path: '/contabilidad/balance', icon: 'ri-line-chart-line' },
      { name: 'Estado de Resultados', path: '/contabilidad/resultados', icon: 'ri-bar-chart-2-line' }
    ]
  },
  // Agrega el resto de los items siguiendo el mismo formato
];

const toggleSubmenu = (item) => {
  openSubmenus.value[item.name] = !openSubmenus.value[item.name];
};
  
  const sidebarStyle = computed(() => {
    const colors = {
      Seportpac: '38, 50, 56', // RGB
      Cisepro: '13, 71, 161'
    };
    return {
      backgroundColor: `rgb(${colors[props.selectedCompany]})`,
      borderRight: `1px solid rgba(255, 255, 255, 0.1)`
    };
  });
  
  const user = computed(() => ({
    name: authStore.user?.name || 'Usuario',
    role: authStore.user?.role || 'Rol',
    photo: authStore.user?.photo
  }));
  
  const logout = () => {
    authStore.logout();
    router.push('/login');
  };
  </script>