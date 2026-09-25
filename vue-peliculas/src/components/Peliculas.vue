<script setup>
import { onMounted } from 'vue'
import SelectorUsuario from './SelectorUsuario.vue'
import BarraFiltro from './BarraFiltro.vue'
import TarjetaPelicula from './TarjetaPelicula.vue'
import { usePeliculasStore } from '../stores/peliculas'

const peliculasStore = usePeliculasStore()

onMounted(() => {
  peliculasStore.cargarPeliculas()
})

</script>

<template>
  <div class="pagina">
    <h1>Catálogo de películas</h1>

    <SelectorUsuario
      :usuarios="peliculasStore.datos.usuarios"
      v-model="peliculasStore.usuarioActualId"
    >
      <template #selector="{ usuarios, seleccionado, seleccionar }">
        <div class="botones-usuario">
          <button
            v-for="u in usuarios"
            :key="u.id"
            :class="{ 'usuario-elegido': u.id === seleccionado }"
            @click="seleccionar(u.id)"
          >
            {{ u.nombre }}
          </button>
        </div>
      </template>

      <template #usuario-actual="{ usuario }">
        <div class="tarjeta-usuario-actual" v-if="usuario">
          👤 Viendo como <strong>{{ usuario.nombre }}</strong>
          (le gusta: {{ usuario.directorFavorito }})
        </div>
      </template>
    </SelectorUsuario>

    <BarraFiltro
      :filtro-actual="peliculasStore.filtro"
      @cambiar-filtro="peliculasStore.cambiarFiltro"
    />
    <p v-if="peliculasStore.cargando">Cargando películas...</p>

    <!-- Estado: ERROR -->
    <p v-else-if="peliculasStore.error" class="error">{{ peliculasStore.error }}</p>

    <!-- Estado: ÉXITO -->
    <div v-else class="lista-peliculas">
      <TarjetaPelicula
        v-for="pelicula in peliculasStore.peliculasFiltradas"
        :key="pelicula.id"
        :pelicula="pelicula"
      />
      <p v-if="peliculasStore.peliculasFiltradas.length === 0">No hay películas para mostrar</p>
    </div>
  </div>
</template>

<style scoped>
.pagina {
  max-width: 700px;
  margin: 0 auto;
  font-family: sans-serif;
}
.botones-usuario button {
  margin-right: 6px;
  padding: 6px 10px;
  cursor: pointer;
}
.usuario-elegido {
  background-color: #42b883;
  color: white;
  font-weight: bold;
}
.tarjeta-usuario-actual {
  margin-top: 8px;
  padding: 8px;
  background-color: #f0f0f0;
  border-radius: 6px;
  display: inline-block;
}
.lista-peliculas {
  display: flex;
  flex-wrap: wrap;
  gap: 12px;
  margin-top: 16px;
}
</style>
