<template>
  <div class="min-h-screen bg-gray-10 p-1">
    
    

    <!-- Barra de acciones superior -->
    <div class="bg-white rounded-lg shadow-md p-3 mb-2 sticky top-0 z-5">
      <div class="flex justify-between items-center">
        <h1 class="text-2xl font-semibold text-gray-800">
          Gestión de Personal
        </h1>
        <div class="flex space-x-2">
          <button
            @click="openSearchModal"
            class="flex items-center px-4 py-2 border border-blue-600 text-blue-600 rounded-lg hover:bg-blue-600 hover:text-white transition-colors"
          >
            <Icon icon="lucide:file-search" class="w-5 h-5 mr-2" /> Buscar
          </button>
          <button
            @click="nuevoPersonal"
            class="flex items-center px-4 py-2 border border-green-600 text-green-600 rounded-lg hover:bg-green-600 hover:text-white transition-colors"
          >
            <Icon icon="lucide:circle-plus" class="w-5 h-5 mr-2" /> Nuevo
          </button>
          <button
            @click="guardarPersonal"
            class="flex items-center px-4 py-2 border border-blue-600 text-blue-600 rounded-lg hover:bg-blue-600 hover:text-white transition-colors"
          >
            
            <Icon icon="lucide:save" class="w-5 h-5 mr-2" /> Guardar
          </button>
          <button
            @click="cancelarEdicion"
            class="flex items-center px-4 py-2 border border-red-700 text-red-700 rounded-lg hover:bg-red-700 hover:text-white transition-colors"
          >
            <Icon icon="material-symbols:cancel-outline" class="w-5 h-5 mr-2" />
            Cancelar
          </button>
        </div>
      </div>
    </div>

    <!-- Pestañas -->
    <div class="bg-white rounded-lg shadow-md overflow-hidden mb-4 ">
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
              <Icon :icon="tab.icon" class="mr-2"></Icon>
              {{ tab.name }}
            </div>
          </button>
        </nav>
      </div>

      <!-- Contenido de las pestañas -->
      <div class="p-6">
        <!-- Pestaña Datos Personales -->
        <div v-if="currentTab === 'datos'">
          <div class="grid grid-cols-1 md:grid-cols-5 gap-4 mb-4">
            <!-- Columna de la foto - Reducida -->
            <div class="space-y-2 flex flex-col -mr-8 ">
              <div class=" relative flex flex-col items-center justify-center">
                <div class="relative w-32 h-32 mr-7">
                  <div
                    v-if="formData.estado_Personal !== undefined"
                    class="absolute inset-0 rounded-full border-[3px] animate-pulse-ring"
                    :class="{
                      'border-green-500': formData.estado_Personal === 1,
                      'border-red-500': formData.estado_Personal === 0,
                      'border-gray-500': formData.estado_Personal === undefined,
                    }"
                  ></div>

                  <div
                    class="relative w-full h-full rounded-full bg-gray-200 mb-2 overflow-hidden border-2 border-white shadow-sm z-10"
                    
                  >
                    <img
                      v-if="formData.foto"
                      :src="formData.foto"
                      class="w-full h-full object-cover"
                      alt="Foto de perfil"
                    />
                    <div
                      v-else
                      class="w-full h-full flex items-center justify-center text-gray-400"
                    >
                      <i class="ri-user-line text-6xl"></i>
                    </div>
                  </div>

                  <label
                    for="dropzone-file"
                    class="  text-xs text-blue-600 hover:text-blue-800 cursor-pointer"
                  >
                    <i class="ri-camera-line text-sm"></i>
                    Cambiar foto
                    <input
                      id="dropzone-file"
                      type="file"
                      class="hidden"
                      @change="handleFileChange"
                    />
                  </label>
                </div>
              </div>
              <div class="pt-11">
                
              <div>
                <label class="block text-xs font-medium text-gray-600 mb-1">Provincia</label
                >
                <input
                  type="text"
                  v-model="formData.provincia"
                  class="w-max-[160px] form-field"
                />
              </div>
              <div class="mt-2">
                <label class="block text-xs font-medium text-gray-600 mb-1"
                  >Banco</label
                >
                <select v-model="formData.banco" 
                class="w-full max-w-[140px] h-8 px-2 text-xs border border-gray-300 rounded shadow-sm focus:outline-none focus:ring-0 focus:ring-blue-500 focus:border-blue-500">
                  <option
                    v-for="banco in bancoStore.bancoOptions"
                    :key="banco.id"
                    :value="banco.id"
                    :label="banco.nombre"
                    class="form-field w-full h-20"
                  >
                    {{ banco.nombre }}
                  </option>
                </select>
              </div>
              <div class="mt-2">
                <label class="block text-xs font-medium text-gray-600 mb-1"
                  >Edad</label
                >
                <input
                  type="number"
                  v-model="formData.edad"
                  class="max-w-[100px] h-8 px-2 text-xs border border-gray-300 rounded shadow-sm focus:outline-none focus:ring-0 focus:ring-blue-500 focus:border-blue-500"
                />
              </div>
              </div>
              
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
                  class="max-w-[130px] h-8 px-2 text-xs border border-gray-300 rounded shadow-sm focus:outline-none focus:ring-0 focus:ring-blue-500 focus:border-blue-500"
                  placeholder="0703686868"
                />
              </div>

              <div>
                <label class="block text-xs font-medium text-gray-600 mb-1"
                  >Id Personal</label
                >
                <input
                  type="text"
                  v-model="formData.idPersonal"
                  class="max-w-[130px] h-8 px-2 text-xs border border-gray-300 rounded shadow-sm focus:outline-none focus:ring-0 focus:ring-blue-500 focus:border-blue-500"
                />
              </div>
              <div>
                <label class="block text-xs font-medium text-gray-600 mb-1"
                  >Email</label
                >
                <input
                  type="email"
                  v-model="formData.email"
                  class="max-w-[160px] form-field"
                />
              </div>
              <div>
                <label class="block text-xs font-medium text-gray-600 mb-1"
                  >Ciudad</label
                >
                <input
                  type="text"
                  v-model="formData.ciudad"
                  class="form-field max-w-[160px]"
                />
              </div>

              <div>
                <label class="block text-xs font-medium text-gray-600 mb-1"
                  >Tipo Cta</label
                >
                <select
                  v-model="formData.tipoCuenta"
                  class="form-field max-w-[160px]"
                >
                  <option value="Corriente">Corriente</option>
                  <option value="Ahorros">Ahorros</option>
                </select>
              </div>
            </div>

            <!-- Grupo 2: Datos personales -->
            <div class="space-y-2">
              <div>
                <label class="block text-xs font-medium text-gray-600 mb-1"
                  >Nombres</label
                >
                <input
                  type="text"
                  v-model="formData.nombres"
                  class="w-max-[160px] form-field"
                />
              </div>
              <div>
                <label class="block text-xs font-medium text-gray-600 mb-1"
                  >Sexo</label
                >
                <select
                  v-model="formData.sexo"
                  class="max-w-[130px] h-8 px-2 text-xs border border-gray-300 rounded shadow-sm focus:outline-none focus:ring-0 focus:ring-blue-500 focus:border-blue-500"
                >
                  <option
                    v-for="option in SexoOption"
                    :key="option.value"
                    :value="option.value"
                  >
                    {{ option.text }}
                  </option>
                </select>
              </div>

              <div>
                <label class="block text-xs font-medium text-gray-600 mb-1"
                  >Peso</label
                >
                <input
                  type="number"
                  v-model="formData.peso"
                  class="max-w-[100px] h-8 px-2 text-xs border border-gray-300 rounded shadow-sm focus:outline-none focus:ring-0 focus:ring-blue-500 focus:border-blue-500"
                />
              </div>
              <div>
                <label class="block text-xs font-medium text-gray-600 mb-1"
                  >Parroquia</label
                >
                <input
                  type="text"
                  v-model="formData.parroquia"
                  class="form-field max-w-[160px]"
                />
              </div>
              <div>
                <label class="block text-xs font-medium text-gray-600 mb-1"
                  >CTA Banco</label
                >
                <input
                  type="text"
                  v-model="formData.cuentaBanco"
                  class="form-field max-w-[160px]"
                />
              </div>
            </div>

            <!-- Grupo 3: Datos laborales -->
            <div class="space-y-2">
              <div>
                <label class="block text-xs font-medium text-gray-600 mb-1"
                  >Apellidos</label
                >
                <input
                  type="text"
                  v-model="formData.apellidos"
                  class="w-max-[160px] form-field"
                />
              </div>
              <div>
                <label class="block text-xs font-medium text-gray-600 mb-1"
                  >Estado Civil</label
                >
                <select
                  v-model="formData.estadoCivil"
                  class="w-max-[180px] h-8 px-2 text-xs border border-gray-300 rounded shadow-sm focus:outline-none focus:ring-blue-500 focus:border-blue-500"
                >
                  <option
                    v-for="option in maritalStatus"
                    :key="option.value"
                    :value="option.value"
                  >
                    {{ option.text }}
                  </option>
                </select>
              </div>
              <div>
                <label class="block text-xs font-medium text-gray-600 mb-1"
                  >Estatura</label
                >
                <input
                  type="number"
                  v-model="formData.estatura"
                  class="max-w-[100px] h-8 px-2 text-xs border border-gray-300 rounded shadow-sm focus:outline-none focus:ring-0 focus:ring-blue-500 focus:border-blue-500"
                />
              </div>
              <div>
                <label class="block text-xs font-medium text-gray-600 mb-1"
                  >Teléfono</label
                >
                <input
                  type="tel"
                  v-model="formData.telefono"
                  class="max-w-[100px] h-8 px-2 text-xs border border-gray-300 rounded shadow-sm focus:outline-none focus:ring-0 focus:ring-blue-500 focus:border-blue-500"
                />
              </div>

              <div>
                <label class="block text-xs font-medium text-gray-600 mb-1"
                  >Celular</label
                >
                <input
                  type="tel"
                  v-model="formData.celular"
                  class="max-w-[100px] h-8 px-2 text-xs border border-gray-300 rounded shadow-sm focus:outline-none focus:ring-0 focus:ring-blue-500 focus:border-blue-500"
                />
              </div>
            </div>

            <!-- Grupo 4: Datos de contacto -->
            <div class="space-y-2">
              <div>
                <label class="block text-xs font-medium text-gray-600 mb-1"
                  >F. Nacimiento</label
                >
                <input
                  type="date"
                  v-model="formData.fechaNacimiento"
                  class="w-max-[160px] appearance-none h-8 px-2 text-xs border border-gray-300 rounded shadow-sm focus:outline-none focus:ring-0 focus:ring-blue-500 focus:border-blue-500"
                />
              </div>
              <div>
                <label class="block text-xs font-medium text-gray-600 mb-1"
                  >Instrucción Primaria</label
                >
                <select
                  v-model="formData.instruccion"
                  class="form-field max-w-[160px]"
                >
                  <option
                    v-for="option in educationlevel"
                    :key="option.value"
                    :value="option.value"
                  >
                    {{ option.text }}
                  </option>
                </select>
              </div>

              <div>
                <label class="block text-xs font-medium text-gray-600 mb-1"
                  >Tipo Sangre</label
                >
                <select
                  v-model="formData.tipoSangre"
                  class="w-max-[180px] h-8 px-2 text-xs border border-gray-300 rounded shadow-sm focus:outline-none focus:ring-0 focus:ring-blue-500 focus:border-blue-500"
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

              <div>
                <label class="block text-xs font-medium text-gray-600 mb-1"
                  >Contrato</label
                >
                <input
                  type="tel"
                  v-model="formData.nroContrato"
                  class="max-w-[100px] h-8 px-2 text-xs border border-gray-300 rounded shadow-sm focus:outline-none focus:ring-0 focus:ring-blue-500 focus:border-blue-500"
                />
              </div>

              <div>
                <label class="block text-xs font-medium text-gray-600 mb-1"
                  >Credencial</label
                >
                <input
                  type="checkbox"
                  v-model="formData.credencial"
                  class="w-4 h-4 p-0"
                />
              </div>
            </div>
          </div>
          <div class="grid grid-cols-1 md:grid-cols-5 gap-4 mb-4">
            <!-- Dirección - Ocupa 2 columnas -->
            <div class="md:col-span-3 py-0">
              <label class="block text-xs font-medium text-gray-600 mb-1"
                >Dirección</label
              >
              <input
                type="text"
                v-model="formData.direccion"
                class="w-full h-8 px-2 text-xs border border-gray-300 rounded shadow-sm focus:outline-none focus:ring-0 focus:ring-blue-500 focus:border-blue-500"
              />
            </div>
            <div class="space-y-2">
              <div>
                <label class="block text-xs font-medium text-gray-600 mb-1"
                  >Lib Militar</label
                >
                <input
                  type="text"
                  v-model="formData.libretaMilitar"
                  class="max-w-[130px] h-8 px-2 text-xs border border-gray-300 rounded shadow-sm focus:outline-none focus:ring-0 focus:ring-blue-500 focus:border-blue-500"
                />
              </div>
            </div>
            <div class="space-y-2">
              <div>
                <label class="block text-xs font-medium text-gray-600 mb-1"
                  >Pasaporte</label
                >
                <input
                  type="text"
                  v-model="formData.pasaporte"
                  class="max-w-[130px] h-8 px-2 text-xs border border-gray-300 rounded shadow-sm focus:outline-none focus:ring-0 focus:ring-blue-500 focus:border-blue-500"
                />
              </div>
            </div>
          </div>
          <!-- Seccion Operativa -->
          <div class="">
            <h2 class="text-lg font-medium text-gray-900 mb-2">
              Información Operativa
            </h2>
          </div>
          <div class="grid grid-cols-1 md:grid-cols-5 gap-4 mb4">
            <!-- Columna 1 -->
            <div class="space-y-2">
              <div>
                <label class="block text-xs font-medium text-gray-600 mb-1"
                  >Ingreso</label
                >
                <input
                  type="date"
                  v-model="formData.fechaEntrada"
                  class="form-field w-full"
                />
              </div>
              <div>
                <label class="block text-xs font-medium text-gray-600 mb-1"
                  >Proyecto</label
                >
                <select v-model="formData.proyecto" class="form-field w-full">
                  <option
                    v-for="proyecto in proyectoDisponible"
                    :key="proyecto.id"
                    :value="proyecto.id"
                    :label="proyecto.nombre"
                    class="form-field w-full h-20"
                  >
                    {{ proyecto.nombre }}
                  </option>
                </select>
              </div>
              <div>
                <label class="block text-xs font-medium text-gray-600 mb-1"
                  >Ubicacion</label
                >
                <select
                  v-model="formData.sitio"
                  class="form-field w-full text-xs"
                >
                  <option
                    v-for="sitio in sitiosDisponibles"
                    :key="sitio.id"
                    :value="sitio.id"
                  >
                    {{ sitio.nombre }}
                  </option>
                </select>
              </div>
            </div>

            <!-- Columna 2 -->
            <div class="space-y-2">
              <div>
                <label class="block text-xs font-medium text-gray-600 mb-1">
                  Fecha de salida
                </label>
                <div
                  v-if="formData.fechaSalida === 'en_funciones'"
                  class="form-field w-full bg-gray-100 italic text-gray-500 text-center"
                >
                  En funciones
                </div>
                <input
                  v-else
                  type="date"
                  v-model="formData.fechaSalida"
                  class="form-field w-full"
                />
              </div>
              <div>
                <label class="block text-xs font-medium text-gray-600 mb-1"
                  >Inicio Pro</label
                >
                <input
                  type="date"
                  v-model="formData.fechaInicio"
                  class="form-field w-full"
                />
              </div>

              <div>
                <label class="block text-xs font-medium text-gray-600 mb-1"
                  >Área</label
                >
                <select
                  v-model="formData.area"
                  class="form-field w-full text-xs"
                >
                  <option
                    v-for="area in areaStore.areasOptions"
                    :key="area.id"
                    :value="area.id"
                  >
                    {{ area.nombre }}
                  </option>
                </select>
              </div>
            </div>

            <!-- Columna 3 -->
            <div class="space-y-2">
              <div>
                <label class="block text-xs font-medium text-gray-600 mb-1"
                  >Cargo</label
                >
                <select
                  v-model="formData.cargo"
                  class="form-field w-full text-xs"
                >
                  <option
                    v-for="cargo in cargoStore.cargoOptions"
                    :key="cargo.id"
                    :value="cargo.id"
                  >
                    {{ cargo.nombre }}
                  </option>
                </select>
              </div>
              <div>
                <label class="block text-xs font-medium text-gray-600 mb-1"
                  >Fin Pro</label
                >
                <input
                  type="date"
                  v-model="formData.fechaFin"
                  class="form-field w-full"
                />
              </div>
              <div>
                <label class="block text-xs font-medium text-gray-600 mb-1"
                  >Observación</label
                >
                <textarea
                  v-model="formData.observaciones"
                  class="form-field w-full"
                ></textarea>
              </div>
            </div>

            <!-- Columna 4 -->
            <div class="space-y-2">
              <div>
                <label class="block text-xs font-medium text-gray-600 mb-1"
                  >Tipo Contrato</label
                >
                <select
                  v-model="formData.tipoContrato"
                  class="form-field w-full"
                >
                  <option
                    v-for="option in tipoContratoSelect"
                    :key="option.value"
                    :value="option.value"
                  >
                    {{ option.text }}
                  </option>
                </select>
              </div>
              <div class="flex items-center gap-2">
                <input
                  type="checkbox"
                  v-model="formData.iess"
                  class="h-4 w-4 text-blue-600 border-gray-300 rounded focus:ring-blue-500"
                  id="afiliadoIESS"
                />
                <label
                  class="text-xs font-medium text-gray-600 cursor-pointer"
                  for="afiliadoIESS"
                >
                  Afiliado IESS
                </label>
              </div>
              <!-- Fecha de Afiliación (siempre visible) -->
              <div>
                <label class="block text-xs font-medium text-gray-600 mb-1"
                  >Fecha Afiliación</label
                >
                <input
                  type="date"
                  v-model="formData.fechaAfiliacion"
                  :disabled="!formData.afiliadoIESS"
                  class="form-field w-full"
                  :class="{
                    'opacity-50 cursor-not-allowed': !formData.afiliadoIESS,
                  }"
                />
              </div>

              <!-- XIII Sueldo (siempre visible) -->
              <div class="flex items-center gap-2">
                <input
                  type="checkbox"
                  v-model="formData.xiii"
                  :disabled="!formData.afiliadoIESS"
                  class="h-4 w-4 text-blue-600 border-gray-300 rounded focus:ring-blue-500"
                  :class="{
                    'opacity-50 cursor-not-allowed': !formData.afiliadoIESS,
                  }"
                  id="XIII"
                />
                <label
                  class="text-xs font-medium text-gray-600 cursor-pointer"
                  for="XIII"
                >
                  XIII Sueldo
                </label>
              </div>

              <!-- XIV Sueldo (siempre visible) -->
              <div class="flex items-center gap-2">
                <input
                  type="checkbox"
                  v-model="formData.xiv"
                  :disabled="!formData.afiliadoIESS"
                  class="h-4 w-4 text-blue-600 border-gray-300 rounded focus:ring-blue-500"
                  :class="{
                    'opacity-50 cursor-not-allowed': !formData.afiliadoIESS,
                  }"
                  id="XIV"
                />
                <label
                  class="text-xs font-medium text-gray-600 cursor-pointer"
                  for="XIV"
                >
                  XIV Sueldo
                </label>
              </div>

              <!-- Fondo de Reserva (siempre visible) -->
              <div class="flex items-center gap-2">
                <input
                  type="checkbox"
                  v-model="formData.reservaRol"
                  :disabled="!formData.afiliadoIESS"
                  class="h-4 w-4 text-blue-600 border-gray-300 rounded focus:ring-blue-500"
                  :class="{
                    'opacity-50 cursor-not-allowed': !formData.afiliadoIESS,
                  }"
                  id="fondoReserva"
                />
                <label
                  class="text-xs font-medium text-gray-600 cursor-pointer"
                  for="fondoReserva"
                >
                  Fondo de Reserva
                </label>
              </div>

              <!-- Acumulado Fondo Reserva (siempre visible) -->
              <div class="flex items-center gap-2">
                <input
                  type="checkbox"
                  v-model="formData.acumFondoReserva"
                  :disabled="!formData.afiliadoIESS"
                  class="h-4 w-4 text-blue-600 border-gray-300 rounded focus:ring-blue-500"
                  :class="{
                    'opacity-50 cursor-not-allowed': !formData.afiliadoIESS,
                  }"
                  id="acumFondoReserva"
                />
                <label
                  class="text-xs font-medium text-gray-600 cursor-pointer"
                  for="acumFondoReserva"
                >
                  Acumulado F. Reserva
                </label>
              </div>
            </div>

            <!-- Columna 5 -->
            <div class="space-y-2">
              <div>
                <label class="block text-xs font-medium text-gray-600 mb-1"
                  >Prueba Antidroga</label
                >
                <select
                  v-model="formData.pruebaAntidroga"
                  class="form-field w-full"
                >
                  <option
                    v-for="option in pruebaAntidrogaSelect"
                    :key="option.value"
                    :value="option.value"
                  >
                    {{ option.text }}
                  </option>
                </select>
              </div>
              <div class="flex items-center gap-2">
                <input
                  type="checkbox"
                  v-model="formData.historiaClinica"
                  class="h-4 w-4 text-blue-600 border-gray-300 rounded"
                  id="historiaClinica"
                />
                <label
                  class="text-xs font-medium text-gray-600"
                  for="historiaClinica"
                  >Historia Clínica</label
                >
              </div>
              <div class="flex flex-col gap-1">
                <div class="flex items-center gap-2">
                  <input
                    type="checkbox"
                    v-model="formData.discapacitado"
                    class="h-4 w-4 text-blue-600 border-gray-300 rounded focus:ring-blue-500"
                    id="discapacitado"
                  />
                  <label
                    class="text-xs font-medium text-gray-600 cursor-pointer"
                    for="discapacitado"
                    >Discapacitado</label
                  >
                </div>
                <input
                  v-if="formData.discapacitado"
                  type="text"
                  v-model="formData.discapacitadoDetalle"
                  class="w-full h-8 px-2 text-xs border border-gray-300 rounded shadow-sm focus:outline-none focus:ring-0 focus:ring-blue-500 focus:border-blue-500 ml-6"
                  placeholder="Número o serie"
                />
              </div>

              <!-- Examen Psicológico (checkbox + input condicional) -->
              <div class="flex flex-col gap-1">
                <div class="flex items-center gap-2">
                  <input
                    type="checkbox"
                    v-model="formData.examenPsicologico"
                    class="h-4 w-4 text-blue-600 border-gray-300 rounded focus:ring-blue-500"
                    id="examenPsicologico"
                  />
                  <label
                    class="text-xs font-medium text-gray-600 cursor-pointer"
                    for="examenPsicologico"
                    >Examen Psicológico</label
                  >
                </div>
                <input
                  v-if="formData.examenPsicologico"
                  type="text"
                  v-model="formData.examenPsicologicoDetalle"
                  class="w-full h-8 px-2 text-xs border border-gray-300 rounded shadow-sm focus:outline-none focus:ring-0 focus:ring-blue-500 focus:border-blue-500 ml-6"
                  placeholder="Número o serie"
                />
              </div>

              <!-- Curso Vigilante (checkbox + input condicional) -->
              <div class="flex flex-col gap-1">
                <div class="flex items-center gap-2">
                  <input
                    type="checkbox"
                    v-model="formData.cursoVigilante"
                    class="h-4 w-4 text-blue-600 border-gray-300 rounded focus:ring-blue-500"
                    id="cursoVigilante"
                  />
                  <label
                    class="text-xs font-medium text-gray-600 cursor-pointer"
                    for="cursoVigilante"
                    >Curso Vigilante</label
                  >
                </div>
                <input
                  v-if="formData.cursoVigilante"
                  type="text"
                  v-model="formData.cursoVigilanteDetalle"
                  class="w-full h-8 px-2 text-xs border border-gray-300 rounded shadow-sm focus:outline-none focus:ring-0 focus:ring-blue-500 focus:border-blue-500 ml-6"
                  placeholder="Número o serie"
                />
              </div>
            </div>
          </div>

          <!-- --- -->
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
          </div>
          <div v-if="loadingHistorial" class="flex justify-center py-4">
            <Icon
              icon="svg-spinners:6-dots-scale"
              class="text-blue-500 text-2xl"
            />
          </div>
          <div v-else class="overflow-x-auto bg-white rounded-lg shadow">
            <table class="min-w-full divide-y divide-gray-200">
              <thead class="bg-gray-50">
                <tr>
                  <th
                    class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase"
                  >
                    Fecha
                  </th>
                  <th
                    class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase"
                  >
                    Detalle
                  </th>
                </tr>
              </thead>
              <tbody class="divide-y divide-gray-200">
                <tr v-for="(item, index) in historialLaboral" :key="index">
                  <td class="px-6 py-4 whitespace-nowrap text-sm text-gray-500">
                    {{ toDateInputFormat(item.fechaHistoriaLaboral) }}
                  </td>
                  <td class="px-6 py-4 text-xs text-gray-500">
                    {{ item.detalleHistoriaLaboral }}
                  </td>
                </tr>
                <tr v-if="historialLaboral.length === 0">
                  <td
                    colspan="2"
                    class="px-6 py-4 text-center text-sm text-gray-500"
                  >
                    No hay registros de historial laboral
                  </td>
                </tr>
              </tbody>
            </table>
          </div>
        </div>
      </div>
    </div>
    <SearchModal
      :show="showSearchModal"
      :items="searchResults"
      :current-page="currentPage"
      :items-per-page="itemsPerPage"
      :total-items="totalItems"
      :total-pages="totalPages"
      :is-loading="isLoading"
      :page-size-options="pageSizeOptions"
      @search="
        (term) => {
          buscarPersonal(term);
        }
      "
      @close="showSearchModal = false"
      @select="loadEmployee"
      @page-change="handlePageChange"
      @change-page-size="handlePageSizeChange"
    />
  </div>
</template>

<script setup>
import { ref, reactive, onMounted } from "vue";
import { useAuthStore } from "@/stores/auth.store";
import SearchModal from "@/components/Personal/SearchModal.vue";
import { personalService } from "@/api/RRHH/personal";
import { useAreaStore } from "../../stores/MasterData/area.store";
import { useBancoStore } from "../../stores/MasterData/banco.store";
import { useCargoStore } from "../../stores/MasterData/cargo.store";
import { useContratoStore } from "../../stores/MasterData/contrato.store";
import { useSitioStore } from "../../stores/MasterData/sitio.store";
import { historialService } from "@/api/RRHH/historial";
import { cuentaPersonalService } from "@/api/RRHH/cuentaPersonal";
import { Icon } from "@iconify/vue";
import { push } from "notivue";
// Estados de busqueda y paginacion
const authStore = useAuthStore();
const searchQuery = ref("");
const tipoConexion = authStore.selectedCompany;
const showSearchModal = ref(false);
const isLoading = ref(false);
const searchResults = ref([]);
const currentPage = ref(1);
const itemsPerPage = ref(20);
const totalItems = ref(0);
const totalPages = ref(0);
const pageSizeOptions = ref([10, 20, 50, 100]);
const areaStore = useAreaStore();
const bancoStore = useBancoStore();
const cargoStore = useCargoStore();
const contratoStore = useContratoStore();
const sitiosStore = useSitioStore();

const historialLaboral = ref([]);
const loadingHistorial = ref(false);


//carga Areas, Cargos, Proyectos, sitios al montar el componente
onMounted(async () => {
  try {
    

    await areaStore.fetchAreas(tipoConexion, false);        
    await bancoStore.fetchBancos(tipoConexion);
    await cargoStore.fetchCargos(tipoConexion);
    await contratoStore.fetchContratos(tipoConexion);
    await sitiosStore.fetchSitios(tipoConexion);
    


  } catch (error) {
    push.error("Error al cargar servicios: ", {
      title: "Error",
      message: error.message || "Ocurrió un error al cargar servicios.",
    });
  }
});

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
  area: "",
  cargo: "cargo1",
  proyecto: "proyecto1",
  inicioProyecto: "",
  sitio: "",
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

// Historial
const loadHistorial = async (idPersona) => {
  try {
    loadingHistorial.value = true;
    const response = await historialService.getHistorialPersonal(
      tipoConexion,
      idPersona
    );
    historialLaboral.value = response.data || [];
  } catch (error) {
    push.error({
      title: "Error al cargar historial",
      message: error.message || "Ocurrió un error al cargar el historial laboral.",
    });
  } finally {
    loadingHistorial.value = false;
  }
};
// Pestañas
const tabs = [
  { id: "datos", name: "Datos", icon: "lucide:user" },
  { id: "fotos", name: "Fotos", icon: "lucide:camera" },
  { id: "historial", name: "Historial", icon: "lucide:history" },
];

const currentTab = ref("datos");

// Métodos

const handlePageChange = (newPage) => {
  currentPage.value = newPage;
  buscarPersonal();
};

const handlePageSizeChange = (newSize) => {
  itemsPerPage.value = newSize;
  currentPage.value = 1; // Reiniciar a la primera página
  buscarPersonal();
};

const openSearchModal = () => {
  showSearchModal.value = true;
  searchQuery.value = null; // Limpiar la consulta de búsqueda
};

const changePageSize = (newSize) => {
  itemsPerPage.value = newSize;
  currentPage.value = 1; // Reiniciar a la primera página
  buscarPersonal(searchQuery.value);
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

const guardarPersonal = () => {
  console.log("Guardando personal...", formData);
};

const cancelarEdicion = () => {
  console.log("Cancelando edición...");
};

// Métodos del modal
const buscarPersonal = async (searchTerm = null) => {
  showSearchModal.value = true;
  isLoading.value = true;

  if (searchTerm !== null) {
    searchQuery.value = searchTerm;
  }

  try {
    const response = await personalService.getPersonal(
      tipoConexion,
      searchQuery.value,
      currentPage.value,
      itemsPerPage.value
    );
    searchResults.value = response.data;
    totalItems.value = response.pagination?.totalRecords || 0;
    totalPages.value = response.pagination?.totalPages || 0;
  } catch (error) {
    push.error({
      title: "Error al buscar personal",
      message: error.message || "Ocurrió un error al buscar personal.",
    });
    // Usa tu sistema de notificaciones (ej: toast)
  } finally {
    isLoading.value = false;
  }
};

const toDateInputFormat = (dateString) => {
  if (!dateString) return "";

  const date = new Date(dateString);
  if (isNaN(date.getTime())) return "";

  return date.toISOString().split("T")[0]; // Formato yyyy-MM-dd
};



const blobToDataURL = async (blobData) => {
  // Si es un Buffer (Node.js) o Blob (navegador)
  if (typeof blobData === "string" && blobData.startsWith("data:image")) {
    return blobData;
  }

  // Si es un string base64 sin prefijo (como el que recibes del backend)
  if (typeof blobData === "string" && blobData.startsWith("/9j")) {
    return `data:image/jpeg;base64,${blobData}`;
  }

  // Si es un Buffer o Blob (código original)
  const blob = new Blob([blobData], { type: "image/jpeg" });
  return new Promise((resolve) => {
    const reader = new FileReader();
    reader.onload = () => resolve(reader.result);
    reader.readAsDataURL(blob);
  });
};

const loadEmployee = async (employee) => {
  try {
    Object.keys(formData).forEach((key) => {
      formData[key] = ""; // Limpia el formulario
    });

    const sitioNumerico = parseInt(employee.ubicacion, 10);
    const sitioValido = sitiosDisponibles.value.find((s) => s.id === sitioNumerico);
    
    Object.assign(formData, {
      idPersonal: employee.id_Personal,
      cedula: employee.cedula,
      nombres: employee.nombres,
      apellidos: employee.apellidos,
      sexo: employee.sexo,
      estadoCivil: employee.estado_Civil?.toUpperCase(),
      instruccion: employee.instruccion?.toUpperCase(),
      tipoSangre: employee.tipo_Sangre,
      provincia: employee.provincia,
      parroquia: employee.parroquia,
      direccion: employee.direccion,
      edad: employee.edad,
      email: employee.email,
      fechaNacimiento: toDateInputFormat(employee.fecha_Nacimiento),
      libretaMilitar: employee.libreta_Militar,
      pasaporte: employee.pasaporte,
      estado_Personal: employee.estado_Personal,
      peso: employee.peso,
      estatura: employee.estatura,
      ciudad: employee.ciudad,
      telefono: employee.telefono,
      celular: employee.movil,
      sitio: sitioValido ? sitioValido.id : "",
      pruebaAntidroga: employee.prueba_Antidroga,
      fechaEntrada: toDateInputFormat(employee.fecha_Entrada),
      fechaSalida:
        employee.estado_Personal === 1
          ? "en_funciones"
          : toDateInputFormat(employee.fecha_Salida),
      foto: employee.foto ? await blobToDataURL(employee.foto) : null,
    });
    

    
    const [cuentasResponse, contratoResponse] = await Promise.all([
    cuentaPersonalService.getCuentaPersonal(tipoConexion, employee.id_Personal)
    .catch(error => {
      push.error({
        title: "Error al cargar cuentas bancarias",
        message: error.message || "Ocurrió un error al cargar las cuentas bancarias.",
      });
      return { success: false, data: [] };
    }),
    personalService.getPersonalContrato(tipoConexion,employee.id_Personal)
    .catch(error => {
      push.error({
        title: "Error al cargar contrato",
        message: error.message || "Ocurrió un error al cargar el contrato.",
      });
      return { success: false, data: null };
    }),
  ]);
    // Cargar datos de la cuenta bancaria
    if (cuentasResponse?.success && cuentasResponse.data) {
       const cuenta = cuentasResponse.data[0];
      formData.banco = cuenta.idBanco;
      formData.cuentaBanco = cuenta.numCuenta ? cuenta.numCuenta : "";
      formData.tipoCuenta = cuenta.tipoCuenta  === "AHO       " ? "Ahorros" : "Corriente";
    }

    console.log("Datos de la cuenta bancaria:", formData.banco, formData.cuentaBanco, formData.tipoCuenta);
    console.log("Datos del contrato:", contratoResponse.data);
    // Cargar datos del contrato
    if (contratoResponse?.success && contratoResponse.data) {
      //area
      const areaContrato = contratoResponse.data.area;
      const areaEncontrada = areaStore.areas.find(
        (a) => a.nombre === areaContrato
      );
      //cargo
      const cargoContrato = contratoResponse.data.descripcion;
      const cargoEncontrado = cargoDisponibles.value.find(
        (c) => c.nombre === cargoContrato
      );
      //contrato
      const proyectoId = contratoResponse.data.idProyecto;
      let proyectoEncontrado = proyectoDisponible.value.find(
        (p) => p.id === proyectoId
      );
      if (!proyectoEncontrado) {
        // Si no se encuentra el proyecto, intenta cargar todos los proyectos
        proyectoEncontrado = todosProyectoCache.find(
          (p) => p.id === proyectoId
        );
      }    
      
      Object.assign(formData, {
        nroContrato: contratoResponse.data.nroContrato,
        area: areaEncontrada ? areaEncontrada.id : "",
        cargo: cargoEncontrado ? cargoEncontrado.id : "",
        proyecto: proyectoEncontrado ? proyectoEncontrado.id : "",

        fechaInicio: toDateInputFormat(contratoResponse.data.fechaInicio),
        fechaFin: toDateInputFormat(contratoResponse.data.fechaFin),
        periodo: contratoResponse.data.periodo,
        tipoContrato: contratoResponse.data.tipoContrato,
        estadoContrato: contratoResponse.data.estado,
        iess: contratoResponse.data.iess === 1,
        fechaAfiliacion: toDateInputFormat(
          contratoResponse.data.fechaAfiliacion
        ),
        reservaRol: contratoResponse.data.reservaRol === 1,
        acumFondoReserva: contratoResponse.data.acu_fondo === 1,
        xiii: contratoResponse.data.xiii === 1,
        xiv: contratoResponse.data.xiv === 1,
        observaciones: contratoResponse.data.observaciones,
        rec_Extra: contratoResponse.data.rec_Extra === 1,
        acu_fondo: contratoResponse.data.acu_fondo === 1,
        desc_Seg: contratoResponse.data.desc_Seg === 1,
        idProyecto: contratoResponse.data.idProyecto,
        sueldo: contratoResponse.data.sueldo,
      });
    }
    
    await loadHistorial(employee.id_Personal);
    // Actualiza formData
    showSearchModal.value = false;
    currentTab.value = "datos";
    
  } catch (error) {
       push.error({
      title: "Error al cargar personal",
      message: error.message || "Ocurrió un error al cargar personal.",
    });

    showSearchModal.value = false;
  }
};

</script>

<style>
/* Estilos para inputs de fecha */
@keyframes pulse-ring {
  0% {
    transform: scale(0.8);
    opacity: 0.8;
  }
  80%,
  100% {
    transform: scale(1.2);
    opacity: 0;
  }
}

.animate-pulse-ring {
  top: 0;
  left: 0;
  animation: pulse-ring 2s linear infinite;
  pointer-events: none; /* Evita interferencias con clics */
}
input[type="date"]::-webkit-calendar-picker-indicator {
  display: inline-block;
  cursor: pointer;
  font-size: x-small;
  @apply h-4 w-4;
  margin-left: 0.5rem;
  background-image: url('data:image/svg+xml;utf8,<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="feather feather-calendar"><rect x="3" y="4" width="18" height="18" rx="2" ry="2"/><line x1="16" x2="16" y1="2" y2="6"/><line x1="8" x2="8" y1="2" y2="6"/><line x1="3" x2="21" y1="10" y2="10"/></svg>');
}

/* Estilo para el icono del calendario */
input[type="date"]::-webkit-calendar-picker-indicator {
  padding: 0;
  margin-left: 0.25rem;
  filter: invert(0.5); /* Color más discreto */
}

.form-field {
  @apply h-8 px-2 text-xs border border-gray-300 rounded shadow-sm
         focus:outline-none focus:ring-0 focus:ring-blue-500 focus:border-blue-500;
}
</style>
