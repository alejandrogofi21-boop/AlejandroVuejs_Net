<script setup>
import { reactive, ref, computed, watch } from 'vue'
import SelectorUsuario from './SelectorUsuario.vue'
import BarraFiltro from './BarraFiltro.vue'
import TarjetaPelicula from './TarjetaPelicula.vue'

// --- REACTIVE: estado central de la app ---
const datos = reactive({
  peliculas: [
    { id: 1, titulo: 'Matrix', genero: 'Accion', imagen: 'https://placehold.co/160x220?text=Matrix' },
    { id: 2, titulo: 'Titanic', genero: 'Drama', imagen: 'https://placehold.co/160x220?text=Titanic' },
    { id: 3, titulo: 'El Conjuro', genero: 'Terror', imagen: 'https://placehold.co/160x220?text=El+Conjuro' },
    { id: 4, titulo: 'John Wick', genero: 'Accion', imagen: 'https://placehold.co/160x220?text=John+Wick' }
  ],
  usuarios: [
    { id: 1, nombre: 'Ana', activo: true, generoFavorito: 'Accion' },
    { id: 2, nombre: 'Luis', activo: false, generoFavorito: 'Drama' },
    { id: 3, nombre: 'Marta', activo: false, generoFavorito: 'Terror' }
  ]
})

// --- REF: usuario seleccionado y filtro activo ---
const usuarioActualId = ref(1)
const filtro = ref('todas')

// --- COMPUTED: usuario actual completo ---
const usuarioActual = computed(() =>
  datos.usuarios.find(u => u.id === usuarioActualId.value)
)

// --- COMPUTED: lista de películas según el filtro elegido ---
const peliculasFiltradas = computed(() => {
  if (filtro.value === 'todas') {
    return datos.peliculas
  }
  if (!usuarioActual.value) return []
  return datos.peliculas.filter(p => p.genero === usuarioActual.value.generoFavorito)
})

// --- WATCH: al cambiar de usuario, lo activamos y desactivamos a los demás ---
watch(usuarioActualId, (nuevoId) => {
  datos.usuarios.forEach(u => {
    u.activo = u.id === nuevoId
  })
})

// --- WATCH: log cuando cambia el estado activo de algún usuario ---
watch(
  () => datos.usuarios,
  (usuarios) => {
    console.log('Cambió el estado de usuarios:')
    usuarios.forEach(u => console.log(`- ${u.nombre}: activo = ${u.activo}`))
  },
  { deep: true }
)

function cambiarFiltro(nuevoFiltro) {
  filtro.value = nuevoFiltro
}
</script>

<template>
  <div class="pagina">
    <h1>Catálogo de películas</h1>

    <SelectorUsuario :usuarios="datos.usuarios" v-model="usuarioActualId">
      <!-- Personalizamos el slot "selector": botones en vez de <select> -->
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

      <!-- Personalizamos el slot "usuario-actual": una tarjeta con más estilo -->
      <template #usuario-actual="{ usuario }">
        <div class="tarjeta-usuario-actual" v-if="usuario">
          👤 Viendo como <strong>{{ usuario.nombre }}</strong>
          (le gusta: {{ usuario.generoFavorito }})
        </div>
      </template>
    </SelectorUsuario>

    <!-- BarraFiltro: le pasamos el filtro actual (prop) y escuchamos su emit -->
    <BarraFiltro :filtro-actual="filtro" @cambiar-filtro="cambiarFiltro" />

    <!-- TarjetaPelicula: una por cada película filtrada, usando props -->
    <div class="lista-peliculas">
      <TarjetaPelicula
        v-for="pelicula in peliculasFiltradas"
        :key="pelicula.id"
        :pelicula="pelicula"
      />
      <p v-if="peliculasFiltradas.length === 0">No hay películas para mostrar</p>
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
