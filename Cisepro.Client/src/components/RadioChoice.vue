<template>
    <div class="grid grid-cols-2 gap-4 mt-5">
      <div 
        v-for="(option, index) in options"
        :key="index"
        class="flex flex-col items-center"
      >
        <label 
          class="choice cursor-pointer group"
          :class="{ 'active': modelValue === option.value }"
          @click="$emit('update:modelValue', option.value)"
        >
          <input 
            type="radio" 
            :name="name"
            :value="option.value"
            class="hidden"
            checked
          >
          <div 
            class="icon rounded-full border-2 flex items-center justify-center transition-all duration-300"
            :class="[
            modelValue === option.value 
              ? 'border-blue-600 ring-2 ring-blue-400' 
              : 'border-gray-300 opacity-80 hover:opacity-100',
            iconBorderColor
          ]"
            :style="{ backgroundColor: option.color || 'transparent' }"
          >
            <img
              :src="option.logo"
              alt="'Logo ' + option.label"
              class="w-full h-full object-contain p-3 transition-all duration-300"
              :class="{
              'brightness-100 saturate-100': modelValue === option.value,
              'brightness-90 saturate-0': modelValue !== option.value
            }"
            >
          </div>
          <h6 class="text-center mt-3 font-medium transition-colors duration-300"
          :class="{
            'text-blue-600 font-semibold': modelValue === option.value,
            'text-gray-500': modelValue !== option.value
          }">
          {{ option.label }}
        </h6>
        </label>
      </div>
    </div>
  </template>
  
  <script setup>
  defineProps({
    modelValue: {
      type: String,
      required: true
    },
    name: {
      type: String,
      required: true
    },
    options: {
      type: Array,
      required: true,
      validator: (options) => {
        return options.every(opt => 
          'value' in opt && 
          'label' in opt && 
          'logo' in opt
          
        )
      }
    },
    iconBorderColor: {
      type: String,
      default: 'border-gray-300'
    }
  })
  
  defineEmits(['update:modelValue'])
  </script>
  
  <style scoped>
  .choice .icon {
    width: 116px;
    height: 116px;
    transition: all 0.2s ease;
    box-shadow: 0 2px 6px rgba(0,0,0,0.1);
  }
   
  
  .choice.active .icon {
    box-shadow: 0 4px 8px rgba(0,0,0,0.15);
    transform: scale(1.05);
  }

  .choice:not(.active):hover .icon {
  opacity: 0.9;
  box-shadow: 0 3px 8px rgba(0, 0, 0, 0.12);
}
  </style>