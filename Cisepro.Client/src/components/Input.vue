<template>
   <div class="relative mt-6">
    <!-- Input principal -->
    <input
      :type="showPassword ? 'text' : type"
      :value="modelValue"
      @input="$emit('update:modelValue', $event.target.value)"  
      ref="input"
      class="peer block w-full pl-4 pr-10 py-3 bg-gray-50 border border-gray-300/80 rounded-lg focus:outline-none focus:ring-1 focus:ring-blue-500"
      placeholder=" "
    />
    
    <!-- Label flotante -->
    <label 
      v-if="label"
      class="absolute left-3 top-2.5 px-1 text-gray-600 transition-all duration-200 transform
             peer-focus:-top-2 peer-focus:text-xs peer-focus:text-blue-600 peer-focus:bg-white
             peer-placeholder-shown:top-3 peer-placeholder-shown:text-base
             peer-[&:not(:placeholder-shown)]:-top-2 peer-[&:not(:placeholder-shown)]:text-xs
           peer-[&:not(:placeholder-shown)]:text-blue-600 peer-[&:not(:placeholder-shown)]:bg-white"
    >
      {{ label }}
    </label>
    
    <!-- Icono de ojo solo para contraseña -->
    <button
      v-if="type === 'password'"
      type="button"
      class="absolute right-3 top-1/2 transform -translate-y-1/2 text-gray-400 hover:text-gray-600 focus:outline-none"
      @click="togglePasswordVisibility"
    >
      <i :class="showPassword ? 'ri-eye-off-line' : 'ri-eye-line'" class="text-lg"></i>
    </button>
  </div>
  </template>



<script setup>
import { ref} from 'vue'

const props = defineProps({
  modelValue: {
    type: String,
    default: ''
    },
  label: {
    type: String,
    default: ''
  },
  type: {
    type: String,
    default: 'text'
  },
 
})

const emit = defineEmits(['update:modelValue'])

const showPassword = ref(false)
const input = ref(null)
const togglePasswordVisibility = async () => {
  showPassword.value = !showPassword.value
  input.value?.focus()

}
</script>
