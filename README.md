# AlejandroVuejs_Net

Proyecto de aprendizaje de Vue.js 3, documentando el avance paso a paso.

## Progreso

### 1. Creación del proyecto
Proyecto creado con `npm create vue@latest` (Vue 3 + Vite). Conectado a este repositorio de GitHub.

### 2. `DataBindingEjemplo.vue`
Sintaxis de template y data binding: interpolación `{{ }}`, `v-html`, `v-bind` (`:class`, `:style`, atributos booleanos).

### 3. Directivas
`v-if` / `v-else` / `v-else-if`, `v-show`, `v-for` (con `:key`), `v-model`.

### 4-6. Componentes, Props, Emits y Slots
Tres componentes reutilizables usados desde `Peliculas.vue`:
- **`TarjetaPelicula.vue`** → recibe la película por **prop**, navega al detalle al hacer clic (Router).
- **`BarraFiltro.vue`** → **emit** `cambiar-filtro` para avisar al padre qué filtro se eligió.
- **`SelectorUsuario.vue`** → **props** + `v-model` personalizado + **slots con datos** (scoped slots) para personalizar cómo se ve el selector y el usuario actual.

### 7. Composition API
`ref`, `reactive`, `computed` (usuario actual, películas filtradas) y `watch` (activa/desactiva usuarios, log con `deep: true`).

### 8. Vue Router
`vue-router` instalado y configurado en `src/router/index.js`. Rutas:
- `/` → `Peliculas.vue`
- `/peliculas/:id` → `DetallePelicula.vue`

Navegación con `router.push()` desde las tarjetas, y lectura del parámetro con `useRoute()` + `watch` (`immediate: true`).

### 9. Pinia
Estado centralizado en `src/stores/peliculas.js` (`usePeliculasStore`), usado tanto por `Peliculas.vue` como por `DetallePelicula.vue`, eliminando datos duplicados entre componentes.

### 10. Axios
`cargarPeliculas()` en el store consume la API pública de Studio Ghibli (`https://ghibliapi.vercel.app/films`), manejando los estados de carga, error y éxito.

## Cómo correr el proyecto

```bash
npm install
npm run dev
```
