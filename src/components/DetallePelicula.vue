<script setup>
import { ref, watch } from 'vue'
import { useRoute, useRouter } from 'vue-router'
import { usePeliculasStore } from '../stores/peliculas'

const route = useRoute()
const router = useRouter()
const peliculasStore = usePeliculasStore()

const pelicula = ref(null)

// watch + immediate: true, en vez de onMounted (más robusto, como vimos)
watch(
  () => route.params.id,
  (nuevoId) => {
    const id = Number(nuevoId)
    pelicula.value = peliculasStore.datos.peliculas.find(p => p.id === id)
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
