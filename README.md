# AlejandroVuejs_Net

Proyecto de aprendizaje de Vue.js 3, documentando el avance paso a paso.

## 📚 Progreso

### 1. Creación del proyecto
Proyecto creado con `npm create vue@latest` (Vue 3 + Vite), sin TypeScript, Router ni Pinia iniciales (se agregarán en pasos posteriores). Conectado a este repositorio de GitHub.

### 2. `DataBindingEjemplo.vue`
Ejemplos de sintaxis de template y data binding:
- Interpolación de texto con `{{ }}`
- `v-html` para renderizar HTML real
- `v-bind` (`:atributo`) para atributos dinámicos, incluyendo `:class`, `:style` y atributos booleanos como `:disabled`

### 3. `Peliculas.vue`
Ejercicio integrador de reactividad con Composition API:
- **`reactive`** → objeto con la lista de películas y usuarios
- **`ref`** → usuario seleccionado actualmente (conectado a un `<select>` con `v-model`)
- **`computed`** → obtiene el usuario actual a partir de su id
- **`watch`** → 
  - detecta cambios en el usuario seleccionado y activa/desactiva usuarios automáticamente
  - vigila (`deep: true`) el array de usuarios y muestra en consola cuando cambia el estado de alguno
- Botón que calcula la recomendación de películas "congelada" (usando `.filter()`), demostrando la diferencia entre `computed` (reactivo automático) y `ref` + función (cálculo manual)

## 🛠️ Cómo correr el proyecto

```bash
npm install
npm run dev
```