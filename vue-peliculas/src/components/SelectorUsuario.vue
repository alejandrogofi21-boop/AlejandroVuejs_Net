<script setup>
import { computed } from 'vue'

const props = defineProps({
  usuarios: {
    type: Array,
    required: true
  },
  modelValue: {
    type: Number,
    required: true
  }
})

const emit = defineEmits(['update:modelValue'])

const usuarioActual = computed(() =>
  props.usuarios.find(u => u.id === props.modelValue)
)

function seleccionar(id) {
  emit('update:modelValue', id)
}
</script>

<template>
  <div class="selector-usuario">
    <!--
      SLOT "selector": el padre puede reemplazar CÓMO se ve el control
      de selección. Le pasamos datos útiles (usuarios, id seleccionado,
      y la función seleccionar) para que el padre pueda usarlos.
      Si el padre no personaliza nada, se usa el <select> por defecto.
    -->
    <slot
      name="selector"
      :usuarios="usuarios"
      :seleccionado="modelValue"
      :seleccionar="seleccionar"
    >
      <select :value="modelValue" @change="seleccionar(Number($event.target.value))">
        <option v-for="u in usuarios" :key="u.id" :value="u.id">
          {{ u.nombre }}
        </option>
      </select>
    </slot>

    <!--
      SLOT "usuario-actual": el padre puede reemplazar CÓMO se muestra
      el usuario seleccionado. Le pasamos el objeto completo del usuario.
    -->
    <slot name="usuario-actual" :usuario="usuarioActual">
      <p>Usuario actual: {{ usuarioActual?.nombre }}</p>
    </slot>
  </div>
</template>

<style scoped>
.selector-usuario {
  margin-bottom: 16px;
}
</style>
