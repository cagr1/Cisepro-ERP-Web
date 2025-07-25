<template>
  <Transition name="modal-fade">
    <div v-if="show" class="modal-mask" @click.self="$emit('close')">
      <div class="modal-container">
        <!-- Encabezado mejorado -->
        <div class="modal-header">
          <Icon icon="heroicons:magnifying-glass" class="mr-2 text-white" />
          <h2 class="text-white font-semibold text-lg">Búsqueda de Personal</h2>
          <button
            @click="$emit('close')"
            class="text-white hover:text-gray-400"
          >
            <Icon icon="heroicons:x-mark" />
          </button>
        </div>

        <!-- Cuerpo del modal -->
        <div class="modal-body">
          <!-- Barra de búsqueda y exportación -->
          <div class="search-container">
            <div
              class="flex flex-col sm:flex-row justify-between items-start sm:items-center gap-2  p-2 bg-gray-10 rounded-lg"
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
                  placeholder="Buscar por cédula, nombres o apellidos..."
                  class="search-input pl-10 pr-4 py-2 w-full rounded-lg border border-gray-300 shadow-sm focus:outline-none focus:ring-1/2 focus:ring-blue-500 focus:border-blue-500"
                />
                <button
                  v-if="searchTerm"
                  @click="clearSearch"
                  class="absolute right-3 top-1/2 transform -translate-y-1/2 text-gray-400 hover:text-gray-600"
                >
                  <i class="ri-close-line"></i>
                </button>
              </div>

              <div class="relative z-20" ref="exportMenuRef">
                <button
                  @click="showExportMenu = !showExportMenu"
                  class="flex items-center justify-center w-10 h-10 rounded-full hover:bg-gray-200 transition-colors focus:outline-none"
                  aria-label="Opciones de exportación"
                >
                  <Icon icon="heroicons:ellipsis-vertical" />
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
          </div>
          <!-- Tabla de resultados -->
          <div class="table-outer-container">
            <div class="table-container bg-white rounded-lg shadow-sm">
              <div class="table-wrapper">
                <table>
                  <thead>
                    <tr>
                      <th
                        v-for="header in headers"
                        :key="header.key"
                        @click="header.sortable ? sortBy(header.key) : null"
                        class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider cursor-pointer hover:bg-gray-100"
                        :class="{
                          'cursor-pointer hover: bg-gray-100': header.sortable,
                          'bggray-100': sortKey === header.key,
                        }"
                      >
                        <div class="flex items-center justify-between">
                          {{ header.label }}
                          <i
                            v-if="header.sortable && sortKey === header.key"
                            :class="[
                              'ml-1',
                              sortDirection === 'asc'
                                ? 'ri-arrow-up-line'
                                : 'ri-arrow-down-line',
                            ]"
                          ></i>
                          <i
                            v-else-if="header.sortable"
                            class="ml-1 ri-arrow-up-down-line text-gray-400"
                          ></i>
                        </div>
                      </th>
                    </tr>
                  </thead>
                  <tbody class="bg-white divide-y divide-gray-200">
                    <tr v-if="displayedItems.length === 0">
                      <td
                        :colspan="headers.length"
                        class="px-6 py-4 text-center text-gray-500"
                      >
                        No se encontraron resultados
                      </td>
                    </tr>
                    <tr
                      v-for="item in displayedItems"
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
                            item.estado_Personal === 1
                              ? 'bg-green-100 text-green-800'
                              : 'bg-red-100 text-red-800'
                          }`"
                        >
                          {{
                            item.estado_Personal === 1 ? "Activo" : "Inactivo"
                          }}
                        </span>
                      </td>
                      <td
                        class="px-6 py-4 whitespace-nowrap text-right text-sm font-medium"
                      >
                        <div class="flex justify-start space-x-2">
                          <button
                            @click="handleView(item)"
                            title="Ver"
                            class="text-green-600 hover:text-green-900"
                            :disabled=" props.isLoading"
                          >
                            <i class="ri-eye-line text-lg"></i>
                          </button>

                          <template v-if="item.estado_Personal === 1">
                            <button
                              @click="$emit('select-employee', item)"
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
                              <!--  -->
                            </button>
                          </template>
                        </div>
                      </td>
                    </tr>
                  </tbody>
                </table>
              </div>
            </div>
          </div>

          
          <!-- Pie de modal mejorado -->
          
        </div>

        <!-- Paginación mejorada -->
          <div
            class="modal-footer "
          >
            <div class="text-sm text-gray-600">
              Mostrando {{ (currentPage - 1) * itemsPerPage + 1 }} a
              {{ Math.min(currentPage * itemsPerPage, totalItems) }} de
              {{ totalItems }} registros
            </div>

            <div class="flex items-center space-x-4">
              <div class="flex items-center space-x-2">
                <span class="text-sm text-gray-600">Mostrar:</span>
                <select
                  :value="itemsPerPage"
                  @change="handlePageSizeChange($event.target.value)"
                  class="text-sm text-gray-700 bg-white border border-gray-200 rounded-md px-3 py-1.5 focus:outline-none focus:ring-1 focus:ring-blue-500 focus:border-blue-500 transition-colors"
                >
                  <option
                    v-for="option in pageSizeOptions"
                    :value="option"
                    :key="option"
                    class="text-sm"
                  >
                    {{ option }}
                  </option>
                </select>
              </div>

              <div class="flex items-center space-x-1">
                <button
                  @click="previousPage"
                  :disabled="currentPage === 1"
                  class="p-1.5 rounded-md text-gray-600 hover:bg-gray-100 disabled:opacity-50 disabled:cursor-not-allowed transition-colors"
                >
                  <i class="ri-arrow-left-s-line text-lg"></i>
                </button>

                <template v-for="page in visiblePages" :key="page">
                  <button
                    @click="emit('page-change', page)"
                    class="w-8 h-8 rounded-md text-sm flex items-center justify-center"
                    :class="{
                      'bg-blue-500 text-white': page === currentPage,
                      'text-gray-700 hover:bg-gray-100': page !== currentPage,
                    }"
                  >
                    {{ page }}
                  </button>
                </template>

                <button
                  @click="nextPage"
                  :disabled="currentPage >= totalPages"
                  class="p-1.5 rounded-md text-gray-600 hover:bg-gray-100 disabled:opacity-50 disabled:cursor-not-allowed transition-colors"
                >
                  <i class="ri-arrow-right-s-line text-lg"></i>
                </button>
              </div>
            </div>
          </div>


      </div>
    </div>
  </Transition>
</template>

<script setup>
import { computed, ref, nextTick, watch } from "vue";
import { onClickOutside } from "@vueuse/core";
import { Icon } from "@iconify/vue";
import { push } from "notivue";

const props = defineProps({
  show: Boolean,
  items: Array,
  currentPage: Number,
  itemsPerPage: Number,
  totalItems: Number,
  totalPages: Number,
  pageSizeOptions: { type: Array, default: () => [10, 20, 50, 100] },
  isLoading: Boolean,
});

const emit = defineEmits([
  "update:show",
  "search",
  "select-employee",
  "view",
  "page-change",
  "change-page-size",
  "sort",
  "close",
]);
const searchInput = ref(null);
const searchTerm = ref("");
const showExportMenu = ref(false);
const exportMenuRef = ref(null);

//

const displayedItems = computed(() => {
  if (!props.items) return [];

  // Hacer una copia para no modificar los props originales
  let items = [...props.items];

  // Ordenar si hay una clave seleccionada
  if (sortKey.value) {
    items.sort((a, b) => {
      const valueA = String(a[sortKey.value] || "").toLowerCase();
      const valueB = String(b[sortKey.value] || "").toLowerCase();

      if (valueA < valueB) return sortDirection.value === "asc" ? -1 : 1;
      if (valueA > valueB) return sortDirection.value === "asc" ? 1 : -1;
      return 0;
    });
  }

  return items;
});

const visiblePages = computed(() => {
  const pages = [];
  const maxVisible = 5;
  let start = Math.max(1, props.currentPage - Math.floor(maxVisible / 2));
  const end = Math.min(props.totalPages, start + maxVisible - 1);

  if (end - start + 1 < maxVisible) {
    start = Math.max(1, end - maxVisible + 1);
  }

  for (let i = start; i <= end; i++) {
    pages.push(i);
  }

  return pages;
});

const clearSearch = () => {
  searchTerm.value = "";
};

const performSearch = () => {
  emit("search", searchTerm.value);
};

const sortKey = ref("");
const sortDirection = ref("asc");
onClickOutside(exportMenuRef, () => {
  showExportMenu.value = false;
});

const headers = ref([
  { key: "cedula", label: "Cédula", sortable: true },
  { key: "nombres", label: "Nombres", sortable: true },
  { key: "provincia", label: "Provincia", sortable: true },
  { key: "ciudad", label: "Ciudad", sortable: true },
  { key: "estado_Personal", label: "Estado", sortable: true },
  { key: "acciones", label: "Acciones", sortable: false },
]);

const nextPage = () => {
  if (props.currentPage < props.totalPages) {
    emit("page-change", props.currentPage + 1);
  }
};
const previousPage = () => {
  if (props.currentPage > 1) {
    emit("page-change", props.currentPage - 1);
  }
};

const handlePageSizeChange = (newValue) => {
  const numValue = Number(newValue);
  emit("change-page-size", numValue);
  emit("page-change", 1); // Reset to first page on page size change
};

//Boton ver
const handleView = (item) => {
 
  if (props.isLoading) return;
 
  try {
   
  emit('select-employee', item, true);
  emit('close');

 } catch (error) {
  push.error(
    {
      title: "Error al ver el personal",
      message: error.message || "Ocurrió un error al intentar ver el personal.",
    });
 }
}
;

const sortBy = (key) => {
  if (key === "acciones") return; // No ordenar por acciones

  if (sortKey.value === key) {
    sortDirection.value = sortDirection.value === "asc" ? "desc" : "asc";
  } else {
    sortKey.value = key;
    sortDirection.value = "asc";
  }
};
</script>

<style scoped>
select {
  appearance: none;
  background-image: url("data:image/svg+xml;charset=UTF-8,%3csvg xmlns='http://www.w3.org/2000/svg' viewBox='0 0 24 24' fill='none' stroke='currentColor' stroke-width='2' stroke-linecap='round' stroke-linejoin='round'%3e%3cpolyline points='6 9 12 15 18 9'%3e%3c/polyline%3e%3c/svg%3e");
  background-repeat: no-repeat;
  background-position: right 0.5rem center;
  background-size: 1em;
  padding-right: 2rem;
}

/* Transiciones suaves para los botones */
button {
  transition: all 0.2s ease;
}

/* Efecto hover más sutil */
.hover\:bg-gray-100:hover {
  background-color: rgba(243, 244, 246, 0.8);
}

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
}

.modal-container {
  width: 90%;
  max-width: 870px;
  max-height: 85vh;
  background-color: #fff;
  border-radius: 12px;
  display: flex;
  flex-direction: column;
  min-height: 0;
}


.modal-header {
  padding: 6px 14px;
  display: flex;
  justify-content: space-between;
  align-items: center;
  background: linear-gradient(to right, #3b82f6, #2563eb);
  border-top-left-radius: 12px;
  border-top-right-radius: 12px;
}

.modal-body {
  
  
  padding: 8px 16px;
  flex-direction: column;
  gap: 4px;
  overflow-y: auto;
}

.search-container {
  padding-top: 0.1rem;
  margin-bottom: 0.1rem;
}

/* Footer ajustado */
.modal-footer {
  padding:  0.75rem;
  border-top: 1px solid #e5e7eb;
  display: flex;
  justify-content: space-between;
  align-items: center;
}

.modal-footer > div:first-child {
  text-align: left;
  margin-right: auto;
}

.table-outer-container {
  flex: 1;
  
  padding: 1px 3px;
  margin-top: 0;
  
}

.table-container {
  flex: 1;
  display: flex;
  flex-direction: column;
  border: 1px solid #e5e7eb;
  border-radius: 8px;
  background: white;
  box-shadow: 0 1px 2px rgba(0, 0, 0, 0.05);
  min-height: 180px;
}

.table-wrapper {
  flex: 1;
  overflow: auto;
  display: flex;
  min-width: 100%;
  border-radius: 4px ;
  background: #888;
}

table {
  min-width: 100%;
  width: max-content;
  border-collapse: separate;
  border-spacing: 0;
}

thead {
  position: sticky;
  top: 0;
  z-index: 10;
  background-color: #f9fafb;
}

th {
  padding: 6px 8px !important; /* Padding reducido */
  font-size: 0.75rem !important;
  font-weight: 500;
  text-align: left;
  white-space: nowrap;
}

td {
  padding: 4px 6px !important; /* Padding reducido para filas más compactas */
  font-size: 0.7rem !important;
  
}

/* Paginación más compacta */
.pagination-container {
  padding: 2px 0;
  margin-top: 4px;
}



.icon-container {
  display: inline-flex;
  align-items: center;
  justify-content: center;
  width: 15px;
  height: 15px;
}

/* Scrollbar personalizada */
.table-wrapper::-webkit-scrollbar {
  height: 8px;
  width: 8px;
}

.table-wrapper::-webkit-scrollbar-track {
  background: #f1f1f1;
}

.table-wrapper::-webkit-scrollbar-thumb {
  background: #c1c1c1;
  border-radius: 6px;
  
}

.hover\:bg-gray-100:hover {
  background-color: rgba(243, 244, 246, 0.8);
}
/* Animaciones mejoradas */
.modal-fade-enter-active,
.modal-fade-leave-active {
  transition: opacity 0.2s ease;
}

.modal-fade-enter-from,
.modal-fade-leave-to {
  opacity: 0;
}

.modal-fade-enter-active .modal-container,
.modal-fade-leave-active .modal-container {
  transition: transform 0.2s ease;
}

.modal-fade-enter-from .modal-container,
.modal-fade-leave-to .modal-container {
  transform: scale(0.98);
}
</style>
