// src/components/Counter.jsx
import React from 'react'; // Importamos React
import { useDispatch, useSelector } from 'react-redux'; // Importamos los hooks de Redux
import { increment, decrement } from '../slices/counterSlice'; // Importamos las acciones del slice

const Counter = () => {
  // Accedemos al valor del contador desde el estado global usando useSelector
  const value = useSelector((state) => state.counter.value);

  // Usamos useDispatch para despachar acciones (incrementar y decrementar)
  const dispatch = useDispatch();

  return (
    <div>
      <h1>Contador: {value}</h1>
      <button onClick={() => dispatch(increment())}>Incrementar</button>
      <button onClick={() => dispatch(decrement())}>Decrementar</button>
    </div>
  );
};

export default Counter;
