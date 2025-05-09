<template>
  <div class="bg-gray-100 min-h-screen p-6">
    <div class="max-w-4xl mx-auto bg-white rounded-lg shadow-md p-8">
      <h1 class="text-2xl font-semibold text-gray-800 mb-6 text-center">Datos Personales</h1>

      <div class="grid grid-cols-1 md:grid-cols-2 gap-6">
        <div>
          <div class="mb-4">
            <label for="cedula" class="block text-gray-700 text-sm font-bold mb-2">Cédula</label>
            <input
              type="text"
              id="cedula"
              v-model="formData.cedula"
              placeholder="Ingrese su número de cédula"
              class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
            />
          </div>

          <div class="mb-4">
            <label for="nombres" class="block text-gray-700 text-sm font-bold mb-2">Nombres</label>
            <input
              type="text"
              id="nombres"
              v-model="formData.nombres"
              placeholder="Ingrese sus nombres"
              class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
            />
          </div>

          <div class="mb-4">
            <label for="apellidos" class="block text-gray-700 text-sm font-bold mb-2">Apellidos</label>
            <input
              type="text"
              id="apellidos"
              v-model="formData.apellidos"
              placeholder="Ingrese sus apellidos"
              class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
            />
          </div>

          <div class="mb-4">
            <label for="sexo" class="block text-gray-700 text-sm font-bold mb-2">Sexo</label>
            <select
              id="sexo"
              v-model="formData.sexo"
              class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
            >
              <option value="masculino">Masculino</option>
              <option value="femenino">Femenino</option>
            </select>
          </div>

          <div class="mb-4">
            <label for="estadoCivil" class="block text-gray-700 text-sm font-bold mb-2">Estado Civil</label>
            <select
              id="estadoCivil"
              v-model="formData.estadoCivil"
              class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
            >
              <option value="soltero">Soltero</option>
              <option value="casado">Casado</option>
              <option value="divorciado">Divorciado</option>
              <option value="viudo">Viudo</option>
            </select>
          </div>

          <div class="mb-4">
            <label for="instruccion" class="block text-gray-700 text-sm font-bold mb-2">Instrucción</label>
            <select
              id="instruccion"
              v-model="formData.instruccion"
              class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
            >
              <option value="primaria">Primaria</option>
              <option value="secundaria">Secundaria</option>
              <option value="superior">Superior</option>
            </select>
          </div>

          <div class="mb-4">
            <label for="tipoSangre" class="block text-gray-700 text-sm font-bold mb-2">Tipo de Sangre</label>
            <select
              id="tipoSangre"
              v-model="formData.tipoSangre"
              class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
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
            <label for="provincia" class="block text-gray-700 text-sm font-bold mb-2">Provincia</label>
            <select
              id="provincia"
              v-model="formData.provincia"
              @change="cargarParroquiasYCiudades"
              class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
            >
              <option v-for="provincia in provincias" :key="provincia.id" :value="provincia.id">
                {{ provincia.nombre }}
              </option>
            </select>
          </div>

          <div class="mb-4">
            <label for="parroquia" class="block text-gray-700 text-sm font-bold mb-2">Parroquia</label>
            <select
              id="parroquia"
              v-model="formData.parroquia"
              class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
              :disabled="!formData.provincia"
            >
              <option v-for="parroquia in parroquias" :key="parroquia.id" :value="parroquia.id">
                {{ parroquia.nombre }}
              </option>
            </select>
          </div>

          <div class="mb-4">
            <label for="direccion" class="block text-gray-700 text-sm font-bold mb-2">Dirección</label>
            <textarea
              id="direccion"
              v-model="formData.direccion"
              class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
            ></textarea>
          </div>

          <div class="mb-4">
            <label for="email" class="block text-gray-700 text-sm font-bold mb-2">Email</label>
            <input
              type="email"
              id="email"
              v-model="formData.email"
              class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
            />
          </div>

          <div class="mb-4">
            <label for="banco" class="block text-gray-700 text-sm font-bold mb-2">Banco</label>
            <select
              id="banco"
              v-model="formData.banco"
              class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
            >
              <option value="banco1">Banco 1</option>
              <option value="banco2">Banco 2</option>
              <option value="banco3">Banco 3</option>
            </select>
          </div>

          <div class="mb-4">
            <label for="cuenta" class="block text-gray-700 text-sm font-bold mb-2">Cuenta</label>
            <input
              type="text"
              id="cuenta"
              v-model="formData.cuenta"
              class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
            />
          </div>
        </div>

        <div>
          <div class="mb-4">
            <label for="contrato" class="block text-gray-700 text-sm font-bold mb-2">Contrato</label>
            <input
              type="text"
              id="contrato"
              v-model="formData.contrato"
              class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
            />
          </div>

          <div class="mb-4">
            <label for="fechaNacimiento" class="block text-gray-700 text-sm font-bold mb-2">Fecha de Nacimiento</label>
            <input
              type="date"
              id="fechaNacimiento"
              v-model="formData.fechaNacimiento"
              class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
            />
          </div>

          <div class="mb-4">
            <label for="pasaporte" class="block text-gray-700 text-sm font-bold mb-2">Pasaporte</label>
            <input
              type="text"
              id="pasaporte"
              v-model="formData.pasaporte"
              class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
            />
          </div>

          <div class="mb-4">
            <label for="libretaMilitar" class="block text-gray-700 text-sm font-bold mb-2">Libreta Militar</label>
            <input
              type="text"
              id="libretaMilitar"
              v-model="formData.libretaMilitar"
              class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
            />
          </div>

          <div class="mb-4">
            <label for="peso" class="block text-gray-700 text-sm font-bold mb-2">Peso (kg)</label>
            <input
              type="number"
              id="peso"
              v-model="formData.peso"
              class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
            />
          </div>

          <div class="mb-4">
            <label for="estatura" class="block text-gray-700 text-sm font-bold mb-2">Estatura (cm)</label>
            <input
              type="number"
              id="estatura"
              v-model="formData.estatura"
              class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
            />
          </div>

          <div class="mb-4">
            <label for="ciudad" class="block text-gray-700 text-sm font-bold mb-2">Ciudad</label>
            <select
              id="ciudad"
              v-model="formData.ciudad"
              class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
              :disabled="!formData.provincia"
            >
              <option v-for="ciudad in ciudades" :key="ciudad.id" :value="ciudad.id">
                {{ ciudad.nombre }}
              </option>
            </select>
          </div>

          <div class="mb-4">
            <label for="telefono" class="block text-gray-700 text-sm font-bold mb-2">Teléfono</label>
            <input
              type="tel"
              id="telefono"
              v-model="formData.telefono"
              class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
            />
          </div>

          <div class="mb-4">
            <label for="celular" class="block text-gray-700 text-sm font-bold mb-2">Celular</label>
            <input
              type="tel"
              id="celular"
              v-model="formData.celular"
              class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
            />
          </div>

          <div class="mb-4">
            <label for="tipo" class="block text-gray-700 text-sm font-bold mb-2">Tipo</label>
            <select
              id="tipo"
              v-model="formData.tipo"
              class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
            >
              <option value="tipo1">Tipo 1</option>
              <option value="tipo2">Tipo 2</option>
              <option value="tipo3">Tipo 3</option>
            </select>
          </div>
        </div>
      </div>
      <div class="grid grid-cols-1 md:grid-cols-3 gap-6 mt-6">
          <div>
            <label class="block text-gray-700 text-sm font-bold mb-2">Imagen de Perfil</label>
            <div class="flex items-center justify-center w-full">
                <label for="dropzone-file" class="flex flex-col items-center justify-center w-full h-32 border-2 border-gray-300 border-dashed rounded-lg cursor-pointer bg-gray-50 dark:hover:bg-bray-800 dark:bg-gray-700 hover:bg-gray-100 dark:border-gray-600 dark:hover:border-gray-500 dark:hover:bg-gray-600">
                    <div class="flex flex-col items-center justify-center pt-5 pb-6">
                        <svg class="w-8 h-8 mb-4 text-gray-500 dark:text-gray-400" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 20 16">
                            <path stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M13 4h-2V2a2 2 0 0 0-2-2H7a2 2 0 0 0-2 2v2H2m2 5h6m-6 2h6m-3-3v6m-3-9h6m-3 3H8m-3-3H2"/>
                        </svg>
                        <p class="mb-2 text-sm text-gray-500 dark:text-gray-400"><span class="font-semibold">Click to upload</span> or drag and drop</p>
                        <p class="text-xs text-gray-500 dark:text-gray-400">SVG, PNG, JPG or GIF (MAX. 800x400px)</p>
                    </div>
                    <input id="dropzone-file" type="file" class="hidden" @change="handleFileChange"/>
                </label>
            </div>
             <div v-if="formData.imagenPerfil" class="mt-2">
                <img :src="formData.imagenPerfil" alt="Imagen de perfil" class="w-16 h-16 rounded-full">
            </div>
          </div>
          <div>
            <label  class="block text-gray-700 text-sm font-bold mb-2">Edad</label>
             <input
              type="number"
              id="edad"
              v-model="edad"
              readonly
              class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline bg-gray-200"
            />
          </div>
          <div class="flex items-center mb-4">
            <label for="credencial" class="mr-2 text-gray-700 text-sm font-bold">Credencial</label>
            <input
              type="checkbox"
              id="credencial"
              v-model="formData.credencial"
              class="mr-2 h-5 w-5 text-blue-600 focus:ring-blue-500 border-gray-300 rounded"
            />

          </div>
          <div class="mb-4">
            <label for="fechaIngreso" class="block text-gray-700 text-sm font-bold mb-2">Fecha de Ingreso</label>
            <input
              type="date"
              id="fechaIngreso"
              v-model="formData.fechaIngreso"
              class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
            />
          </div>

          <div class="mb-4">
            <label for="tipoContrato" class="block text-gray-700 text-sm font-bold mb-2">Tipo de Contrato</label>
            <select
              id="tipoContrato"
              v-model="formData.tipoContrato"
              class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
            >
              <option value="indefinido">Indefinido</option>
              <option value="temporal">Temporal</option>
              <option value="prueba">Prueba</option>
            </select>
          </div>

          <div class="mb-4">
            <label for="pagoRol" class="block text-gray-700 text-sm font-bold mb-2">Pago en Rol</label>
            <input
              type="text"
              id="pagoRol"
              v-model="formData.pagoRol"
              class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
            />
          </div>

          <div class="mb-4">
            <label for="fechaSalida" class="block text-gray-700 text-sm font-bold mb-2">Fecha de Salida</label>
            <input
              type="date"
              id="fechaSalida"
              v-model="formData.fechaSalida"
              class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
            />
          </div>

           <div class="mb-4">
            <label for="area" class="block text-gray-700 text-sm font-bold mb-2">Área</label>
            <select
              id="area"
              v-model="formData.area"
              class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
            >
              <option value="area1">Área 1</option>
              <option value="area2">Área 2</option>
              <option value="area3">Área 3</option>
            </select>
          </div>

          <div class="mb-4">
            <label for="cargo" class="block text-gray-700 text-sm font-bold mb-2">Cargo</label>
            <select
              id="cargo"
              v-model="formData.cargo"
              class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
            >
              <option value="cargo1">Cargo 1</option>
              <option value="cargo2">Cargo 2</option>
              <option value="cargo3">Cargo 3</option>
            </select>
          </div>

          <div class="mb-4">
            <label for="proyecto" class="block text-gray-700 text-sm font-bold mb-2">Proyecto</label>
            <select
              id="proyecto"
              v-model="formData.proyecto"
              class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
            >
              <option value="proyecto1">Proyecto 1</option>
              <option value="proyecto2">Proyecto 2</option>
              <option value="proyecto3">Proyecto 3</option>
            </select>
          </div>

          <div class="mb-4">
            <label for="inicioProyecto" class="block text-gray-700 text-sm font-bold mb-2">Inicio Proyecto</label>
            <input
              type="date"
              id="inicioProyecto"
              v-model="formData.inicioProyecto"
              class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
            />
          </div>

          <div class="mb-4">
            <label for="ubicacion" class="block text-gray-700 text-sm font-bold mb-2">Ubicación</label>
            <input
              type="text"
              id="ubicacion"
              v-model="formData.ubicacion"
              class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
            />
          </div>

          <div class="mb-4">
            <label for="observacion" class="block text-gray-700 text-sm font-bold mb-2">Observación</label>
            <textarea
              id="observacion"
              v-model="formData.observacion"
              class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
            ></textarea>
          </div>
      </div>

      <div class="grid grid-cols-1 md:grid-cols-3 gap-6 mt-6">
        <div class="flex items-center">
            <label for="historiaClinica" class="mr-2 text-gray-700 text-sm font-bold">Historia Clínica</label>
            <input type="checkbox" id="historiaClinica" v-model="formData.historiaClinica" class="h-5 w-5 text-blue-600 focus:ring-blue-500 border-gray-300 rounded">
        </div>
        <div class="flex items-center">
            <label for="discapacitado" class="mr-2 text-gray-700 text-sm font-bold">Discapacitado</label>
            <input type="checkbox" id="discapacitado" v-model="formData.discapacitado" class="h-5 w-5 text-blue-600 focus:ring-blue-500 border-gray-300 rounded">
        </div>
         <div class="flex items-center">
            <label for="examenPsicologico" class="mr-2 text-gray-700 text-sm font-bold">Examen Psicológico</label>
            <input type="checkbox" id="examenPsicologico" v-model="formData.examenPsicologico" class="h-5 w-5 text-blue-600 focus:ring-blue-500 border-gray-300 rounded">
        </div>
        <div class="flex items-center">
             <label for="cursoVigilante" class="mr-2 text-gray-700 text-sm font-bold">Curso Vigilante</label>
            <input type="checkbox" id="cursoVigilante" v-model="formData.cursoVigilante" class="h-5 w-5 text-blue-600 focus:ring-blue-500 border-gray-300 rounded">
        </div>
        <div class="flex items-center">
            <label for="documentacion" class="mr-2 text-gray-700 text-sm font-bold">Documentación</label>
            <input type="checkbox" id="documentacion" v-model="formData.documentacion" class="h-5 w-5 text-blue-600 focus:ring-blue-500 border-gray-300 rounded">
        </div>
        <div class="flex items-center">
            <label for="pruebaAntidroga" class="mr-2 text-gray-700 text-sm font-bold">Prueba Antidroga</label>
            <input type="checkbox" id="pruebaAntidroga" v-model="formData.pruebaAntidroga" class="h-5 w-5 text-blue-600 focus:ring-blue-500 border-gray-300 rounded">
        </div>
        <div class="flex items-center">
            <label for="conadis" class="mr-2 text-gray-700 text-sm font-bold">Conadis</label>
            <input type="checkbox" id="conadis" v-model="formData.conadis" class="h-5 w-5 text-blue-600 focus:ring-blue-500 border-gray-300 rounded">
        </div>
        <div class="flex items-center">
            <label  class="mr-2 text-gray-700 text-sm font-bold">Emisor</label>
            <div class="flex items-center mr-4">
                <input type="radio" id="emisorSi" value="si" v-model="formData.emisor" class="h-4 w-4 text-blue-600 focus:ring-blue-500 border-gray-300 rounded">
                <label for="emisorSi" class="ml-2 text-gray-700 text-sm font-medium">Sí</label>
            </div>
            <div class="flex items-center">
                <input type="radio" id="emisorNo" value="no" v-model="formData.emisor" class="h-4 w-4 text-blue-600 focus:ring-blue-500 border-gray-300 rounded">
                <label for="emisorNo" class="ml-2 text-gray-700 text-sm font-medium">No</label>
            </div>
        </div>
      </div>

      <div class="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-4 gap-4 mt-6">
        <div>
            <label  class="block text-gray-700 text-sm font-bold mb-2">XIII</label>
             <input
              type="text"
              id="xiii"
              v-model="formData.xiii"

              class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline "
            />
        </div>
         <div>
            <label  class="block text-gray-700 text-sm font-bold mb-2">XIV</label>
             <input
              type="text"
              id="xiv"
              v-model="formData.xiv"
              class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline "
            />
        </div>
         <div>
            <label  class="block text-gray-700 text-sm font-bold mb-2">Fondo Re.</label>
             <input
              type="text"
              id="fondoReserva"
              v-model="formData.fondoReserva"
              class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline "
            />
        </div>
         <div>
            <label  class="block text-gray-700 text-sm font-bold mb-2">Acum. F. Res.</label>
             <input
              type="text"
              id="acumFondoReserva"
              v-model="formData.acumFondoReserva"
              class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline "
            />
        </div>
         <div>
            <label  class="block text-gray-700 text-sm font-bold mb-2">Sueldo</label>
             <input
              type="text"
              id="sueldo"
              v-model="formData.sueldo"
              class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline "
            />
        </div>
         <div>
            <label  class="block text-gray-700 text-sm font-bold mb-2">Extra</label>
             <input
              type="text"
              id="extra"
              v-model="formData.extra"
              class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline "
            />
        </div>
        <div class="col-span-2">
            <label  class="block text-gray-700 text-sm font-bold mb-2">CISEPRO CIA. LTDA. (SIN NOMBRE DE PROYECTO) S/N</label>
             <input
              type="text"
              id="nombreProyecto"
              v-model="formData.nombreProyecto"
              class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline "
            />
        </div>
         <div>
            <label  class="block text-gray-700 text-sm font-bold mb-2">Fin Pro</label>
             <input
              type="text"
              id="finProyecto"
              v-model="formData.finProyecto"
              class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline "
            />
        </div>
         <div>
            <label  class="block text-gray-700 text-sm font-bold mb-2">AUN NO SE ESPECIFICA</label>
             <input
              type="text"
              id="noEspecificado"
              v-model="formData.noEspecificado"
              class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline "
            />
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { ref, reactive, computed, watch } from 'vue';
import { useRouter } from 'vue-router';

const router = useRouter();
export default {
  setup() {
    const formData = reactive({
      cedula: '',
      nombres: '',
      apellidos: '',
      sexo: 'masculino',
      estadoCivil: 'soltero',
      instruccion: 'primaria',
      tipoSangre: 'O+',
      provincia: '',
      parroquia: '',
      direccion: '',
      email: '',
      banco: 'banco1',
      cuenta: '',
      contrato: '',
      fechaNacimiento: '',
      pasaporte: '',
      libretaMilitar: '',
      peso: '',
      estatura: '',
      ciudad: '',
      telefono: '',
      celular: '',
      tipo: 'tipo1',
      imagenPerfil: null,
      credencial: false,
      fechaIngreso: '',
      tipoContrato: 'indefinido',
      pagoRol: '',
      fechaSalida:'',
      area: 'area1',
      cargo: 'cargo1',
      proyecto: 'proyecto1',
      inicioProyecto: '',
      ubicacion: '',
      observacion: '',
      historiaClinica: false,
      discapacitado: false,
      examenPsicologico: false,
      cursoVigilante: false,
      documentacion: false,
      pruebaAntidroga: false,
      conadis: false,
      emisor: 'si',
      xiii: '',
      xiv: '',
      fondoReserva: '',
      acumFondoReserva: '',
      sueldo: '',
      extra: '',
      nombreProyecto: '',
      finProyecto: '',
      noEspecificado: '',
    });

    const provincias = ref([
      { id: 'p1', nombre: 'Pichincha' },
      { id: 'p2', nombre: 'Guayas' },
      { id: 'p3', nombre: 'Azuay' },
    ]);

    const parroquias = ref([]);
    const ciudades = ref([]);

     const cargarParroquiasYCiudades = () => {
        if (formData.provincia === 'p1') {
            parroquias.value = [
                { id: 'par1_p1', nombre: 'Parroquia 1 - Pichincha' },
                { id: 'par2_p1', nombre: 'Parroquia 2 - Pichincha' },
            ];
            ciudades.value = [{id: 'c1_p1', nombre: 'Ciudad 1 - Pichincha'},{id: 'c2_p1', nombre: 'Ciudad 2 - Pichincha'}];
        } else if (formData.provincia === 'p2') {
            parroquias.value = [
              { id: 'par1_p2', nombre: 'Parroquia 1 - Guayas' },
              { id: 'par2_p2', nombre: 'Parroquia 2 - Guayas' },
            ];
             ciudades.value = [{id: 'c1_p2', nombre: 'Ciudad 1 - Guayas'},{id: 'c2_p2', nombre: 'Ciudad 2 - Guayas'}];
        } else if (formData.provincia === 'p3') {
             parroquias.value = [
                { id: 'par1_p3', nombre: 'Parroquia 1 - Azuay' },
                { id: 'par2_p3', nombre: 'Parroquia 2 - Azuay' },
            ];
            ciudades.value = [{id: 'c1_p3', nombre: 'Ciudad 1 - Azuay'},{id: 'c2_p3', nombre: 'Ciudad 2 - Azuay'}];
        } else {
            parroquias.value = [];
            ciudades.value = [];
        }
        formData.parroquia = '';
        formData.ciudad = '';
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
            let edad = hoy.getFullYear() - fechaNacimiento.getFullYear();
            const mes = hoy.getMonth() - fechaNacimiento.getMonth();
            if (mes < 0 || (mes === 0 && hoy.getDate() < fechaNacimiento.getDate())) {
                edad--;
            }
            return edad;
        }
        return '';
    });
    watch(() => formData.fechaNacimiento, () => {
      edad.value = calcularEdad();
    });

    return {
      formData,
      provincias,
      parroquias,
      ciudades,
      cargarParroquiasYCiudades,
      handleFileChange,
      edad
    };
  },
};
</script>

<style>
/* Estilos adicionales para Material Design (puedes ajustarlos) */
input:focus,
select:focus,
textarea:focus {
  outline: none;
  border-color: #3b82f6; /* Color primario de Tailwind */
  box-shadow: 0 0 0 3px rgba(59, 130, 246, 0.1); /* Sombra de enfoque */
}

.form-label {
  font-size: 0.875rem;
  color: #4b5563; /* Color de texto secundario */
  font-weight: 500;
  display: block;
  margin-bottom: 0.5rem;
}

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
    background-image: url('data:image/svg+xml;utf8,<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="feather feather-calendar"><rect x="3" y="4" width="18" height="18" rx="2" ry="2"/><line x1="16" x2="16" y1="2" y2="6"/><line x1="8" x2="8" y1="2" y2="6"/><line x1="3" x2="21" y1="10" y2="10"/></svg>'); /* Icono de calendario */
}
input[type="date"]:focus{
   border-color: #3b82f6;
  box-shadow: 0 0 0 3px rgba(59, 130, 246, 0.1);
}
</style>
