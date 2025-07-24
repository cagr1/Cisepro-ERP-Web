<template>
  <div class="relative w-full " ref="container">
    <label class="block text-xs font-medium text-gray-600 mb-1">
      {{ label }}
    </label>

    <!-- Input de búsqueda -->
    <input
      type="text"
      v-model="searchText"
      @input="handleInput"
      @focus="openDropdown"
      @blur="handleBlur"
      class="form-field max-w-[160px]"
      :placeholder="placeholder"
      :disabled="disabled"
    />

    <!-- Lista desplegable -->
    <ul
      v-show="showDropdown && filteredOptions.length > 0"
      class="absolute z-50 w-full bg-white border border-gray-300 rounded-md shadow-lg overflow-y-auto"
      :class="{
        'mt-1 bottom-full': shouldOpenUpward,
        'mt-1': !shouldOpenUpward
      }"
      :style="{
        'max-height': maxHeight,
        'min-width': '200px'
      }"
      ref="dropdown"
    >
      <li
        v-for="option in filteredOptions"
        :key="getOptionValue(option)"
        @mousedown="selectOption(option)"
        class="px-3 py-2 text-sm cursor-pointer hover:bg-gray-100 whitespace-nowrap"
        :class="{ 'bg-gray-100': isOptionSelected(option) }"
      >
        {{ getOptionLabel(option) }}
      </li>
    </ul>

    <!-- Mensaje cuando no hay resultados -->
    <div
      v-if="showDropdown && filteredOptions.length === 0"
       class="absolute z-50 w-full bg-white border border-gray-300 rounded-md shadow-lg px-3 py-2 text-sm text-gray-500"
      :class="{
        'mt-1 bottom-full': shouldOpenUpward,
        'mt-1': !shouldOpenUpward
      }"
      :style="{ 'min-width': '200px' }"
    >
      No se encontraron resultados
    </div>
  </div>
</template>

<script setup>
import { ref, computed, watch, onMounted, nextTick } from "vue";

const props = defineProps({
  modelValue: {
    type: [String, Number],    
  },
  options: {
    type: Array,
    required: true,
    default: () => [],
  },
  label: {
    type: String,    
  },
  placeholder: {
    type: String,
    default: "Buscar...",
  },
  optionLabel: {
    type: String,
    default: "text",
  },
  optionValue: {
    type: String,
    default: "value",
  },
  disabled: {
    type: Boolean,    
  },
  maxHeight: {
    type: String,
    default: "300px",
  },  
});

const emit = defineEmits(["update:modelValue"]);

const searchText = ref("");
const showDropdown = ref(false);
const selectedOption = ref(null);
const shouldOpenUpward = ref(false);
const container = ref(null);
const dropdown = ref(null);
// Métodos para obtener label y value de forma genérica
const getOptionLabel = (option) => option?.[props.optionLabel] || option?.nombre || option?.text || "";

const getOptionValue = (option) => option?.[props.optionValue] || option?.id || option?.value || "";

const isOptionSelected = (option) => getOptionValue(option) === props.modelValue;


// Filtra las opciones basadas en la búsqueda
const filteredOptions = computed(() => {
  if (!searchText.value) return props.options;
  
  const searchTerm = searchText.value.toLowerCase();
  return props.options.filter(option => getOptionLabel(option).toString().toLowerCase().includes(searchTerm));
    });

// Calcula la posición del dropdown
const calculateDropdownPosition = async () => {
  await nextTick();
  if (!container.value || !dropdown.value) return;
  
  const containerRect = container.value.getBoundingClientRect();
  const dropdownHeight = Math.min(
    dropdown.value.scrollHeight,
    parseInt(props.maxHeight)
  );
  
  // Calcula espacio considerando scroll
  const spaceBelow = window.innerHeight - containerRect.bottom - window.scrollY;
  const spaceAbove = containerRect.top + window.scrollY;
  
  shouldOpenUpward.value = spaceBelow < dropdownHeight && spaceAbove >= dropdownHeight;
  
  // Ajusta altura máxima real
  if (shouldOpenUpward.value) {
    dropdown.value.style.maxHeight = `${Math.min(dropdownHeight, spaceAbove - 10)}px`;
  } else {
    dropdown.value.style.maxHeight = `${Math.min(dropdownHeight, spaceBelow - 10)}px`;
  }
};

// Añade listener para scroll y resize
onMounted(() => {
  window.addEventListener('scroll', calculateDropdownPosition);
  window.addEventListener('resize', calculateDropdownPosition);
});

// Limpia listeners
onBeforeUnmount(() => {
  window.removeEventListener('scroll', calculateDropdownPosition);
  window.removeEventListener('resize', calculateDropdownPosition);
});

const openDropdown = () => {
  showDropdown.value = true;
  calculateDropdownPosition();
};



// Verifica si una opción está seleccionada
const selectOption = (option) => {
  selectedOption.value = option;
  searchText.value = getOptionLabel(option);
  emit("update:modelValue", getOptionValue(option));
  showDropdown.value = false;
};

// Maneja el input del usuario
const handleInput = () => {
  showDropdown.value = true;
  calculateDropdownPosition();
};




// Maneja el evento blur del input
const handleBlur = () => {
  setTimeout(() => {
    showDropdown.value = false;
    if (selectedOption.value && props.modelValue !== getOptionValue(selectedOption.value)) {
      const foundOption = props.options.find(opt => 
        getOptionValue(opt) === props.modelValue
      );
      searchText.value = foundOption ? getOptionLabel(foundOption) : "";
    }
  }, 200);
};


// Sincroniza el valor inicial
watch(() => props.modelValue, (newVal) => {
  const foundOption = props.options.find(opt => 
    getOptionValue(opt) === newVal
  );
   searchText.value = foundOption ? getOptionLabel(foundOption) : "";
}, { immediate: true });

// Actualiza cuando cambian las opciones
// Recalcular posición cuando cambian las opciones
watch(() => props.options, () => {
  if (showDropdown.value) calculateDropdownPosition();
});

</script>

<style>
.form-field {
  @apply w-full px-3 py-2 text-sm border border-gray-300 rounded-md focus:outline-none focus:ring-1 focus:ring-blue-500;
}

/* Transición suave para el dropdown */
ul {
  transition: all 0.2s ease;
}

</style>
