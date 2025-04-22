import React, { useState, useEffect } from 'react';
import './Usuario.css'; // Lo creamos después

function Usuario({ nombre, edad, activo }) {
  const [usuarioNombre, setUsuarioNombre] = useState('');
  const [usuarioEdad, setUsuarioEdad] = useState(null);
  const [usuarioActivo, setUsuarioActivo] = useState(false);

  useEffect(() => {
    setUsuarioNombre(nombre);
    setUsuarioEdad(edad);
    setUsuarioActivo(activo);
  }, [nombre, edad, activo]);

  return (
    <div className={`usuario-card ${usuarioActivo ? 'activo' : 'inactivo'}`}>
      <h2>{usuarioNombre ? `Hola, ${usuarioNombre}` : 'Usuario sin nombre'}</h2>
      {usuarioEdad !== null && <p>Edad: {usuarioEdad}</p>}
      <p>
        Estado: <strong>{usuarioActivo ? 'Activo' : 'Inactivo'}</strong>
      </p>
    </div>
  );
}

export default Usuario;
