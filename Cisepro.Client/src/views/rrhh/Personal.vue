<template>
  <div class="min-h-screen bg-gray-10 p-4">
    <!-- Barra de acciones superior -->
    <div class="bg-white rounded-lg shadow-md p-4 mb-2 sticky top-0 z-10">
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
            class="flex items-center px-4 py-2 border border-blue-600 text-blue-600 rounded-lg hover:bg-blue-600 hover:text-white transition-colors"
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
          <div class="grid grid-cols-1 md:grid-cols-5 gap-4 mb-4">
            <!-- Columna de la foto - Reducida -->
            <div class="space-y-2">
              <div class="flex flex-col items-center justify-center">
                <div
                  class="w-20 h-20 rounded-full bg-gray-200 mb-2 overflow-hidden border-2 border-white shadow-sm"
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

              <div class="py-1">
                <label class="block text-xs font-medium text-gray-600 mb-1"
                  >Edad</label
                >
                <input
                  type="number"
                  v-model="formData.edad"
                  class="max-w-[100px] h-8 px-2 text-xs border border-gray-300 rounded shadow-sm focus:outline-none focus:ring-1 focus:ring-blue-500 focus:border-blue-500"
                />
              </div>
              <div>
                <label class="block text-xs font-medium text-gray-600 mb-1"
                  >Provincia</label
                >
                <input
                  type="text"
                  v-model="formData.provincia"
                  class="w-max-[160px] form-field"
                />
              </div>
              <div>
                <label class="block text-xs font-medium text-gray-600 mb-1"
                  >Banco</label
                >
                <select v-model="formData.banco" class="form-field">
                  <option>Banco Pichincha</option>
                  <option>Banco Machala</option>
                </select>
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
                  class="max-w-[130px] h-8 px-2 text-xs border border-gray-300 rounded shadow-sm focus:outline-none focus:ring-1 focus:ring-blue-500 focus:border-blue-500"
                  placeholder="0703686868"
                />
              </div>

              <div>
                <label class="block text-xs font-medium text-gray-600 mb-1"
                  >Pasaporte</label
                >
                <input
                  type="text"
                  v-model="formData.pasaporte"
                  class="max-w-[130px] h-8 px-2 text-xs border border-gray-300 rounded shadow-sm focus:outline-none focus:ring-1 focus:ring-blue-500 focus:border-blue-500"
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
                  v-model="formData.tipoCta"
                  class="form-field max-w-[160px]"
                >
                  <option>Corriente</option>
                  <option>Ahorros</option>
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
                  class="max-w-[130px] h-8 px-2 text-xs border border-gray-300 rounded shadow-sm focus:outline-none focus:ring-1 focus:ring-blue-500 focus:border-blue-500"
                >
                  <option value="masculino">Masculino</option>
                  <option value="femenino">Femenino</option>
                </select>
              </div>

              <div>
                <label class="block text-xs font-medium text-gray-600 mb-1"
                  >Peso</label
                >
                <input
                  type="number"
                  v-model="formData.peso"
                  class="max-w-[100px] h-8 px-2 text-xs border border-gray-300 rounded shadow-sm focus:outline-none focus:ring-1 focus:ring-blue-500 focus:border-blue-500"
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
                  v-model="formData.ctaBanco"
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
                  <option value="soltero">Soltero</option>
                  <option value="casado">Casado</option>
                  <option value="divorciado">Divorciado</option>
                  <option value="viudo">Viudo</option>
                </select>
              </div>
              <div>
                <label class="block text-xs font-medium text-gray-600 mb-1"
                  >Estatura</label
                >
                <input
                  type="number"
                  v-model="formData.estatura"
                  class="max-w-[100px] h-8 px-2 text-xs border border-gray-300 rounded shadow-sm focus:outline-none focus:ring-1 focus:ring-blue-500 focus:border-blue-500"
                />
              </div>
              <div>
                <label class="block text-xs font-medium text-gray-600 mb-1"
                  >Teléfono</label
                >
                <input
                  type="tel"
                  v-model="formData.telefono"
                  class="max-w-[100px] h-8 px-2 text-xs border border-gray-300 rounded shadow-sm focus:outline-none focus:ring-1 focus:ring-blue-500 focus:border-blue-500"
                />
              </div>

              <div>
                <label class="block text-xs font-medium text-gray-600 mb-1"
                  >Celular</label
                >
                <input
                  type="tel"
                  v-model="formData.telefono"
                  class="max-w-[100px] h-8 px-2 text-xs border border-gray-300 rounded shadow-sm focus:outline-none focus:ring-1 focus:ring-blue-500 focus:border-blue-500"
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
                  class="w-max-[160px] appearance-none h-8 px-2 text-xs border border-gray-300 rounded shadow-sm focus:outline-none focus:ring-1 focus:ring-blue-500 focus:border-blue-500"
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
                  <option>Primaria</option>
                  <option>Secundaria</option>
                  <option>Bachiller</option>
                  <option>Universidad</option>
                  <option>Universidad Incompleta</option>
                  <option>Ninguna</option>
                </select>
              </div>

              <div>
                <label class="block text-xs font-medium text-gray-600 mb-1"
                  >Tipo Sangre</label
                >
                <select
                  v-model="formData.tipoSangre"
                  class="w-max-[180px] h-8 px-2 text-xs border border-gray-300 rounded shadow-sm focus:outline-none focus:ring-1 focus:ring-blue-500 focus:border-blue-500"
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
            <div class="md:col-span-2 py-0">
              <label class="block text-xs font-medium text-gray-600 mb-1"
                >Dirección</label
              >
              <input
                type="text"
                v-model="formData.direccion"
                class="w-full h-8 px-2 text-xs border border-gray-300 rounded shadow-sm focus:outline-none focus:ring-1 focus:ring-blue-500 focus:border-blue-500"
              />
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
                  v-model="formData.fechaIngreso"
                  class="form-field w-full"
                />
              </div>
              <div>
                <label class="block text-xs font-medium text-gray-600 mb-1"
                  >Ubicacion</label
                >
                <input
                  type="text"
                  v-model="formData.pagoRol"
                  class="form-field w-full h-20"
                />
              </div>
              <div>
                <label class="block text-xs font-medium text-gray-600 mb-1"
                  >Proyecto</label
                >
                <select v-model="formData.proyecto" class="form-field w-full">
                  <option>Cisepro</option>
                  <option>Proyecto X</option>
                </select>
              </div>
            </div>

            <!-- Columna 2 -->
            <div class="space-y-2">
              <div>
                <label class="block text-xs font-medium text-gray-600 mb-1"
                  >Salida</label
                >
                <input
                  type="date"
                  v-model="formData.fechaSalida"
                  class="form-field w-full"
                />
              </div>
              <div>
                <label class="block text-xs font-medium text-gray-600 mb-1"
                  >Área</label
                >
                <select v-model="formData.area" class="form-field w-full">
                  <option>Sistemas</option>
                  <option>RRHH</option>
                  <option>Contabilidad</option>
                </select>
              </div>

              
              <div>
                <label class="block text-xs font-medium text-gray-600 mb-1"
                  >Inicio Pro</label
                >
                <input
                  type="date"
                  v-model="formData.inicioProyecto"
                  class="form-field w-full"
                />
              </div>
              <div>
                <label class="block text-xs font-medium text-gray-600 mb-1"
                  >Fin Pro</label
                >
                <input
                  type="date"
                  v-model="formData.inicioProyecto"
                  class="form-field w-full"
                />
              </div>
            </div>

            <!-- Columna 4 -->
            <div class="space-y-2">
              <div>
                <label class="block text-xs font-medium text-gray-600 mb-1"
                  >Motivo</label
                >
                <input
                  type="text"
                  v-model="formData.ubicacion"
                  class="form-field w-full"
                />
              </div>
              <div>
                <label class="block text-xs font-medium text-gray-600 mb-1"
                  >Cargo</label
                >
                <select v-model="formData.cargo" class="form-field w-full">
                  <option>Analista de Sistema</option>
                  <option>Asistente</option>
                  <option>Contador</option>
                </select>
              </div>
              <div>
                <label class="block text-xs font-medium text-gray-600 mb-1"
                  >Observación</label
                >
                <textarea
                  v-model="formData.observacion"
                  class="form-field w-full h-20"
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
                  <option>Indefinido</option>
                  <option>Temporal</option>
                  <option>Por obra</option>
                </select>
              </div>
              <div class="flex items-center gap-2">
                <input
                  type="checkbox"
                  v-model="formData.afiliadoIESS"
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
                  v-model="formData.fechaAfiliacionIESS"
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
                  v-model="formData.fondoReserva"
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
                <select v-model="formData.emisor" class="form-field w-full">
                  <option>Negativo</option>
                  <option>Positivo</option>
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
                  class="w-full h-8 px-2 text-xs border border-gray-300 rounded shadow-sm focus:outline-none focus:ring-1 focus:ring-blue-500 focus:border-blue-500 ml-6"
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
                  class="w-full h-8 px-2 text-xs border border-gray-300 rounded shadow-sm focus:outline-none focus:ring-1 focus:ring-blue-500 focus:border-blue-500 ml-6"
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
                  class="w-full h-8 px-2 text-xs border border-gray-300 rounded shadow-sm focus:outline-none focus:ring-1 focus:ring-blue-500 focus:border-blue-500 ml-6"
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
            <p class="text-sm text-gray-500">
              Registro completo de la trayectoria del empleado en la empresa.
            </p>
          </div>
          <!-- Contenido específico de historial -->
        </div>
      </div>
    </div>
     <SearchModal 
      :show="showSearchModal" 
      :items="searchResults"
      @close="showSearchModal = false"
      @select="loadEmployee"
      @terminate="terminateContract"
    />
    
  </div>

</template>

<script setup>
import { ref, reactive, computed, watch } from "vue";
import SearchModal from "@/components/Personal/SearchModal.vue";

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




const guardarPersonal = () => {
  console.log("Guardando personal...", formData);
};

const cancelarEdicion = () => {
  console.log("Cancelando edición...");
};

// Estado del modal
const showSearchModal = ref(false);
const searchResults = ref([]);
const isLoading = ref(false);

// Estado del formulario (tu reactive existente)


// Métodos del modal
const buscarPersonal = async () => {
  showSearchModal.value = true;
  isLoading.value = true;
  try {
    searchResults.value = await $api.getPersonal();
    showSearchModal.value = true;
  } catch (error) {
    console.error("Error buscando personal:", error);
    // Usa tu sistema de notificaciones (ej: toast)
  }
};

const loadEmployee = (employee) => {
  Object.assign(formData, {
    id: employee.id,
    cedula: employee.cedula,
    nombres: employee.nombres,
    apellidos: employee.apellidos,
    sexo: employee.sexo,
    estadoCivil: employee.estadoCivil,
    instruccion: employee.instruccion,
    tipoSangre: employee.tipoSangre,
    provincia: employee.provincia,
    parroquia: employee.parroquia,
    direccion: employee.direccion,
    email: employee.email,
    banco: employee.banco,
    cuenta: employee.cuenta,
    contrato: employee.contrato,
    fechaNacimiento: employee.fechaNacimiento,
    pasaporte: employee.pasaporte,
    libretaMilitar: employee.libretaMilitar,
    peso: employee.peso,
    estatura: employee.estatura,
    ciudad: employee.ciudad,
    telefono: employee.telefono,
    celular: employee.celular,
  });
   // Actualiza formData
  showSearchModal.value = false;
  currentTab.value = 'datos';
};

const terminateContract = async (employee) => {
  if (confirm(`¿Terminar contrato de ${employee.nombres}?`)) {
    try {
      await $api.terminateContract(employee.id);
      // toast.success(`Contrato finalizado`);
      await buscarPersonal(); // Refrescar
    } catch (error) {
      // toast.error("Error al terminar contrato");
    }
  }
};



</script>

<style>
/* Estilos para inputs de fecha */

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
         focus:outline-none focus:ring-1 focus:ring-blue-500 focus:border-blue-500;
}
</style>
