import { defineStore } from 'pinia'
import { reactive, ref, computed, watch } from 'vue'
import axios from 'axios'

export const usePeliculasStore = defineStore('peliculas', () => {
  // --- REACTIVE: mismo estado que ya tenías ---
  const datos = reactive({
    peliculas: [],
    usuarios: [
      { id: 1, nombre: 'Ana', activo: true, directorFavorito: 'Hayao Miyazaki' },
      { id: 2, nombre: 'Luis', activo: false, directorFavorito: 'Gorō Miyazaki' },
      { id: 3, nombre: 'Marta', activo: false, directorFavorito: 'Hiromasa Yonebayashi' }
    ]
  })

  const cargando = ref(false)
  const error = ref(null)

  // --- REF: mismo estado que ya tenías ---
  const usuarioActualId = ref(1)
  const filtro = ref('todas')

  // --- COMPUTED: mismos que ya tenías ---
  const usuarioActual = computed(() =>
    datos.usuarios.find(u => u.id === usuarioActualId.value)
  )

  const peliculasFiltradas = computed(() => {
    if (filtro.value === 'todas') return datos.peliculas
    if (!usuarioActual.value) return []
    return datos.peliculas.filter(p => p.director === usuarioActual.value.directorFavorito)
  })

  // --- WATCH: mismos que ya tenías ---
  watch(usuarioActualId, (nuevoId) => {
    datos.usuarios.forEach(u => {
      u.activo = u.id === nuevoId
    })
  })

  watch(
    () => datos.usuarios,
    (usuarios) => {
      console.log('Cambió el estado de usuarios:')
      usuarios.forEach(u => console.log(`- ${u.nombre}: activo = ${u.activo}`))
    },
    { deep: true }
  )

  // --- FUNCIÓN: la que usaba BarraFiltro ---
  function cambiarFiltro(nuevoFiltro) {
    filtro.value = nuevoFiltro
  }

   async function cargarPeliculas() {
    cargando.value = true
    error.value = null
    try {
      const respuesta = await axios.get('https://ghibliapi.vercel.app/films')
      // Transformamos los datos de la API al formato que ya usa nuestra app
      datos.peliculas = respuesta.data.map(p => ({
        id: p.id,
        titulo: p.title,
        director: p.director, // la API no trae género real
        imagen: p.movie_banner || p.image,
        descripcion: p.description
      }))
    } catch (err) {
      error.value = 'No se pudieron cargar las películas. Intenta de nuevo.'
      console.error(err)
    } finally {
      cargando.value = false
    }
  }

  // --- IMPORTANTE: hay que exponer (return) todo lo que quieras usar afuera ---
  return {
    datos,
    usuarioActualId,
    filtro,
    usuarioActual,
    peliculasFiltradas,
    cambiarFiltro,
    cargarPeliculas,
    cargando,
    error
  }
})


