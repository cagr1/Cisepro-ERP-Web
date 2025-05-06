<template>
    <div class="min-h-screen bg-gray-100">
      <header class="bg-white shadow">
        <div class="max-w-7xl mx-auto py-6 px-4 sm:px-6 lg:px-8">
          <h1 class="text-3xl font-bold text-gray-900">Dashboard</h1>
        </div>
      </header>
      <main>
        <div class="max-w-7xl mx-auto py-6 sm:px-6 lg:px-8">
          <div class="px-4 py-6 sm:px-0">
            <div class="border-4 border-dashed border-gray-200 rounded-lg p-6">
              <h2 class="text-xl font-semibold mb-4">Bienvenido, {{ user.nombre }}</h2>
              <p class="mb-4">Rol: {{ rolNombre }}</p>
              <button 
                @click="logout"
                class="px-4 py-2 bg-red-600 text-white rounded hover:bg-red-700"
              >
                Cerrar Sesión
              </button>
            </div>
          </div>
        </div>
      </main>
    </div>
  </template>
  
  <script setup>
  import { useAuthStore } from '@/stores/auth.store'
  import { computed } from 'vue'
  
  const authStore = useAuthStore()
  const user = computed(() => authStore.user)
  
  const rolNombre = computed(() => {
    switch(user.value?.rol) {
      case 1: return 'Administrador'
      case 2: return 'Usuario'
      default: return 'Invitado'
    }
  })
  
  const logout = () => {
    authStore.logout()
  }
  </script>

  