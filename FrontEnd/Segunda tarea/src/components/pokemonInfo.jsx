// src/components/PokemonInfo.jsx
import React, { useEffect, useState } from 'react';
import axios from 'axios';
import './pokemonInfoStyle.css';

const PokemonInfo = () => {
  // Definir el estado para los Pokémon, cargando y error
  const [pokemons, setPokemons] = useState([]);  // Lista de todos los Pokémon
  const [pokemonDetails, setPokemonDetails] = useState(null);  // Detalles de cada Pokémon
  const [cargando, setCargando] = useState(true);  // Estado de carga
  const [error, setError] = useState(null);  // Estado de error
  const [currentIndex, setCurrentIndex] = useState(0);  // Índice actual del carrusel

  // Función para obtener los Pokémon desde la API
  useEffect(() => {
    const obtenerPokemons = async () => {
      try {
        // Obtener la lista de los primeros 100 Pokémon
        const respuesta = await axios.get('https://pokeapi.co/api/v2/pokemon?limit=100');
        setPokemons(respuesta.data.results);
        // Obtener los detalles del primer Pokémon
        const detalles = await axios.get(respuesta.data.results[0].url);
        setPokemonDetails(detalles.data);
      } catch (err) {
        setError('No se pudo cargar los Pokémon');
        console.error(err);
      } finally {
        setCargando(false);
      }
    };

    obtenerPokemons();
  }, []);

  // Si está cargando, mostrar un mensaje de carga
  if (cargando) return <p>Cargando...</p>;

  // Si hay error, mostrar el mensaje de error
  if (error) return <p>{error}</p>;

  // Función para cambiar al siguiente Pokémon en el carrusel
  const siguientePokemon = () => {
    const siguienteIndex = (currentIndex + 1) % pokemons.length;
    setCurrentIndex(siguienteIndex);
    obtenerDetallesPokemon(siguienteIndex);  // Cargar detalles del siguiente Pokémon
  };

  // Función para cambiar al Pokémon anterior en el carrusel
  const pokemonAnterior = () => {
    const anteriorIndex = (currentIndex - 1 + pokemons.length) % pokemons.length;
    setCurrentIndex(anteriorIndex);
    obtenerDetallesPokemon(anteriorIndex);  // Cargar detalles del Pokémon anterior
  };

  // Función para obtener los detalles de un Pokémon dado su índice
  const obtenerDetallesPokemon = async (index) => {
    const url = pokemons[index].url;
    try {
      const respuesta = await axios.get(url);
      setPokemonDetails(respuesta.data);
    } catch (err) {
      console.error(err);
      setError('No se pudo cargar los detalles del Pokémon');
    }
  };

  return (
    <div className="carousel-container">
      <h1 className="titulo">POKEDEX</h1>
      <div className="card">
        <h2 className="pokemonName">{pokemonDetails?.name.toUpperCase()}</h2>
        <img
          src={pokemonDetails?.sprites.front_default}
          alt={pokemonDetails?.name}
          className="image"
        />
        <p><strong>Altura:</strong> {pokemonDetails?.height}</p>
        <p><strong>Peso:</strong> {pokemonDetails?.weight}</p>
        <p><strong>Tipo:</strong> {pokemonDetails?.types.map(t => t.type.name).join(', ')}</p>

        {/* Botones de navegación dentro de la tarjeta */}
        <div className="carousel-controls">
          <button onClick={pokemonAnterior} className="prev-btn">Anterior</button>
          <button onClick={siguientePokemon} className="next-btn">Siguiente</button>
        </div>
      </div>
    </div>
  );
};

export default PokemonInfo;
