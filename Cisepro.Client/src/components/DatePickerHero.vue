<!-- DatePickerHero.vue -->
<template>
  <div class="relative inline-block text-sm" @keydown.stop.prevent="onKeydown">
    <button
      ref="trigger"
      type="button"
      class="flex items-center gap-2 px-3 py-2 rounded-2xl shadow-sm bg-white dark:bg-slate-800 border border-slate-200 dark:border-slate-700 hover:shadow-md transition"
      @click="open = !open"
      :aria-expanded="open"
      aria-haspopup="dialog"
    >
      <svg class="w-5 h-5" viewBox="0 0 24 24" fill="none" stroke="currentColor"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M8 7V3m8 4V3M3 11h18M5 21h14a2 2 0 0 0 2-2V7a2 2 0 0 0-2-2H5a2 2 0 0 0-2 2v12a2 2 0 0 0 2 2z"/></svg>
      <span>{{ displayLabel }}</span>
      <svg class="w-4 h-4 ml-1 opacity-70" viewBox="0 0 20 20" fill="currentColor"><path fill-rule="evenodd" d="M5.23 7.21a.75.75 0 011.06.02L10 10.94l3.71-3.71a.75.75 0 011.08 1.04l-4.25 4.25a.75.75 0 01-1.08 0L5.21 8.27a.75.75 0 01.02-1.06z" clip-rule="evenodd"/></svg>
    </button>

    <div
      v-if="open"
      ref="panel"
      class="mt-2 w-80 bg-white dark:bg-slate-900 rounded-2xl shadow-lg border border-slate-200 dark:border-slate-800 p-4 z-50"
      role="dialog"
      aria-modal="false"
    >
      <!-- Header -->
      <div class="flex items-center justify-between mb-3">
        <div class="flex items-center gap-3">
          <button @click="changeMonth(-1)" class="p-2 rounded-lg hover:bg-slate-100 dark:hover:bg-slate-800">
            <svg class="w-5 h-5" viewBox="0 0 24 24" fill="none" stroke="currentColor"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M15 19l-7-7 7-7"/></svg>
          </button>
          <div class="text-base font-semibold">
            {{ months[visibleMonth] }} {{ visibleYear }}
          </div>
          <button @click="changeMonth(1)" class="p-2 rounded-lg hover:bg-slate-100 dark:hover:bg-slate-800">
            <svg class="w-5 h-5" viewBox="0 0 24 24" fill="none" stroke="currentColor"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 5l7 7-7 7"/></svg>
          </button>
        </div>

        <div class="flex items-center gap-2">
          <button @click="selectToday" class="text-xs px-2 py-1 rounded-md hover:bg-slate-100 dark:hover:bg-slate-800">Hoy</button>
          <button @click="clear" class="text-xs px-2 py-1 rounded-md text-rose-600 hover:bg-rose-50">Limpiar</button>
        </div>
      </div>

      <!-- Weekdays -->
      <div class="grid grid-cols-7 text-xs text-center text-slate-500 mb-2">
        <div v-for="d in weekdaysShort" :key="d" class="py-1">{{ d }}</div>
      </div>

      <!-- Days grid -->
      <div class="grid grid-cols-7 gap-1">
        <button
          v-for="cell in calendar"
          :key="cell.key"
          :disabled="cell.isPad"
          @click="selectDate(cell.date)"
          @focus="focused = cell.key"
          :class="[
            'py-2 rounded-lg text-center select-none focus:outline-none',
            cell.isPad ? 'opacity-0 pointer-events-none' : 'hover:bg-slate-100 dark:hover:bg-slate-800',
            isSameDate(cell.date, selectedDate) ? 'bg-sky-600 text-white' : '',
            isToday(cell.date) && !isSameDate(cell.date, selectedDate) ? 'ring-1 ring-slate-200 dark:ring-slate-700' : '',
            cell.inMonth ? '' : 'text-slate-400'
          ]"
          :aria-label="ariaLabel(cell)"
          :tabindex="cell.isPad ? -1 : 0"
        >
          <span class="text-sm font-medium">{{ cell.day }}</span>
        </button>
      </div>
    </div>
  </div>
</template>

<script setup>
import { ref, computed, watch, onMounted, onBeforeUnmount } from 'vue'

/* Props */
const props = defineProps({
  modelValue: { type: [String, Date, null], default: null }, // ISO string or Date
  format: { type: String, default: 'dd/MM/yyyy' }, // only for label (informative)
  localeStart: { type: Number, default: 1 } // 0 = Sun, 1 = Mon (common in HeroUI)
})
const emit = defineEmits(['update:modelValue'])

/* State */
const open = ref(false)
const selectedDate = ref(props.modelValue ? normalizeDate(props.modelValue) : null)
const today = new Date()
const visibleMonth = ref((selectedDate.value || today).getMonth())
const visibleYear = ref((selectedDate.value || today).getFullYear())
const focused = ref(null)
const trigger = ref(null)
const panel = ref(null)

/* Constants */
const months = ['Enero','Febrero','Marzo','Abril','Mayo','Junio','Julio','Agosto','Septiembre','Octubre','Noviembre','Diciembre']
const weekdaysShort = computed(() => {
  const names = ['Dom','Lun','Mar','Mié','Jue','Vie','Sáb']
  if (props.localeStart === 1) return [...names.slice(1), names[0]]
  return names
})

/* Helpers */
function normalizeDate(v){
  if (!v) return null
  const d = (v instanceof Date) ? new Date(v) : new Date(String(v))
  d.setHours(0,0,0,0)
  return d
}
function daysInMonth(year, month){ return new Date(year, month+1, 0).getDate() }
function firstWeekdayOfMonth(year, month){ return new Date(year, month, 1).getDay() } // 0..6
function isSameDate(a,b){ if(!a||!b) return false; return a.getFullYear()===b.getFullYear()&&a.getMonth()===b.getMonth()&&a.getDate()===b.getDate() }
function isToday(d){ return isSameDate(new Date(), d) }

/* Calendar computation */
const calendar = computed(() => {
  const year = visibleYear.value, month = visibleMonth.value
  const startWeekday = firstWeekdayOfMonth(year, month) // 0..6
  // adjust for localeStart (Mon=1)
  const offset = props.localeStart === 1 ? (startWeekday === 0 ? 6 : startWeekday - 1) : startWeekday
  const days = []
  const prevMonthDays = daysInMonth(year, month - 1 < 0 ? year - 1 : year, (month - 1 + 12) % 12)
  const totalCells = 42 // 6 weeks grid
  for (let i = 0; i < totalCells; i++){
    const dayIndex = i - offset + 1
    let cellDate, inMonth = true, isPad = false
    if (dayIndex <= 0){
      // prev month
      const d = prevMonthDays + dayIndex
      const m = month - 1 < 0 ? 11 : month - 1
      const y = month - 1 < 0 ? year - 1 : year
      cellDate = new Date(y, m, d); inMonth = false
    } else if (dayIndex > daysInMonth(year, month)){
      // next month
      const d = dayIndex - daysInMonth(year, month)
      const m = (month + 1) % 12
      const y = month + 1 > 11 ? year + 1 : year
      cellDate = new Date(y, m, d); inMonth = false
    } else {
      cellDate = new Date(year, month, dayIndex); inMonth = true
    }
    // create stable key
    const key = `${cellDate.getFullYear()}-${cellDate.getMonth()}-${cellDate.getDate()}`
    days.push({ key, date: cellDate, day: cellDate.getDate(), inMonth, isPad })
  }
  return days
})

/* Display label */
const displayLabel = computed(() => {
  if (!selectedDate.value) return 'Seleccionar fecha'
  const d = selectedDate.value
  const dd = String(d.getDate()).padStart(2,'0')
  const mm = String(d.getMonth()+1).padStart(2,'0')
  const yyyy = d.getFullYear()
  // quick format dd/mm/yyyy (user can pass format but keeping simple)
  return `${dd}/${mm}/${yyyy}`
})

/* Actions */
function changeMonth(delta){
  let m = visibleMonth.value + delta
  let y = visibleYear.value
  if (m < 0) { m = 11; y -= 1 }
  if (m > 11) { m = 0; y += 1 }
  visibleMonth.value = m; visibleYear.value = y
}
function selectDate(d){
  selectedDate.value = normalizeDate(d)
  emit('update:modelValue', selectedDate.value ? selectedDate.value.toISOString().slice(0,10) : null)
  open.value = false
  // return focus to trigger
  trigger.value?.focus()
}
function selectToday(){
  const t = normalizeDate(new Date())
  visibleMonth.value = t.getMonth(); visibleYear.value = t.getFullYear()
  selectDate(t)
}
function clear(){
  selectedDate.value = null
  emit('update:modelValue', null)
  open.value = false
  trigger.value?.focus()
}

/* Keyboard navigation (basic) */
function onKeydown(e){
  if (!open.value) return
  const idx = calendar.value.findIndex(c => c.key === focused.value)
  switch(e.key){
    case 'ArrowLeft': if(idx>-1) focusIndex(Math.max(0, idx-1)); break
    case 'ArrowRight': if(idx>-1) focusIndex(Math.min(calendar.value.length-1, idx+1)); break
    case 'ArrowUp': if(idx>-1) focusIndex(Math.max(0, idx-7)); break
    case 'ArrowDown': if(idx>-1) focusIndex(Math.min(calendar.value.length-1, idx+7)); break
    case 'Enter':
      if (idx>-1 && !calendar.value[idx].isPad) selectDate(calendar.value[idx].date)
      break
    case 'Escape':
      open.value = false; trigger.value?.focus()
      break
  }
}
function focusIndex(i){
  const item = calendar.value[i]
  if (!item || item.isPad) return
  focused.value = item.key
  // focus DOM element
  // small timeout to ensure panel elements exist
  setTimeout(()=>{
    const el = panel.value?.querySelector(`[aria-label="${ariaLabel(item)}"]`)
    el?.focus()
  },0)
}
function ariaLabel(cell){
  if (!cell || !cell.date) return ''
  return `${cell.day}-${cell.date.getMonth()+1}-${cell.date.getFullYear()}`
}

/* Outside click close */
function onDocClick(e){
  if (!panel.value) return
  if (!panel.value.contains(e.target) && !trigger.value.contains(e.target)){
    open.value = false
  }
}

/* Watches / lifecycle */
watch(() => props.modelValue, (v)=>{
  selectedDate.value = normalizeDate(v)
  if (selectedDate.value){
    visibleMonth.value = selectedDate.value.getMonth()
    visibleYear.value = selectedDate.value.getFullYear()
  }
})

onMounted(()=>{
  document.addEventListener('click', onDocClick)
})
onBeforeUnmount(()=>{
  document.removeEventListener('click', onDocClick)
})
</script>
