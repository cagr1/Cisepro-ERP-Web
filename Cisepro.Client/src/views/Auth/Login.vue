<template>
  <div
    class="min-h-screen flex items-center justify-center p-4 bg-[url('/src/assets/Images/login_bg.jpg')] bg-cover bg-center bg-no-repeat bg-opacity-50"
  >
    <!-- Card Container -->

    <div class="w-full max-w-md bg-white rounded-lg shadow-md overflow-hidden">
      <!-- Card Content -->
      <div class="px-6 pb-6 pt-2">
        <div class="mb-4">
          <h4 class="text-xl font-semibold mb-1 text-gray-900">
            Bienvenido! 👋
          </h4>
          <p class="text-gray-600">Inicie sesión en su cuenta para comenzar</p>
        </div>
        <div class="mt-8">
          <RadioChoice
            v-model="selectedCompany"
            name="company"
            :options="companies"
            icon-border-color="border-gray-200"
          />
        </div>
        <div class="mt-4"></div>
        <form @submit.prevent="handleLogin">
          <!-- Email Input -->

          <div class="mb-6">         

            <UiInput 
              v-model="form.login"
              label="Usuario"
              type="text"
              autocomplete="username"
              :class="{'border-red-500': errors.login} "
              @input="errorMessage = ''"
            />
            <FormErrorMessage :message="errors.login" />
          </div>
         

          <!-- Error state -->
          <div v-if="usersError" class="mt-2 text-sm text-red-500">
            Error cargando usuarios: {{ usersError }}
          </div>
          <!-- Password Input -->
          <div class="mb-6">
            <UiInput
              v-model="form.password"
              label="Contraseña"
              type="password"
              :class="{ 'border-red-500': errors.password }"
              @input="errorMessage = ''"
            />
            <FormErrorMessage :message="errors.password" />
          </div>

          <div v-if="errorMessage" class="text-red-500 text-center mb-4">
            {{ errorMessage }}
          </div>

          <!-- Remember Me & Forgot Password -->
          <div class="flex items-center justify-between mb-6">
            <label class="flex items-center text-gray-600">
              <input
                v-model="form.remember"
                type="checkbox"
                class="rounded border-gray-300 text-blue-600 shadow-sm focus:border-blue-300 focus:ring focus:ring-blue-200 focus:ring-opacity-50"
              />
              <span class="ml-2 text-sm">Recordar sesión</span>
            </label>

            <RouterLink
              to="/forgot-password"
              class="text-sm text-blue-600 hover:text-blue-800"
            >
              ¿Olvidó su contraseña?
            </RouterLink>
          </div>

          <!-- Login Button -->
          <button
            type="submit"
            class="w-full bg-blue-600 hover:bg-blue-700 text-white font-medium py-2 px-4 rounded-md shadow-md transition duration-200"
          >
            Iniciar Sesión
          </button>

          <!-- Divider -->
          <div class="flex items-center my-6">
            <div class="flex-grow border-t border-gray-300"></div>
            <span class="mx-4 text-gray-500 text-sm">o</span>
            <div class="flex-grow border-t border-gray-300"></div>
          </div>

          <!-- Social Auth -->
          <div class="grid grid-cols-2 gap-4">
            <button
              type="button"
              class="flex items-center justify-center gap-2 bg-gray-100 hover:bg-gray-200 text-gray-800 py-2 px-4 rounded-md transition"
            >
              <i class="ri-google-fill text-red-500"></i>
              Google
            </button>
            <button
              type="button"
              class="flex items-center justify-center gap-2 bg-gray-100 hover:bg-gray-200 text-gray-800 py-2 px-4 rounded-md transition"
            >
              <i class="ri-microsoft-fill text-blue-500"></i>
              Microsoft
            </button>
          </div>
        </form>
      </div>

      <!-- Card Footer -->
      <div class="bg-gray-50 px-6 py-4 text-center">
        <span class="text-gray-600 text-sm">¿No tiene una cuenta?</span>
        <RouterLink
          to="/register"
          class="text-blue-600 hover:text-blue-800 ml-2 text-sm font-medium"
        >
          Crear cuenta
        </RouterLink>
      </div>
    </div>
  </div>
</template>

<script setup>
import { ref,onMounted } from "vue";
import { useRouter } from "vue-router";
import { useAuthStore } from "@/stores/auth.store";
import UiInput from "@/components/Input.vue";
import RadioChoice from "@/components/RadioChoice.vue";
import FormErrorMessage from "@/components/FormErrorMessage.vue";
import { useFormValidation } from "@/validations/useFormValidation";
import { useAuthValidations } from "@/validations/useAuthValidations";



const authStore = useAuthStore();
const router = useRouter();

const { errors, validateRequire } = useFormValidation();
const { validateLoginForm } = useAuthValidations();

const selectedCompany = ref("Cisepro");

const companies = ref([
  {
    value: "Cisepro",
    label: "Cisepro",
    logo: "/src/assets/Images/cisepro.png",
    bgColor: "#0D47A1",
  },
  {
    value: "Seportpac",
    label: "Seportpac",
    logo: "/src/assets/Images/seportpac.png",
    bgColor: "#404040",
  },
]);

const form = ref({
  tipoConexion: selectedCompany.value,
  login: localStorage.getItem('rememberedUsername') || "",
  password: "",
  remember: localStorage.getItem('rememberUsername') === "true"
});

onMounted(() => {
  if (form.value.remember) {
    form.value.login = localStorage.getItem("rememberedUsername") || "";
  } 
})

const errorMessage = ref("");


const handleLogin = async () => {
  try {
    errorMessage.value = "";

    const isValid = validateRequire({
      login: form.value.login,
      password: form.value.password,
    });

    if (!isValid) return;

    if (form.value.remember) {
      localStorage.setItem("rememberedUsername", form.value.login);
      localStorage.setItem("rememberUsername", 'true');
    } else {
      localStorage.removeItem("rememberedUsername");
      localStorage.removeItem("rememberPassword");
    }

    if (!form.value.login) {
      errors.value.login = "El campo usuario es requerido";
      return;
    }

    const authErrors = validateLoginForm(form.value);
    if (Object.keys(authErrors).length > 0) {
      errors.value = authErrors;
      return;
    }

    await authStore.login({
      TipoConexion: selectedCompany.value, // 'cisepro' o 'seportpac'
      Login: form.value.login.toUpperCase(),
      Password: form.value.password,
    });

    router.push({ name: "Dashboard" }); // Redirigir a dashboard
    // Redirigir a dashboard
  } catch (error) {
    errorMessage.value =
      error.response?.data?.message ||
      "Error al iniciar sesión. Usuario o Contraseña incorrectos.";
    console.error("Error de inicio de sesión:", error);
  }
};
</script>
