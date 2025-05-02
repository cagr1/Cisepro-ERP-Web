<template>
  <div class="min-h-screen flex items-center justify-center bg-blue-600 p-4">
    <!-- Card Container -->
    <div class="w-full max-w-md bg-white rounded-lg shadow-md overflow-hidden">
     

      <!-- Card Content -->
      <div class="px-6 pb-6 pt-2">
        <div class="mb-4">
          <h4 class="text-xl font-semibold mb-1 text-gray-900">Bienvenido! 👋</h4>
          <p class="text-gray-600">Inicie sesión en su cuenta para comenzar</p>
        </div>
        <div class="mt-8">
        <RadioChoice 
          v-model="selectedCompany" 
          name="company"
          :options="companies"
          icon-border-color="border-gray-300"
        />
      </div>
        <form @submit.prevent="handleLogin">
          <!-- Email Input -->
          <div class="mb-6">
            <UiInput 
              v-model="form.email"
              label="Email"
              type="email"
              
            />
          </div>

          <!-- Password Input -->
          <div class="mb-6">
            <UiInput 
              v-model="form.password"
              label="Contraseña"
              type="password"
            />
          </div>

          <!-- Remember Me & Forgot Password -->
          <div class="flex items-center justify-between mb-6">
            <label class="flex items-center text-gray-600">
              <input 
                v-model="form.remember" 
                type="checkbox" 
                class="rounded border-gray-300 text-blue-600 shadow-sm focus:border-blue-300 focus:ring focus:ring-blue-200 focus:ring-opacity-50"
              >
              <span class="ml-2 text-sm">Recordar sesión</span>
            </label>
            
            <RouterLink 
              to="/forgot-password" 
              class="text-sm text-blue-600 hover:text-blue-800"
            >
              ¿Olvidó su contraseña?
            </RouterLink>
          </div>

          <!-- Login Button -->
          <button
            type="submit"
            class="w-full bg-blue-600 hover:bg-blue-700 text-white font-medium py-2 px-4 rounded-md shadow-md transition duration-200"
          >
            Iniciar Sesión
          </button>

          <!-- Divider -->
          <div class="flex items-center my-6">
            <div class="flex-grow border-t border-gray-300"></div>
            <span class="mx-4 text-gray-500 text-sm">o</span>
            <div class="flex-grow border-t border-gray-300"></div>
          </div>

          <!-- Social Auth -->
          <div class="grid grid-cols-2 gap-4">
            <button 
              type="button"
              class="flex items-center justify-center gap-2 bg-gray-100 hover:bg-gray-200 text-gray-800 py-2 px-4 rounded-md transition"
            >
              <i class="ri-google-fill text-red-500"></i>
              Google
            </button>
            <button 
              type="button"
              class="flex items-center justify-center gap-2 bg-gray-100 hover:bg-gray-200 text-gray-800 py-2 px-4 rounded-md transition"
            >
              <i class="ri-microsoft-fill text-blue-500"></i>
              Microsoft
            </button>
          </div>
        </form>
      </div>

      <!-- Card Footer -->
      <div class="bg-gray-50 px-6 py-4 text-center">
        <span class="text-gray-600 text-sm">¿No tiene una cuenta?</span>
        <RouterLink 
          to="/register" 
          class="text-blue-600 hover:text-blue-800 ml-2 text-sm font-medium"
        >
          Crear cuenta
        </RouterLink>
      </div>
    </div>
  </div>
</template>

<script setup>
import { ref } from 'vue'
import { RouterLink } from 'vue-router'
import UiInput from '@/components/Input.vue'
import RadioChoice from '@/components/RadioChoice.vue'

const selectedCompany = ref('cisepro')

const companies = ref([
  {
    value: 'cisepro',
    label: 'Cisepro',
    logo: '/src/assets/Images/cisepro.png',
    bgColor: '#0D47A1'
  },
  {
    
    value: 'seportpac',
    label: 'Seportpac',
    logo: '/src/assets/Images/seportpac.png',
    bgColor: '#404040'
  },
  
])

const form = ref({
  email: '',
  password: '',
  remember: false
})



const handleLogin = () => {
  console.log('Login attempt:', form.value)
}
</script>