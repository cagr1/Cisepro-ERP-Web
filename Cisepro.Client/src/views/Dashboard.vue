<template>
  <main-layout :selectedCompany="selectedCompany">
    <div class="bg-white rounded-lg shadow p-6">
      
    </div>
    
  </main-layout>
    
   
  </template>
  
  <script setup>
  import { useAuthStore } from '@/stores/auth.store'
  import { computed } from 'vue'
  import MainLayout from '../layouts/MainLayout.vue'
  
  const authStore = useAuthStore()
  
  const selectedCompany = computed(() => authStore.selectedCompany || 'Cisepro')
  
  
  const logout = () => {
    authStore.logout()
  }
  </script>

  