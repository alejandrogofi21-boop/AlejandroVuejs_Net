<script setup>
import { ref, watch } from 'vue'
import { useRoute, useRouter } from 'vue-router'

const route = useRoute()
const router = useRouter()

// Mismos datos de ejemplo (en el Paso 10, esto vendrá de una API con Axios)
const peliculas = [
  { id: 1, titulo: 'Matrix', genero: 'Accion', imagen: 'https://placehold.co/300x400?text=Matrix', descripcion: 'Un hacker descubre que la realidad es una simulación.' },
  { id: 2, titulo: 'Titanic', genero: 'Drama', imagen: 'https://placehold.co/300x400?text=Titanic', descripcion: 'Una historia de amor en el trasatlántico más famoso de la historia.' },
  { id: 3, titulo: 'El Conjuro', genero: 'Terror', imagen: 'https://placehold.co/300x400?text=El+Conjuro', descripcion: 'Investigadores paranormales ayudan a una familia atormentada.' },
  { id: 4, titulo: 'John Wick', genero: 'Accion', imagen: 'https://placehold.co/300x400?text=John+Wick', descripcion: 'Un asesino retirado vuelve a la acción por venganza.' }
]

const pelicula = ref(null)

watch(
  () => route.params.id,
  (nuevoId) => {
    const id = Number(nuevoId)
    pelicula.value = peliculas.find(p => p.id === id)
  },
  { immediate: true }
)

function volver() {
  router.push('/')
}
</script>

<template>
  <div class="detalle" v-if="pelicula">
    <button @click="volver">← Volver</button>
    <img :src="pelicula.imagen" :alt="pelicula.titulo" />
    <h1>{{ pelicula.titulo }}</h1>
    <p class="genero">{{ pelicula.genero }}</p>
    <p>{{ pelicula.descripcion }}</p>
  </div>
  <div v-else>
    <p>Película no encontrada</p>
    <button @click="volver">← Volver</button>
  </div>
</template>

<style scoped>
.detalle {
  max-width: 400px;
  margin: 0 auto;
  text-align: center;
}
.detalle img {
  width: 100%;
  border-radius: 8px;
}
.genero {
  color: gray;
}
button {
  margin-bottom: 16px;
  cursor: pointer;
}
</style>
