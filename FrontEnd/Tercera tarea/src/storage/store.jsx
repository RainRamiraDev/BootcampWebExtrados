// src/storage/store.js
import { configureStore } from '@reduxjs/toolkit';
import counterReducer from '../slices/counterSlice'; // Importamos el reducer de nuestro slice

// Configuramos el store con el slice del contador
const store = configureStore({
  reducer: {
    counter: counterReducer, // Reducer para el contador
  },
});

export default store; // Exportamos el store para usarlo en el Provider
