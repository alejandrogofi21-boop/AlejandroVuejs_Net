<template>
  <div class="ejemplo">
    <h1>Ejemplos de Data Binding</h1>

    <!-- 1. Interpolación de texto -->
    <p>Texto plano: {{ mensaje }}</p>

    <!-- 2. v-html (renderiza HTML real) -->
    <p v-html="mensajeHtml"></p>

    <!-- 3. v-bind (atributo dinámico) -->
    <img :src="imagenUrl" :alt="descripcionImagen" width="150" />

    <!-- 4. v-bind en un atributo de estilo -->
    <p :style="{ color: colorTexto }">Este texto cambia de color dinámicamente</p>

    <!-- 5. v-bind en class -->
    <p :class="{ activo: estaActivo }">Esta clase se activa condicionalmente</p>
  </div>
</template>

<script setup>
import { ref } from 'vue'

const mensaje = ref('Hola, este es texto plano')
const mensajeHtml = ref('<strong>Hola</strong>, este texto está en <em>negrita y cursiva</em>')
const imagenUrl = ref('https://vuejs.org/images/logo.png')
const descripcionImagen = ref('Logo de Vue')
const colorTexto = ref('blue')
const estaActivo = ref(true)
</script>

<style scoped>
.activo {
  font-weight: bold;
  color: green;
}
</style>