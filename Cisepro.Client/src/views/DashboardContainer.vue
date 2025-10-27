<template>
  <div class="p-4">
    <!-- Selector de dashboards -->
    <div class="bg-white border border-slate rounded-lg shadow-md  sticky top-0 z-10">
      <!-- Tabs como botones -->
       <nav
          ref="tabList"
          role="tablist"
          aria-label="Selector de dashboards"
          class="flex gap-2 p-3"
        >
          <button
            v-for="(tab, idx) in tabs"
            :key="tab.name"
            :id="`tab-${idx}`"
            role="tab"
            :aria-selected="currentIndex === idx"
            :tabindex="currentIndex === idx ? 0 : -1"
            @click="selectTab(idx)"
            @keydown="onKeydown($event, idx)"
            class="flex items-center gap-2 px-4 py-2 text-sm font-medium rounded-md transition-all transform focus:outline-none"
            :class="currentIndex === idx
              ? 'bg-gradient-to-r from-blue-500 to-blue-600 hover:from-blue-600 hover:to-blue-700 text-white shadow-lg scale-100'
              : 'bg-gray-50 text-gray-600 hover:bg-gray-100'"
          >
            <Icon :icon="tab.icon" class="w-5 h-5"></Icon>
            {{ tab.name }}
          </button>
        </nav>
    </div>

    <!-- Contenedor dinámico -->
    <!-- <component :is="currentTab.component" :tipoCon="currentConnection" /> -->

    <div class="p-4">
        <transition name="fade" mode="out-in">
          <component
            :is="tabs[currentIndex].component"
            :tipoCon="tipoCon"
            :key="tabs[currentIndex].name"
          />
        </transition>
      </div>
  </div>
</template>

<script setup>
import { defineAsyncComponent,ref,nextTick } from 'vue';
import { Icon } from '@iconify/vue';
import { useAuthStore } from "@/stores/auth.store";

const authStore = useAuthStore();
const tipoConexion = computed(() => authStore.selectedCompany || "Cisepro");

const currentIndex = ref(0);

const tabs = [
  {
    name: "Financiero",
    icon: "heroicons:currency-dollar",
    component: defineAsyncComponent(() =>
      import("@/views/dashboard/Financiero.vue")
    ),
  },
  {
    name: "Operativo",
    icon: "heroicons:map-pin",
    component: defineAsyncComponent(() =>
      import("@/views/dashboard/Operativo.vue")
    ),
  },
  {
    name: "RRHH",
    icon: "heroicons:user-group",
    component: defineAsyncComponent(() =>
      import("@/views/dashboard/RRHH.vue")
    ),
  },
];

// Métodos
function selectTab(idx) {
  currentIndex.value = idx;
  // accesibilidad: poner foco en el botón activo
  nextTick(() => {
    const el = document.getElementById(`tab-${idx}`);
    if (el) el.focus();
  });
}

function onKeydown(e, idx) {
  const last = tabs.length - 1;
  if (e.key === "ArrowRight") {
    e.preventDefault();
    selectTab(idx === last ? 0 : idx + 1);
  } else if (e.key === "ArrowLeft") {
    e.preventDefault();
    selectTab(idx === 0 ? last : idx - 1);
  } else if (e.key === "Home") {
    e.preventDefault();
    selectTab(0);
  } else if (e.key === "End") {
    e.preventDefault();
    selectTab(last);
  } else if (e.key === "Enter" || e.key === " ") {
    e.preventDefault();
    selectTab(idx);
  }
}




</script>


<style scoped>
.fade-enter-active,
.fade-leave-active {
  transition: opacity 220ms ease, transform 220ms ease;
}
.fade-enter-from,
.fade-leave-to {
  opacity: 0;
  transform: translateY(6px);
}


</style>
<!-- <style scoped>
.dashboard-selector {
  display: flex;
  gap: 10px;
  padding: 10px;
  background: #2a2a3c;
  border-radius: 8px;
}

.dashboard-selector button {
  flex: 1;
  padding: 10px 15px;
  background: #34344a;
  color: #a0a0c0;
  border: none;
  border-radius: 6px;
  cursor: pointer;
  transition: all 0.3s;
  display: flex;
  align-items: center;
  justify-content: center;
}

.dashboard-selector button.active-tab {
  background: #4361ee;
  color: white;
  box-shadow: 0 4px 6px rgba(67, 97, 238, 0.3);
}
</style> -->









