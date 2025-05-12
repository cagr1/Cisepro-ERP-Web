<template>
  <div class="min-h-screen bg-gray-10 p-4">
    <!-- Barra de acciones superior -->
    <div class="bg-white rounded-lg shadow-md p-4 mb-6 sticky top-0 z-10">
      <div class="flex justify-between items-center">
        <h1 class="text-2xl font-semibold text-gray-800">
          Gestión de Personal
        </h1>
        <div class="flex space-x-2">
          <button
            @click="buscarPersonal"
            class="flex items-center px-4 py-2 border border-blue-600 text-blue-600 rounded-lg hover:bg-blue-600 hover:text-white transition-colors"
          >
            <i class="ri-search-line mr-2"></i> Buscar
          </button>
          <button
            @click="nuevoPersonal"
            class="flex items-center px-4 py-2 border border-green-600 text-green-600 rounded-lg hover:bg-green-600 hover:text-white transition-colors"
          >
            <i class="ri-add-line mr-2"></i> Nuevo
          </button>
          <button
            @click="guardarPersonal"
            class="flex items-center px-4 py-2 border border-indigo-600 text-indigo-700 rounded-lg hover:bg-indigo-700 hover:text-white transition-colors"
          >
            <i class="ri-save-line mr-2"></i> Guardar
          </button>
          <button
            @click="cancelarEdicion"
            class="flex items-center px-4 py-2 border border-gray-700 text-gray-700 rounded-lg hover:bg-gray-700 hover:text-white transition-colors"
          >
            <i class="ri-close-line mr-2"></i> Cancelar
          </button>
        </div>
      </div>
    </div>

    <!-- Pestañas -->
    <div class="bg-white rounded-lg shadow-md overflow-hidden mb-6">
      <div class="border-b border-gray-200">
        <nav class="flex -mb-px">
          <button
            v-for="tab in tabs"
            :key="tab.id"
            @click="currentTab = tab.id"
            :class="[
              'px-6 py-3 text-sm font-medium',
              currentTab === tab.id
                ? 'border-b-2 border-blue-500 text-blue-600'
                : 'text-gray-500 hover:text-gray-700 hover:border-gray-300',
            ]"
          >
            <div class="flex items-center">
              <i :class="`${tab.icon} mr-2`"></i>
              {{ tab.name }}
            </div>
          </button>
        </nav>
      </div>

      <!-- Contenido de las pestañas -->
      <div class="p-6">
        <!-- Pestaña Datos Personales -->
        <div v-if="currentTab === 'datos'">
          <!-- <div class="grid grid-cols-1 md:grid-cols-2 gap-6"> -->
          <!-- Columna Izquierda -->
          <!-- <div>
              <div class="mb-4">
                <label class="block text-sm font-medium text-gray-700 mb-1">Cédula</label>
                <input
                  type="text"
                  v-model="formData.cedula"
                  class="w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-blue-500 focus:border-blue-500"
                />
              </div>

              <div class="mb-4">
                <label class="block text-sm font-medium text-gray-700 mb-1">Nombres</label>
                <input
                  type="text"
                  v-model="formData.nombres"
                  class="w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-blue-500 focus:border-blue-500"
                />
              </div>

              <div class="mb-4">
                <label class="block text-sm font-medium text-gray-700 mb-1">Apellidos</label>
                <input
                  type="text"
                  v-model="formData.apellidos"
                  class="w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-blue-500 focus:border-blue-500"
                />
              </div>

              <div class="mb-4">
                <label class="block text-sm font-medium text-gray-700 mb-1">Sexo</label>
                <select
                  v-model="formData.sexo"
                  class="w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-blue-500 focus:border-blue-500"
                >
                  <option value="masculino">Masculino</option>
                  <option value="femenino">Femenino</option>
                </select>
              </div>

              <div class="mb-4">
                <label class="block text-sm font-medium text-gray-700 mb-1">Estado Civil</label>
                <select
                  v-model="formData.estadoCivil"
                  class="w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-blue-500 focus:border-blue-500"
                >
                  <option value="soltero">Soltero</option>
                  <option value="casado">Casado</option>
                  <option value="divorciado">Divorciado</option>
                  <option value="viudo">Viudo</option>
                </select>
              </div>

              <div class="mb-4">
                <label class="block text-sm font-medium text-gray-700 mb-1">Instrucción</label>
                <select
                  v-model="formData.instruccion"
                  class="w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-blue-500 focus:border-blue-500"
                >
                  <option value="primaria">Primaria</option>
                  <option value="secundaria">Secundaria</option>
                  <option value="superior">Superior</option>
                </select>
              </div>

              <div class="mb-4">
                <label class="block text-sm font-medium text-gray-700 mb-1">Tipo de Sangre</label>
                <select
                  v-model="formData.tipoSangre"
                  class="w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-blue-500 focus:border-blue-500"
                >
                  <option value="O+">O+</option>
                  <option value="O-">O-</option>
                  <option value="A+">A+</option>
                  <option value="A-">A-</option>
                  <option value="B+">B+</option>
                  <option value="B-">B-</option>
                  <option value="AB+">AB+</option>
                  <option value="AB-">AB-</option>
                </select>
              </div>

              <div class="mb-4">
                <label class="block text-sm font-medium text-gray-700 mb-1">Provincia</label>
                <select
                  v-model="formData.provincia"
                  @change="cargarParroquiasYCiudades"
                  class="w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-blue-500 focus:border-blue-500"
                >
                  <option v-for="provincia in provincias" :key="provincia.id" :value="provincia.id">
                    {{ provincia.nombre }}
                  </option>
                </select>
              </div>

              <div class="mb-4">
                <label class="block text-sm font-medium text-gray-700 mb-1">Parroquia</label>
                <select
                  v-model="formData.parroquia"
                  class="w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-blue-500 focus:border-blue-500"
                  :disabled="!formData.provincia"
                >
                  <option v-for="parroquia in parroquias" :key="parroquia.id" :value="parroquia.id">
                    {{ parroquia.nombre }}
                  </option>
                </select>
              </div>

              <div class="mb-4">
                <label class="block text-sm font-medium text-gray-700 mb-1">Dirección</label>
                <textarea
                  v-model="formData.direccion"
                  class="w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-blue-500 focus:border-blue-500"
                ></textarea>
              </div>
            </div> -->

          <!-- Columna Derecha -->
          <!-- <div>
              <div class="mb-4">
                <label class="block text-sm font-medium text-gray-700 mb-1">Email</label>
                <input
                  type="email"
                  v-model="formData.email"
                  class="w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-blue-500 focus:border-blue-500"
                />
              </div>

              <div class="mb-4">
                <label class="block text-sm font-medium text-gray-700 mb-1">Banco</label>
                <select
                  v-model="formData.banco"
                  class="w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-blue-500 focus:border-blue-500"
                >
                  <option value="banco1">Banco 1</option>
                  <option value="banco2">Banco 2</option>
                  <option value="banco3">Banco 3</option>
                </select>
              </div>

              <div class="mb-4">
                <label class="block text-sm font-medium text-gray-700 mb-1">Cuenta</label>
                <input
                  type="text"
                  v-model="formData.cuenta"
                  class="w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-blue-500 focus:border-blue-500"
                />
              </div>

              <div class="mb-4">
                <label class="block text-sm font-medium text-gray-700 mb-1">Contrato</label>
                <input
                  type="text"
                  v-model="formData.contrato"
                  class="w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-blue-500 focus:border-blue-500"
                />
              </div>

              <div class="mb-4">
                <label class="block text-sm font-medium text-gray-700 mb-1">Fecha de Nacimiento</label>
                <input
                  type="date"
                  v-model="formData.fechaNacimiento"
                  class="w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-blue-500 focus:border-blue-500"
                />
              </div>

              <div class="mb-4">
                <label class="block text-sm font-medium text-gray-700 mb-1">Pasaporte</label>
                <input
                  type="text"
                  v-model="formData.pasaporte"
                  class="w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-blue-500 focus:border-blue-500"
                />
              </div>

              <div class="mb-4">
                <label class="block text-sm font-medium text-gray-700 mb-1">Libreta Militar</label>
                <input
                  type="text"
                  v-model="formData.libretaMilitar"
                  class="w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-blue-500 focus:border-blue-500"
                />
              </div>

              <div class="mb-4">
                <label class="block text-sm font-medium text-gray-700 mb-1">Peso (kg)</label>
                <input
                  type="number"
                  v-model="formData.peso"
                  class="w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-blue-500 focus:border-blue-500"
                />
              </div>

              <div class="mb-4">
                <label class="block text-sm font-medium text-gray-700 mb-1">Estatura (cm)</label>
                <input
                  type="number"
                  v-model="formData.estatura"
                  class="w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-blue-500 focus:border-blue-500"
                />
              </div>

              <div class="mb-4">
                <label class="block text-sm font-medium text-gray-700 mb-1">Ciudad</label>
                <select
                  v-model="formData.ciudad"
                  class="w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-blue-500 focus:border-blue-500"
                  :disabled="!formData.provincia"
                >
                  <option v-for="ciudad in ciudades" :key="ciudad.id" :value="ciudad.id">
                    {{ ciudad.nombre }}
                  </option>
                </select>
              </div>
            </div> -->
          <!-- Sección superior con foto y datos básicos -->

          <!-- </div> -->

          <!-- Sección adicional de datos -->
          <!-- <div class="grid grid-cols-1 md:grid-cols-3 gap-6 mt-6">
            <div>
              <label class="block text-sm font-medium text-gray-700 mb-2">Imagen de Perfil</label>
              <div class="flex items-center justify-center w-full">
                <label for="dropzone-file" class="flex flex-col items-center justify-center w-full h-32 border-2 border-gray-300 border-dashed rounded-lg cursor-pointer bg-gray-50 hover:bg-gray-100">
                  <div class="flex flex-col items-center justify-center pt-5 pb-6">
                    <svg class="w-8 h-8 mb-4 text-gray-500" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 20 16">
                      <path stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M13 4h-2V2a2 2 0 0 0-2-2H7a2 2 0 0 0-2 2v2H2m2 5h6m-6 2h6m-3-3v6m-3-9h6m-3 3H8m-3-3H2"/>
                    </svg>
                    <p class="mb-2 text-sm text-gray-500"><span class="font-semibold">Click para subir</span> o arrastrar y soltar</p>
                    <p class="text-xs text-gray-500">SVG, PNG, JPG o GIF (MAX. 800x400px)</p>
                  </div>
                  <input id="dropzone-file" type="file" class="hidden" @change="handleFileChange"/>
                </label>
              </div>
              <div v-if="formData.imagenPerfil" class="mt-2">
                <img :src="formData.imagenPerfil" alt="Imagen de perfil" class="w-16 h-16 rounded-full">
              </div>
            </div>
            
            <div>
              <label class="block text-sm font-medium text-gray-700 mb-2">Edad</label>
              <input
                type="number"
                v-model="edad"
                readonly
                class="w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm bg-gray-100 focus:outline-none focus:ring-blue-500 focus:border-blue-500"
              />
            </div>
            
            <div class="flex items-center mb-4">
              <label for="credencial" class="mr-2 text-sm font-medium text-gray-700">Credencial</label>
              <input
                type="checkbox"
                id="credencial"
                v-model="formData.credencial"
                class="h-5 w-5 text-blue-600 focus:ring-blue-500 border-gray-300 rounded"
              />
            </div>
          </div> -->
          <div class="grid grid-cols-1 md:grid-cols-4 gap-4 mb-4">
            <!-- Columna de la foto - Reducida -->
            <div class="flex flex-col items-center">
              <div
                class="w-24 h-24 rounded-full bg-gray-200 mb-2 overflow-hidden border-2 border-white shadow-sm"
              >
                <img
                  v-if="formData.imagenPerfil"
                  :src="formData.imagenPerfil"
                  class="w-full h-full object-cover"
                  alt="Foto de perfil"
                />
                <div
                  v-else
                  class="w-full h-full flex items-center justify-center text-gray-400"
                >
                  <i class="ri-user-line text-4xl"></i>
                </div>
              </div>
              <label
                for="dropzone-file"
                class="text-xs text-blue-600 hover:text-blue-800 cursor-pointer"
              >
                Cambiar foto
                <input
                  id="dropzone-file"
                  type="file"
                  class="hidden"
                  @change="handleFileChange"
                />
              </label>
            </div>

            <!-- Grupo 1: Datos básicos -->
            <div class="space-y-2">
              <div>
                <label class="block text-xs font-medium text-gray-600 mb-1"
                  >Cédula</label
                >
                <input
                  type="text"
                  v-model="formData.cedula"
                  class="max-w-[180px] px-2 py-1 text-sm border border-gray-300 rounded shadow-sm focus:outline-none focus:ring-blue-500 focus:border-blue-500"
                  placeholder="0703686868"
                />
              </div>
              <div>
                <label class="block text-xs font-medium text-gray-600 mb-1"
                  >Nombres</label
                >
                <input
                  type="text"
                  v-model="formData.nombres"
                  class="w-full px-2 py-1 text-sm border border-gray-300 rounded shadow-sm focus:outline-none focus:ring-blue-500 focus:border-blue-500"
                />
              </div>
              <div>
                <label class="block text-xs font-medium text-gray-600 mb-1"
                  >Apellidos</label
                >
                <input
                  type="text"
                  v-model="formData.apellidos"
                  class="w-full px-2 py-1 text-sm border border-gray-300 rounded shadow-sm focus:outline-none focus:ring-blue-500 focus:border-blue-500"
                />
              </div>
            </div>

            <!-- Grupo 2: Datos personales -->
            <div class="grid grid-cols-2 gap-2">
              <div>
                <label class="block text-xs font-medium text-gray-600 mb-1"
                  >Sexo</label
                >
                <select
                  v-model="formData.sexo"
                  class="w-full px-2 py-1 text-sm border border-gray-300 rounded shadow-sm focus:outline-none focus:ring-blue-500 focus:border-blue-500"
                >
                  <option value="masculino">Masculino</option>
                  <option value="femenino">Femenino</option>
                </select>
              </div>
              <div>
                <label class="block text-xs font-medium text-gray-600 mb-1"
                  >F. Nacimiento</label
                >
                <input
                  type="date"
                  v-model="formData.fechaNacimiento"
                  class="w-full px-2 py-1 text-sm border border-gray-300 rounded shadow-sm focus:outline-none focus:ring-blue-500 focus:border-blue-500"
                />
              </div>
              <div>
                <label class="block text-xs font-medium text-gray-600 mb-1"
                  >Estado Civil</label
                >
                <select
                  v-model="formData.estadoCivil"
                  class="w-full px-2 py-1 text-sm border border-gray-300 rounded shadow-sm focus:outline-none focus:ring-blue-500 focus:border-blue-500"
                >
                  <option value="soltero">Soltero</option>
                  <option value="casado">Casado</option>
                  <option value="divorciado">Divorciado</option>
                  <option value="viudo">Viudo</option>
                </select>
              </div>
              <div>
                <label class="block text-xs font-medium text-gray-600 mb-1"
                  >Tipo Sangre</label
                >
                <select
                  v-model="formData.tipoSangre"
                  class="w-full px-2 py-1 text-sm border border-gray-300 rounded shadow-sm focus:outline-none focus:ring-blue-500 focus:border-blue-500"
                >
                  <option value="O+">O+</option>
                  <option value="O-">O-</option>
                  <option value="A+">A+</option>
                  <option value="A-">A-</option>
                  <option value="B+">B+</option>
                  <option value="B-">B-</option>
                  <option value="AB+">AB+</option>
                  <option value="AB-">AB-</option>
                </select>
              </div>
            </div>

            <!-- Grupo 3: Datos laborales -->
            <div class="space-y-2">
              <div>
                <label class="block text-xs font-medium text-gray-600 mb-1"
                  >Contrato</label
                >
                <input
                  type="text"
                  v-model="formData.contrato"
                  class="max-w-[180px] px-2 py-1 text-sm border border-gray-300 rounded shadow-sm focus:outline-none focus:ring-blue-500 focus:border-blue-500"
                  placeholder="CT-2024-001"
                />
              </div>
              <div>
                <label class="block text-xs font-medium text-gray-600 mb-1"
                  >Tipo Contrato</label
                >
                <select
                  v-model="formData.tipoContrato"
                  class="w-full px-2 py-1 text-sm border border-gray-300 rounded shadow-sm focus:outline-none focus:ring-blue-500 focus:border-blue-500"
                >
                  <option value="indefinido">Indefinido</option>
                  <option value="temporal">Temporal</option>
                  <option value="prueba">Prueba</option>
                </select>
              </div>
              <div>
                <label class="block text-xs font-medium text-gray-600 mb-1"
                  >F. Ingreso</label
                >
                <input
                  type="date"
                  v-model="formData.fechaIngreso"
                  class="w-full px-2 py-1 text-sm border border-gray-300 rounded shadow-sm focus:outline-none focus:ring-blue-500 focus:border-blue-500"
                />
              </div>
            </div>
          </div>
        </div>

        <!-- Pestaña Familia -->
        <div v-if="currentTab === 'familia'">
          <div class="mb-4">
            <h3 class="text-lg font-medium text-gray-900 mb-2">
              Información Familiar
            </h3>
            <p class="text-sm text-gray-500">
              Aquí puedes gestionar la información de los familiares del
              empleado.
            </p>
          </div>
          <!-- Contenido específico de familia -->
        </div>

        <!-- Pestaña Referencias -->
        <div v-if="currentTab === 'referencias'">
          <div class="mb-4">
            <h3 class="text-lg font-medium text-gray-900 mb-2">
              Referencias Personales
            </h3>
            <p class="text-sm text-gray-500">
              Información de contactos de referencia para el empleado.
            </p>
          </div>
          <!-- Contenido específico de referencias -->
        </div>

        <!-- Pestaña Fotos -->
        <div v-if="currentTab === 'fotos'">
          <div class="mb-4">
            <h3 class="text-lg font-medium text-gray-900 mb-2">Fotografías</h3>
            <p class="text-sm text-gray-500">
              Gestión de imágenes relacionadas con el empleado.
            </p>
          </div>
          <!-- Contenido específico de fotos -->
        </div>

        <!-- Pestaña Historial -->
        <div v-if="currentTab === 'historial'">
          <div class="mb-4">
            <h3 class="text-lg font-medium text-gray-900 mb-2">
              Historial Laboral
            </h3>
            <p class="text-sm text-gray-500">
              Registro completo de la trayectoria del empleado en la empresa.
            </p>
          </div>
          <!-- Contenido específico de historial -->
        </div>
      </div>
    </div>
  </div>
</template>

<script setup>
import { ref, reactive, computed, watch } from "vue";

// Estado del formulario
const formData = reactive({
  cedula: "",
  nombres: "",
  apellidos: "",
  sexo: "masculino",
  estadoCivil: "soltero",
  instruccion: "primaria",
  tipoSangre: "O+",
  provincia: "",
  parroquia: "",
  direccion: "",
  email: "",
  banco: "banco1",
  cuenta: "",
  contrato: "",
  fechaNacimiento: "",
  pasaporte: "",
  libretaMilitar: "",
  peso: "",
  estatura: "",
  ciudad: "",
  telefono: "",
  celular: "",
  tipo: "tipo1",
  imagenPerfil: null,
  credencial: false,
  fechaIngreso: "",
  tipoContrato: "indefinido",
  pagoRol: "",
  fechaSalida: "",
  area: "area1",
  cargo: "cargo1",
  proyecto: "proyecto1",
  inicioProyecto: "",
  ubicacion: "",
  observacion: "",
  historiaClinica: false,
  discapacitado: false,
  examenPsicologico: false,
  cursoVigilante: false,
  documentacion: false,
  pruebaAntidroga: false,
  conadis: false,
  emisor: "si",
  xiii: "",
  xiv: "",
  fondoReserva: "",
  acumFondoReserva: "",
  sueldo: "",
  extra: "",
  nombreProyecto: "",
  finProyecto: "",
  noEspecificado: "",
});

// Datos para selects
const provincias = ref([
  { id: "p1", nombre: "Pichincha" },
  { id: "p2", nombre: "Guayas" },
  { id: "p3", nombre: "Azuay" },
]);

const parroquias = ref([]);
const ciudades = ref([]);

// Pestañas
const tabs = [
  { id: "datos", name: "Datos", icon: "ri-user-line" },
  { id: "familia", name: "Familia", icon: "ri-group-line" },
  { id: "referencias", name: "Referencias", icon: "ri-contacts-line" },
  { id: "fotos", name: "Fotos", icon: "ri-camera-line" },
  { id: "historial", name: "Historial", icon: "ri-history-line" },
];

const currentTab = ref("datos");

// Métodos
const cargarParroquiasYCiudades = () => {
  if (formData.provincia === "p1") {
    parroquias.value = [
      { id: "par1_p1", nombre: "Parroquia 1 - Pichincha" },
      { id: "par2_p1", nombre: "Parroquia 2 - Pichincha" },
    ];
    ciudades.value = [
      { id: "c1_p1", nombre: "Ciudad 1 - Pichincha" },
      { id: "c2_p1", nombre: "Ciudad 2 - Pichincha" },
    ];
  } else if (formData.provincia === "p2") {
    parroquias.value = [
      { id: "par1_p2", nombre: "Parroquia 1 - Guayas" },
      { id: "par2_p2", nombre: "Parroquia 2 - Guayas" },
    ];
    ciudades.value = [
      { id: "c1_p2", nombre: "Ciudad 1 - Guayas" },
      { id: "c2_p2", nombre: "Ciudad 2 - Guayas" },
    ];
  } else if (formData.provincia === "p3") {
    parroquias.value = [
      { id: "par1_p3", nombre: "Parroquia 1 - Azuay" },
      { id: "par2_p3", nombre: "Parroquia 2 - Azuay" },
    ];
    ciudades.value = [
      { id: "c1_p3", nombre: "Ciudad 1 - Azuay" },
      { id: "c2_p3", nombre: "Ciudad 2 - Azuay" },
    ];
  } else {
    parroquias.value = [];
    ciudades.value = [];
  }
  formData.parroquia = "";
  formData.ciudad = "";
};

const handleFileChange = (event) => {
  const file = event.target.files[0];
  if (file) {
    const reader = new FileReader();
    reader.onload = (e) => {
      formData.imagenPerfil = e.target.result;
    };
    reader.readAsDataURL(file);
  }
};

const edad = computed(() => {
  if (formData.fechaNacimiento) {
    const hoy = new Date();
    const fechaNacimiento = new Date(formData.fechaNacimiento);
    let edadCalculada = hoy.getFullYear() - fechaNacimiento.getFullYear();
    const mes = hoy.getMonth() - fechaNacimiento.getMonth();
    if (mes < 0 || (mes === 0 && hoy.getDate() < fechaNacimiento.getDate())) {
      edadCalculada--;
    }
    return edadCalculada;
  }
  return "";
});

const buscarPersonal = () => {
  console.log("Buscando personal...");
};

const nuevoPersonal = () => {
  console.log("Nuevo personal...");
  // Resetear formulario
  Object.assign(formData, {
    cedula: "",
    nombres: "",
    apellidos: "",
    sexo: "masculino",
    estadoCivil: "soltero",
    instruccion: "primaria",
    tipoSangre: "O+",
    provincia: "",
    parroquia: "",
    direccion: "",
    email: "",
    banco: "banco1",
    cuenta: "",
    contrato: "",
    fechaNacimiento: "",
    pasaporte: "",
    libretaMilitar: "",
    peso: "",
    estatura: "",
    ciudad: "",
    telefono: "",
    celular: "",
    tipo: "tipo1",
    imagenPerfil: null,
    credencial: false,
    fechaIngreso: "",
    tipoContrato: "indefinido",
    pagoRol: "",
    fechaSalida: "",
    area: "area1",
    cargo: "cargo1",
    proyecto: "proyecto1",
    inicioProyecto: "",
    ubicacion: "",
    observacion: "",
    historiaClinica: false,
    discapacitado: false,
    examenPsicologico: false,
    cursoVigilante: false,
    documentacion: false,
    pruebaAntidroga: false,
    conadis: false,
    emisor: "si",
    xiii: "",
    xiv: "",
    fondoReserva: "",
    acumFondoReserva: "",
    sueldo: "",
    extra: "",
    nombreProyecto: "",
    finProyecto: "",
    noEspecificado: "",
  });
};

const guardarPersonal = () => {
  console.log("Guardando personal...", formData);
};

const cancelarEdicion = () => {
  console.log("Cancelando edición...");
};
</script>

<style>
/* Estilos para inputs de fecha */
input[type="date"] {
  appearance: none;
  -webkit-appearance: none;
  display: inline-flex;
  align-items: center;
  padding: 0.5rem;
  border: 1px solid #d1d5db;
  border-radius: 0.375rem;
  width: 100%;
  font-size: 1rem;
  color: #374151;
  line-height: 1.5rem;
  cursor: pointer;
  background-color: #fff;
}

input[type="date"]::-webkit-calendar-picker-indicator {
  display: inline-block;
  cursor: pointer;
  width: 1.5rem;
  height: 1.5rem;
  margin-left: 0.5rem;
  background-image: url('data:image/svg+xml;utf8,<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="feather feather-calendar"><rect x="3" y="4" width="18" height="18" rx="2" ry="2"/><line x1="16" x2="16" y1="2" y2="6"/><line x1="8" x2="8" y1="2" y2="6"/><line x1="3" x2="21" y1="10" y2="10"/></svg>');
}

input[type="date"]:focus {
  border-color: #3b82f6;
  box-shadow: 0 0 0 3px rgba(59, 130, 246, 0.1);
}

input[type="date"] {
  height: 2rem; /* Igual que otros inputs */
  line-height: 1.25rem; /* Para alinear el texto verticalmente */
  appearance: none;
  -webkit-appearance: none;
  background-color: white;
}

/* Estilo para el icono del calendario */
input[type="date"]::-webkit-calendar-picker-indicator {
  padding: 0;
  margin-left: 0.25rem;
  filter: invert(0.5); /* Color más discreto */
}
</style>
