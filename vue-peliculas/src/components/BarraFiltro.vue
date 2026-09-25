<script setup>
defineProps({
  filtroActual: {
    type: String,
    required: true
  }
})

const emit = defineEmits(['cambiar-filtro'])
</script>

<template>
  <div class="barra-filtro">
    <button
      :class="{ activo: filtroActual === 'todas' }"
      @click="emit('cambiar-filtro', 'todas')"
    >
      Todas
    </button>
    <button
      :class="{ activo: filtroActual === 'recomendadas' }"
      @click="emit('cambiar-filtro', 'recomendadas')"
    >
      Recomendadas
    </button>
  </div>
</template>

<style scoped>
.barra-filtro {
  margin-bottom: 16px;
}
button {
  margin-right: 8px;
  padding: 6px 12px;
  cursor: pointer;
}
.activo {
  background-color: #42b883;
  color: white;
  font-weight: bold;
}
</style>
