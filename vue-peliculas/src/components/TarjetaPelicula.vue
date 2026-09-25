<script setup>

import { useRouter } from 'vue-router'

const router = useRouter()

const props = defineProps({
  pelicula: {
    type: Object,
    required: true
  }
})


function irADetalle() {
  router.push(`/peliculas/${props.pelicula.id}`)
}

</script>

<template>
  <div class="tarjeta-pelicula" @click="irADetalle">
    <img :src="pelicula.imagen" :alt="pelicula.titulo" />
    <h3>{{ pelicula.titulo }}</h3>
    <p class="genero">{{ pelicula.genero }}</p>
  </div>
</template>

<style scoped>
.tarjeta-pelicula {
  border: 1px solid #ddd;
  border-radius: 8px;
  padding: 10px;
  width: 160px;
  text-align: center;
}
.tarjeta-pelicula img {
  width: 100%;
  border-radius: 4px;
}
.genero {
  color: gray;
  font-size: 0.9em;
}
</style>
