<template>
  <Transition name="modal-fade">
    <div v-if="show" class="modal-mask" @click.self="$emit('close')">
      <div class="modal-container">
        <!-- Encabezado mejorado -->
        <div class="modal-header bg-gradient-to-r from-blue-500 to-blue-600">
          <h3 class="text-white font-semibold text-lg">
            <i class="ri-team-line mr-2"></i> Búsqueda de Personal
          </h3>
          
        </div>

        <!-- Cuerpo del modal -->
        <div class="modal-body">
          <!-- Barra de búsqueda y exportación -->
          <div class="flex flex-col sm:flex-row justify-between items-start sm:items-center gap-4 mb-6 p-4 bg-gray-50 rounded-lg">
            <div class="relative flex-grow max-w-md">
              <i class="ri-search-line absolute left-3 top-1/2 transform -translate-y-1/2 text-gray-400"></i>
              <input
                v-model="searchQuery"
                placeholder="Buscar por cédula, nombres o apellidos..."
                class="search-input pl-10 pr-4 py-2 w-full  rounded-lg border border-gray-300 shadow-sm focus:outline-none focus:ring-1 focus:ring-blue-500 focus:border-blue-500"
                
              />
            </div>
            
            <div class="flex gap-2 w-full sm:w-auto">
              <button 
                @click="exportToExcel"
                class="flex items-center gap-2 px-4 py-2 bg-green-600 hover:bg-green-700 text-white rounded-lg transition-colors"
              >
                <i class="ri-file-excel-2-line"></i> Excel
              </button>
              <button 
                @click="exportToPDF"
                class="flex items-center gap-2 px-4 py-2 bg-red-600 hover:bg-red-700 text-white rounded-lg transition-colors"
              >
                <i class="ri-file-pdf-line"></i> PDF
              </button>
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
                          :class="sortDirection === 'asc' ? 'ri-arrow-up-line' : 'ri-arrow-down-line'"
                          class="ml-1"
                        ></i>
                      </div>
                    </th>
                  </tr>
                </thead>
                <tbody class="bg-white divide-y divide-gray-200">
                  <tr v-if="filteredItems.length === 0">
                    <td :colspan="headers.length" class="px-6 py-4 text-center text-gray-500">
                      No se encontraron resultados
                    </td>
                  </tr>
                  <tr 
                    v-for="item in filteredItems" 
                    :key="item.id"
                    class="hover:bg-blue-50 transition-colors"
                  >
                    <td class="px-6 py-4 whitespace-nowrap text-sm font-medium text-gray-900">
                      {{ item.cedula }}
                    </td>
                    <td class="px-6 py-4 whitespace-nowrap text-sm text-gray-500">
                      {{ item.nombres }} {{ item.apellidos }}
                    </td>
                    <td class="px-6 py-4 whitespace-nowrap text-sm text-gray-500">
                      {{ item.cargo }}
                    </td>
                    <td class="px-6 py-4 whitespace-nowrap">
                      <span :class="`px-2 py-1 rounded-full text-xs font-semibold ${item.activo ? 'bg-green-100 text-green-800' : 'bg-red-100 text-red-800'}`">
                        {{ item.activo ? 'Activo' : 'Inactivo' }}
                      </span>
                    </td>
                    <td class="px-6 py-4 whitespace-nowrap text-right text-sm font-medium">
                      <div class="flex justify-end space-x-2">
                        <button 
                          @click="$emit('select', item)"
                          class="text-blue-600 hover:text-blue-900"
                          title="Editar"
                        >
                          <i class="ri-edit-line text-lg"></i>
                        </button>
                        <button 
                          @click="confirmTerminate(item)"
                          class="text-red-600 hover:text-red-900"
                          title="Terminar contrato"
                        >
                          <i class="ri-contract-line text-lg"></i>
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
              Mostrando {{ filteredItems.length }} de {{ items.length }} registros
            </span>
            <div class="flex space-x-2">
              <button class="px-3 py-1 border rounded-md text-sm disabled:opacity-50" disabled>
                Anterior
              </button>
              <button class="px-3 py-1 border rounded-md text-sm bg-blue-500 text-white">
                1
              </button>
              <button class="px-3 py-1 border rounded-md text-sm">
                Siguiente
              </button>
            </div>
          </div>
        </div>

        <!-- Pie de modal centrado -->
        <div class="modal-footer flex justify-center border-t border-gray-200">
          <button 
            @click="$emit('close')" 
            class="px-6 py-2 bg-gray-200 hover:bg-gray-300 text-gray-800 rounded-lg transition-colors"
          >
            Cerrar
          </button>
        </div>
      </div>
    </div>
  </Transition>
</template>

<script>
//import { jsPDF } from 'jspdf'
//import 'jspdf-autotable'
//import * as XLSX from 'xlsx'

export default {
  props: {
    show: Boolean,
    items: Array
  },
  data() {
    return {
      searchQuery: '',
      sortKey: '',
      sortDirection: 'asc',
      headers: [
        { key: 'cedula', label: 'Cédula' },
        { key: 'nombres', label: 'Nombres' },
        { key: 'cargo', label: 'Cargo' },
        { key: 'activo', label: 'Estado' },
        { key: 'actions', label: 'Acciones' }
      ]
    }
  },
  computed: {
    filteredItems() {
      let result = [...this.items]
      
      // Filtrado
      if (this.searchQuery) {
        const query = this.searchQuery.toLowerCase()
        result = result.filter(item => 
          item.cedula.toLowerCase().includes(query) || 
          item.nombres.toLowerCase().includes(query) ||
          item.apellidos.toLowerCase().includes(query) ||
          item.cargo.toLowerCase().includes(query)
        )
      }
      
      // Ordenamiento
      if (this.sortKey) {
        result.sort((a, b) => {
          const valA = a[this.sortKey]
          const valB = b[this.sortKey]
          
          if (valA < valB) return this.sortDirection === 'asc' ? -1 : 1
          if (valA > valB) return this.sortDirection === 'asc' ? 1 : -1
          return 0
        })
      }
      
      return result
    }
  },
  methods: {
    sortBy(key) {
      if (this.sortKey === key) {
        this.sortDirection = this.sortDirection === 'asc' ? 'desc' : 'asc'
      } else {
        this.sortKey = key
        this.sortDirection = 'asc'
      }
    },
    confirmTerminate(item) {
      this.$confirm(
        `¿Está seguro de terminar el contrato de ${item.nombres} ${item.apellidos}?`,
        'Confirmar acción',
        {
          confirmButtonText: 'Sí, terminar',
          cancelButtonText: 'Cancelar',
          type: 'warning'
        }
      ).then(() => {
        this.$emit('terminate', item)
      }).catch(() => {})
    },
    exportToExcel() {
      const data = this.filteredItems.map(item => ({
        Cédula: item.cedula,
        Nombres: item.nombres,
        Apellidos: item.apellidos,
        Cargo: item.cargo,
        Estado: item.activo ? 'Activo' : 'Inactivo'
      }))
      
      const worksheet = XLSX.utils.json_to_sheet(data)
      const workbook = XLSX.utils.book_new()
      XLSX.utils.book_append_sheet(workbook, worksheet, 'Personal')
      
      const date = new Date().toISOString().split('T')[0]
      XLSX.writeFile(workbook, `personal_${date}.xlsx`)
    },
    exportToPDF() {
      const doc = new jsPDF()
      const date = new Date().toLocaleDateString()
      
      // Título
      doc.setFontSize(18)
      doc.text('Listado de Personal', 14, 22)
      doc.setFontSize(11)
      doc.setTextColor(100)
      doc.text(`Generado el: ${date}`, 14, 30)
      
      // Tabla
      const headers = [['Cédula', 'Nombres', 'Apellidos', 'Cargo', 'Estado']]
      const data = this.filteredItems.map(item => [
        item.cedula,
        item.nombres,
        item.apellidos,
        item.cargo,
        item.activo ? 'Activo' : 'Inactivo'
      ])
      
      doc.autoTable({
        head: headers,
        body: data,
        startY: 40,
        styles: {
          cellPadding: 3,
          fontSize: 9,
          valign: 'middle',
          halign: 'left'
        },
        headStyles: {
          fillColor: [41, 128, 185],
          textColor: 255,
          fontStyle: 'bold'
        },
        alternateRowStyles: {
          fillColor: [245, 245, 245]
        },
        margin: { top: 40 }
      })
      
      doc.save(`personal_${new Date().toISOString().split('T')[0]}.pdf`)
    }
  }
}
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