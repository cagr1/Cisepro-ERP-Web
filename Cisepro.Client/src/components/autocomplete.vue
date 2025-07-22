<template>
  <div class="relative w-full ">
    <label class="block text-xs font-medium text-gray-600 mb-1">
      {{ label }}
    </label>

    <!-- Input de búsqueda -->
    <input
      type="text"
      v-model="searchText"
      @input="handleInput"
      @focus="showDropdown = true"
      @blur="handleBlur"
      class="form-field max-w-[160px]"
      :placeholder="placeholder"
      :disabled="disabled"
    />

    <!-- Lista desplegable -->
    <ul
      v-show="showDropdown && filteredOptions.length > 0"
      class="absolute z-10 mt-1 w-full bg-white border border-gray-300 rounded-md shadow-lg max-h-[200px] overflow-y-auto"
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
      class="absolute z-10 mt-1 w-full bg-white border border-gray-300 rounded-md shadow-lg px-3 py-2 text-sm text-gray-500"
    >
      No se encontraron resultados
    </div>
  </div>
</template>

<script setup>
import { ref, computed, watch } from "vue";

const props = defineProps({
  modelValue: {
    type: [String, Number],
    default: "",
  },
  options: {
    type: Array,
    required: true,
    default: () => [],
  },
  label: {
    type: String,
    default: "",
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
    default: false
  },
});

const emit = defineEmits(["update:modelValue"]);

const searchText = ref("");
const showDropdown = ref(false);
const selectedOption = ref(null);

// Métodos para obtener label y value de forma genérica
const getOptionLabel = (option) => {
  if (typeof option === "object") {
    return option[props.optionLabel] || option.nombre || option.text || "";
  }
  return option;
};

const getOptionValue = (option) => {
  if (typeof option === "object") {
    return option[props.optionValue] || option.id || option.value || "";
  }
  return option;
};

const isOptionSelected = (option) => {
  return getOptionValue(option) === props.modelValue;
};


// Filtra las opciones basadas en la búsqueda
const filteredOptions = computed(() => {
  if (!searchText.value) return props.options;
  
  const searchTerm = searchText.value.toLowerCase();
  return props.options.filter(option => {
    const label = getOptionLabel(option).toString().toLowerCase();
    return label.includes(searchTerm);
  });
});


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
};




// Maneja el evento blur del input
const handleBlur = () => {
  setTimeout(() => {
    showDropdown.value = false;
    
    // Restaura el texto mostrado si no se seleccionó nada
    if (selectedOption.value) {
      const currentValue = getOptionValue(selectedOption.value);
      if (props.modelValue !== currentValue) {
        const foundOption = props.options.find(opt => 
          getOptionValue(opt) === props.modelValue
        );
        searchText.value = foundOption ? getOptionLabel(foundOption) : "";
      }
    } else if (props.modelValue) {
      const foundOption = props.options.find(opt => 
        getOptionValue(opt) === props.modelValue
      );
      searchText.value = foundOption ? getOptionLabel(foundOption) : "";
    } else {
      searchText.value = "";
    }
  }, 200);
};


// Sincroniza el valor inicial
watch(() => props.modelValue, (newVal) => {
  const foundOption = props.options.find(opt => 
    getOptionValue(opt) === newVal
  );
  if (foundOption) {
    selectedOption.value = foundOption;
    searchText.value = getOptionLabel(foundOption);
  } else {
    searchText.value = "";
    selectedOption.value = null;
  }
}, { immediate: true });

// Actualiza cuando cambian las opciones
watch(() => props.options, (newOptions) => {
  if (props.modelValue) {
    const foundOption = newOptions.find(opt => 
      getOptionValue(opt) === props.modelValue
    );
    if (foundOption) {
      searchText.value = getOptionLabel(foundOption);
    }
  }
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
