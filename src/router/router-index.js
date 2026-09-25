import { createRouter, createWebHistory } from 'vue-router'
import Peliculas from '../components/Peliculas.vue'
import DetallePelicula from '../components/DetallePelicula.vue'

const routes = [
  {
    path: '/',
    name: 'peliculas',
    component: Peliculas
  },
  {
    path: '/peliculas/:id',
    name: 'detalle-pelicula',
    component: DetallePelicula
  }
]

const router = createRouter({
  history: createWebHistory(),
  routes
})

export default router
