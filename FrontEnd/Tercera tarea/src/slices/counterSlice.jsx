// src/slices/counterSlice.js
import { createSlice } from '@reduxjs/toolkit';

// Creamos el slice del contador
const counterSlice = createSlice({
  name: 'counter', // Nombre del slice
  initialState: { value: 0 }, // Estado inicial
  reducers: {
    // Acción para incrementar el contador
    increment: (state) => {
      state.value += 1;
    },
    // Acción para decrementar el contador
    decrement: (state) => {
      state.value -= 1;
    },
  },
});

// Exportamos las acciones que podemos usar en los componentes
export const { increment, decrement } = counterSlice.actions;

// Exportamos el reducer para usarlo en la configuración del store
export default counterSlice.reducer;
