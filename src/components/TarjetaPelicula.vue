<script setup>
defineProps({
  pelicula: {
    type: Object,
    required: true
  }
})
</script>

<template>
  <div class="tarjeta-pelicula">
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
