import { defineStore } from 'pinia'
import { reactive, ref, computed, watch } from 'vue'

export const usePeliculasStore = defineStore('peliculas', () => {
  // --- REACTIVE: mismo estado que ya tenías ---
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
    return datos.peliculas.filter(p => p.genero === usuarioActual.value.generoFavorito)
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

  // --- IMPORTANTE: hay que exponer (return) todo lo que quieras usar afuera ---
  return {
    datos,
    usuarioActualId,
    filtro,
    usuarioActual,
    peliculasFiltradas,
    cambiarFiltro
  }
})
