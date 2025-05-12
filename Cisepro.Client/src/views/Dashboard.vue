<template>
  
    <div class="bg-white rounded-lg shadow p-6">
      
    </div>
    
  
    
   
  </template>
  
  <script setup>
  import { useAuthStore } from '@/stores/auth.store'
  import { computed } from 'vue'
  
  
  const authStore = useAuthStore()
  
  const selectedCompany = computed(() => authStore.selectedCompany || 'Cisepro')
  
  
  const logout = () => {
    authStore.logout()
  }
  </script>

  