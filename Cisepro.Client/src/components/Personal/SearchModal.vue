<template>
  <Transition name="modal-fade">
    <div v-if="show" class="modal-mask" @click.self="$emit('close')">
      <div class="modal-container">
        <!-- Encabezado mejorado -->
        <div class="modal-header bg-gradient-to-r from-blue-500 to-blue-600">
          <Icon icon="lucide:file-search" class="mr-2" />
          <h2 class="text-white font-semibold text-lg">
             Búsqueda de Personal
          </h2>
          <button
            @click="$emit('close')"
            class="text-white hover:text-gray-400"
          >
            <i class="ri-close-line text-2xl"></i>
          </button>
        </div>

        <!-- Cuerpo del modal -->
        <div class="modal-body">
          <!-- Barra de búsqueda y exportación -->
          <div
            class="flex flex-col sm:flex-row justify-between items-start sm:items-center gap-4 mb-6 p-4 bg-gray-10 rounded-lg"
          >
            <div class="relative flex-grow max-w-md">
              <i
                class="ri-search-line absolute left-3 top-1/2 transform -translate-y-1/2 text-gray-400"
              ></i>
              <input
                ref="searchInput"
                v-model="searchTerm"
                @keyup.enter="performSearch"
                type="text"
                placeholder="Buscar por id, cédula, nombres o apellidos..."
                class="search-input pl-10 pr-4 py-2 w-full rounded-lg border border-gray-300 shadow-sm focus:outline-none focus:ring-1/2 focus:ring-blue-500 focus:border-blue-500"
              />
            </div>
            <button
              @click="performSearch"
              class="px-6 py-2 bg-white border text-blue-700 border-blue-700 rounded-lg hover:bg-blue-700"
            >
              <i class="ri-search-line mr-2"></i>
              Buscar
            </button>

            <div class="relative" ref="exportMenuRef">
              <button
                @click="showExportMenu = !showExportMenu"
                class="flex items-center justify-center w-10 h-10 rounded-full hover:bg-gray-200 transition-colors focus:outline-none"
                aria-label="Opciones de exportación"
              >
                <i class="ri-more-2-fill text-gray-600 text-xl"></i>
              </button>

              <transition
                enter-active-class="transition duration-100 ease-out"
                enter-from-class="transform scale-95 opacity-0"
                enter-to-class="transform scale-100 opacity-100"
                leave-active-class="transition duration-75 ease-in"
                leave-from-class="transform scale-100 opacity-100"
                leave-to-class="transform scale-95 opacity-0"
              >
                <div
                  v-if="showExportMenu"
                  class="absolute right-0 mt-2 w-48 bg-white rounded-md shadow-lg py-1 z-10 border border-gray-200"
                >
                  <button
                    @click="exportToExcel(filteredItems)"
                    class="flex items-center px-4 py-2 text-sm text-gray-700 hover:bg-blue-50 hover:text-blue-600 w-full text-left"
                  >
                    <i class="ri-file-excel-2-line mr-2 text-green-600"></i>
                    Exportar a Excel
                  </button>
                  <button
                    @click="exportToPDF(filteredItems)"
                    class="flex items-center px-4 py-2 text-sm text-gray-700 hover:bg-blue-50 hover:text-blue-600 w-full text-left"
                  >
                    <i class="ri-file-pdf-line mr-2 text-red-600"></i>
                    Exportar a PDF
                  </button>
                </div>
              </transition>
            </div>
          </div>

          <!-- Tabla de resultados -->
          <div class="border border-gray-200 rounded-lg overflow-hidden">
            <div class="overflow-x-auto">
              <table class="min-w-full divide-y divide-gray-200">
                <thead class="bg-gray-50">
                  <tr>
                    <th
                      v-for="header in headers"
                      :key="header.key"
                      @click="sortBy(header.key)"
                      class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider cursor-pointer hover:bg-gray-100"
                      :class="{ 'bg-gray-100': sortKey === header.key }"
                    >
                      <div class="flex items-center justify-between">
                        {{ header.label }}
                        <i
                          v-if="sortKey === header.key"
                          :class="
                            sortDirection === 'asc'
                              ? 'ri-arrow-up-line'
                              : 'ri-arrow-down-line'
                          "
                          class="ml-1"
                        ></i>
                      </div>
                    </th>
                  </tr>
                </thead>
                <tbody class="bg-white divide-y divide-gray-200">
                  <tr v-if="filteredItems.length === 0">
                    <td
                      :colspan="headers.length"
                      class="px-6 py-4 text-center text-gray-500"
                    >
                      No se encontraron resultados
                    </td>
                  </tr>
                  <tr
                    v-for="item in filteredItems"
                    :key="item.id"
                    class="hover:bg-blue-50 transition-colors"
                  >
                    <td
                      class="px-6 py-4 whitespace-nowrap text-xs font-medium text-gray-900"
                    >
                      {{ item.cedula }}
                    </td>
                    <td
                      class="px-6 py-4 whitespace-nowrap text-xs text-gray-500"
                    >
                      {{ item.nombres }} {{ item.apellidos }}
                    </td>
                    <td
                      class="px-6 py-4 whitespace-nowrap text-xs text-gray-500"
                    >
                      {{ item.provincia }}
                    </td>
                    <td
                      class="px-6 py-4 whitespace-nowrap text-xs text-gray-500"
                    >
                      {{ item.ciudad }}
                    </td>
                    <td class="px-6 py-4 whitespace-nowrap">
                      <span
                        :class="`px-2 py-1 rounded-full text-xs font-semibold ${
                          item.estado_Persoanl === 1
                            ? 'bg-green-100 text-green-800'
                            : 'bg-red-100 text-red-800'
                        }`"
                      >
                        {{ item.estado ? "Activo" : "Inactivo" }}
                      </span>
                    </td>
                    <td
                      class="px-6 py-4 whitespace-nowrap text-right text-sm font-medium"
                    >
                      <div class="flex justify-end space-x-2">
                        <button
                          @click="$emit('select', item)"
                          title="Editar"
                          class="text-blue-600 hover:text-blue-900"
                        >
                          <i class="ri-edit-line text-lg"></i>
                        </button>
                        <button
                          @click="confirmTerminate(item)"
                          title="Eliminar"
                          class="text-red-600 hover:text-red-900"
                        >
                          <i class="ri-delete-bin-line text-lg"></i>
                        </button>
                      </div>
                    </td>
                  </tr>
                </tbody>
              </table>
            </div>
          </div>

          <!-- Paginación (opcional) -->
          <div class="flex justify-between items-center mt-4 px-4">
            <span class="text-sm text-gray-700">
              Mostrando {{ filteredItems.length }} de
              {{ items.length }} registros
            </span>
            <select
              :value="itemsPerPage"
              @change="handlePageSizeChange"
              class="page-size-selector"
            >
              <option
                v-for="option in pageSizeOptions"
                :value="option"
                :key="option"
              >
                {{ option }} por página
              </option>
            </select>
            <div class="flex space-x-2">
              <button
                class="px-3 py-1 border rounded-md text-sm disabled:opacity-50"
                disabled="currentPage === 1"
                @click="previousPage"
              >
                Anterior
              </button>
              <button
                class="px-3 py-1 border rounded-md text-sm bg-blue-500 text-white"
              >
                1
              </button>
              <button
                class="px-3 py-1 border rounded-md text-sm"
                :disabled="currentPage >= totalPages"
                @click="nextPage"
              >
                Siguiente
              </button>
            </div>
          </div>
        </div>

        <!-- Pie de modal centrado -->
        <div class="modal-footer flex justify-center border-t border-gray-200">
          <button
            @click="$emit('close')"
            class="px-6 py-2 bg-gray-200 hover:bg-gray-300 text-gray-800 rounded-lg transition-colors flex items-center justify-center"
          >
            <span class="icon-container mr-2">
              <svg
                xmlns="http://www.w3.org/2000/svg"
                width="20"
                height="20"
                viewBox="0 0 24 24"
              >
                <path
                  fill="currentColor"
                  d="M6.4 19L5 17.6l5.6-5.6L5 6.4L6.4 5l5.6 5.6L17.6 5L19 6.4L13.4 12l5.6 5.6l-1.4 1.4l-5.6-5.6L6.4 19Z"
                />
              </svg>
            </span>
            Cerrar
          </button>
        </div>
      </div>
    </div>
  </Transition>
</template>

<script setup>
import { computed, ref, nextTick, watch } from "vue";
import { onClickOutside } from "@vueuse/core";
import { Icon } from "@iconify/vue";


 const props= defineProps( {
    show: Boolean,
    items: Array,
    currentPage: Number,
    itemsPerPage: Number,
    totalPages: Number,
    pageSizeOptions: { type: Array, default: () => [10, 20, 50, 100] },
    isLoading: Boolean
    
  });
  
  const emit = defineEmits([
  'close', 
  'search', 
  'select', 
  'page-change', 
  'change-page-size'
]);
    const searchInput = ref(null);
    const searchTerm = ref("");
    const showExportMenu = ref(false);
    const exportMenuRef = ref(null);
    const filteredItems = computed(() => {
      return props.items || [];
    });

    if (props.show) {
      nextTick(() => {
        if (searchInputElement) {
          searchInput.value.focus();
        }
      });
    }
    watch(
      () => props.show,
      (newVal) => {
        if (newVal) {
          setTimeout(() => {
            const input = document.querySelector(".search-input");
            if (input) input.focus();
          }, 100);
        }
      }
    );

    const performSearch = () => {
      emit("search", searchTerm.value);
    };

    const sortKey = ref("");
    const sortDirection = ref("asc");
    onClickOutside(exportMenuRef, () => {
      showExportMenu.value = false;
    });

    const headers = ref([
      { key: "CEDULA", label: "Cédula" },
      { key: "NOMBRES", label: "Nombres" },
      { key: "PROVINCIA", label: "Provincia" },
      { key: "CIUDAD", label: "Ciudad" },
      { key: "ESTADO_PERSONAL", label: "Estado" },
      { key: "acciones", label: "Acciones" },
    ]);

    const nextPage = () => {
      if (props.currentPage < props.totalPages) {
        emit("page-change", props.currentPage + 1);
      }
    };

    const handlePageSizeChange = (e) => {
      const newValue = Number(e.target.value);
      emit("change-page-size", newValue); // Emite el evento para actualizar
    };

    const sortBy = (key) => {
      if (sortKey.value === key) {
        sortDirection.value = sortDirection.value === "asc" ? "desc" : "asc";
      } else {
        sortKey.value = key;
        sortDirection.value = "asc";
      }
    };

    
  
</script>

<style scoped>
.modal-mask {
  position: fixed;
  z-index: 9999;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background-color: rgba(0, 0, 0, 0.5);
  display: flex;
  justify-content: center;
  align-items: center;
  transition: opacity 0.3s ease;
}

.modal-container {
  width: 90%;
  max-width: 1200px;
  max-height: 90vh;
  background-color: #fff;
  border-radius: 12px;
  box-shadow: 0 4px 20px rgba(0, 0, 0, 0.15);
  display: flex;
  flex-direction: column;
  transition: all 0.3s ease;
}

.modal-header {
  padding: 16px 24px;
  display: flex;
  justify-content: space-between;
  align-items: center;
  border-top-left-radius: 12px;
  border-top-right-radius: 12px;
}

.modal-body {
  flex: 1;
  padding: 20px;
  max-height: 60vh;
  overflow-y: auto;
}

.modal-footer {
  padding: 16px 24px;
  border-bottom-left-radius: 12px;
  border-bottom-right-radius: 12px;
}

.modal-close {
  background: transparent;
  border: none;
  cursor: pointer;
  padding: 4px;
  display: flex;
  align-items: center;
  justify-content: center;
}

.icon-container {
  display: inline-flex;
  align-items: center;
  justify-content: center;
  width: 20px;
  height: 20px;
}

/* Animaciones */
.modal-fade-enter-from,
.modal-fade-leave-to {
  opacity: 0;
}

.modal-fade-enter-active .modal-container,
.modal-fade-leave-active .modal-container {
  transform: scale(0.95);
}

/* Scroll personalizado */
.modal-body::-webkit-scrollbar {
  width: 8px;
}

.modal-body::-webkit-scrollbar-track {
  background: #f1f1f1;
  border-radius: 4px;
}

.modal-body::-webkit-scrollbar-thumb {
  background: #c1c1c1;
  border-radius: 4px;
}

.modal-body::-webkit-scrollbar-thumb:hover {
  background: #a8a8a8;
}
</style>
