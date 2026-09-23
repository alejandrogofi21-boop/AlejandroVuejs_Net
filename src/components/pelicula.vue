<template>
  <div class="contenedor">
    <h1>Ejercicio: reactive + ref + computed + watch</h1>

    <section>
      <h2>Usuarios</h2>
      <ul>
        <li v-for="usuario in datos.usuarios" :key="usuario.id">
          <strong>{{ usuario.nombre }}</strong>
          — Género favorito: {{ usuario.generoFavorito }}
          — Estado:
          <span :class="usuario.activo ? 'activo' : 'inactivo'">
            {{ usuario.activo ? 'Activo' : 'Inactivo' }}
          </span>
        </li>
      </ul>
    </section>

    <section>
      <h2>Usuario actual seleccionado</h2>

      <!-- Selector con v-model: conecta directamente con usuarioActualId -->
      <label for="selectorUsuario">Elige un usuario: </label>
      <select id="selectorUsuario" v-model="usuarioActualId">
        <option v-for="usuario in datos.usuarios" :key="usuario.id" :value="usuario.id">
          {{ usuario.nombre }}
        </option>
      </select>

      <p>{{ usuarioActual?.nombre }} (le gusta: {{ usuarioActual?.generoFavorito }})</p>
    </section>

    <section>
      <h2>Película recomendada</h2>
      <button @click="mostrarRecomendada = true">Mostrar recomendada</button>
      <ul v-if="mostrarRecomendada">
        <li v-if="peliculasRecomendadas.length === 0">
          No hay coincidencias para este usuario
        </li>
        <li v-for="pelicula in peliculasRecomendadas" :key="pelicula.id">
          🎬 {{ pelicula.titulo }}
        </li>
      </ul>
    </section>

    <section>
      <h2>Todas las películas</h2>
      <ul>
        <li v-for="pelicula in datos.peliculas" :key="pelicula.id">
          {{ pelicula.titulo }} ({{ pelicula.genero }})
        </li>
      </ul>
    </section>
  </div>
</template>

<script setup>
import { reactive, ref, computed, watch } from 'vue'

// --- REACTIVE: objeto con películas y usuarios ---
const datos = reactive({
  peliculas: [
    { id: 1, titulo: 'Matrix', genero: 'Accion' },
    { id: 2, titulo: 'Titanic', genero: 'Drama' },
    { id: 3, titulo: 'El Conjuro', genero: 'Terror' },
    { id: 4, titulo: 'John Wick', genero: 'Accion' }
  ],
  usuarios: [
    { id: 1, nombre: 'Ana', activo: true, generoFavorito: 'Accion' },
    { id: 2, nombre: 'Luis', activo: false, generoFavorito: 'Drama' },
    { id: 3, nombre: 'Marta', activo: false, generoFavorito: 'Terror' }
  ]
})

// --- REF: id del usuario actualmente seleccionado ---
const usuarioActualId = ref(1)

// --- REF: controla si ya se pidió mostrar la recomendación ---
const mostrarRecomendada = ref(false)

// --- COMPUTED: encuentra el objeto completo del usuario actual ---
const usuarioActual = computed(() => {
  return datos.usuarios.find(u => u.id === usuarioActualId.value)
})

// --- COMPUTED: busca una película que coincida con el género favorito del usuario actual ---
const peliculasRecomendadas = computed(() => {
  if (!usuarioActual.value) return null
  return datos.peliculas.filter(p => p.genero === usuarioActual.value.generoFavorito)
})


// --- WATCH: vigila el array de usuarios (deep) y loguea cuando cambia el estado activo ---
watch(
  () => datos.usuarios,
  (usuariosNuevos, usuariosViejos) => {
    console.log('Se detectó un cambio en la lista de usuarios')
    usuariosNuevos.forEach(u => {
      console.log(`- ${u.nombre}: activo = ${u.activo}`)
    })
  },
  { deep: true }
)

watch(usuarioActualId, (nuevoId) => {
  datos.usuarios.forEach(usuario => {
    usuario.activo = usuario.id === nuevoId
  })
})
</script>

<style scoped>
.contenedor {
  max-width: 600px;
  margin: 0 auto;
  font-family: sans-serif;
}
.activo {
  color: green;
  font-weight: bold;
}
.inactivo {
  color: red;
}
button {
  margin-left: 8px;
  cursor: pointer;
}
.nota {
  margin-top: 20px;
  font-style: italic;
  color: gray;
}
</style>