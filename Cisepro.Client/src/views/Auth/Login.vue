<template>
    <div class="min-h-screen flex items-center justify-center bg-gray-50">
      <div class="w-full max-w-md p-8 space-y-8 bg-white rounded-lg shadow">
        <div class="text-center">
          <img src="../public/Cisepro_Wall.png" alt="Logo" class="mx-auto h-16 w-auto">
          <h2 class="mt-4 text-3xl font-bold text-gray-900">Iniciar Sesión</h2>
        </div>
  
        <!-- Selector de Base de Datos -->
        <div class="space-y-4">
          <h3 class="text-sm font-medium text-gray-700">Seleccione base de datos:</h3>
          <div class="flex justify-center space-x-6">
            <div 
              v-for="(db, index) in databases" 
              :key="index"
              @click="selectDatabase(index)"
              :class="[
                'cursor-pointer transition-all duration-300',
                'flex flex-col items-center',
                selectedDb === index 
                  ? 'ring-2 ring-blue-500 scale-105' 
                  : 'opacity-80 hover:opacity-100'
              ]"
            >
              <div class="h-16 w-16 rounded-full overflow-hidden border-2 border-gray-200">
                <img 
                  :src="db.image" 
                  :alt="db.name"
                  class="h-full w-full object-cover"
                >
              </div>
              <span class="mt-2 text-sm font-medium">{{ db.name }}</span>
            </div>
          </div>
        </div>
  
        <form @submit.prevent="handleLogin" class="space-y-6">
          <div>
            <label class="block text-sm font-medium text-gray-700">Usuario</label>
            <input
              v-model="username"
              type="text"
              placeholder="Ingrese su usuario"
              class="mt-1 block w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-blue-500 focus:border-blue-500 data-[error=true]:border-red-500 data-[success=true]:border-green-500 "
            >
            
          </div>
          <div>
            <label class="block text-sm font-medium text-gray-700">Contraseña</label>
            <input
              v-model="password"
              type="password"
              class="mt-1 block w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-blue-500 focus:border-blue-500"
            >
          </div>
          <button
            type="submit"
            class="w-full btn-primary"
          >
            Ingresar
          </button>
        </form>
      </div>
    </div>
  </template>
    
<script setup>
import {  ref } from 'vue'
import { useAuthStore } from 'stores/auth.store'
//import { initInputs} from '@material-tailwind/html'


const authStore = useAuthStore()
const username = ref('')
const password = ref('')


const handleLogin = () => {
  authStore.login(username.value, password.value)
}


</script>