# Trabajo Final Backend - Curso Extrados 2024




![Grafico](https://yuml.me/4342fb33.png)




## Introducción

El trabajo final consiste en la programación de un backend para un sistema de administración de torneos de eliminación online de juegos de cartas coleccionables.

---

## Funcionalidades Principales

### Cartas
- Las cartas se publican en **series**.
- Una carta puede pertenecer a una o múltiples series (Ejemplo: carta X pertenece a la serie 1, carta Y pertenece tanto a la serie 1 como 2).

### Mazos
- Un mazo de cartas contiene **15 cartas únicas** (no se permiten cartas repetidas).

### Juegos/Partidas
- Un juego:
  - Tiene una duración máxima de **30 minutos**.
  - Es de **1 jugador vs 1 jugador**.
  - Siempre tiene un **ganador** (no se permiten empates).

---

## Torneos

### Generalidades
- Un torneo es organizado por un **Organizador**.
- El organizador asigna **Jueces** para oficializar los resultados.
- El sistema debe planificar los días y horarios de los juegos según la cantidad de jugadores y el tiempo disponible.
- Cada torneo puede **limitar las series de cartas** permitidas para jugar.

### Fases del Torneo
1. **Fase de Registro**
   - Los jugadores pueden registrarse con un mazo de cartas válido.
   - El mazo debe contener cartas que pertenezcan a las series aceptadas por el torneo.
   - El organizador cierra manualmente el registro.

2. **Fase de Torneo**
   - Durante esta fase:
     - Se evita que nuevos jugadores se inscriban.
     - Se planifican los días y horarios de los juegos para la primera ronda.
   - Los juegos se organizan en rondas de eliminación:
     - Los perdedores son eliminados.
     - Los ganadores avanzan a la siguiente ronda.
   - El sistema actualiza automáticamente la planificación entre rondas.

3. **Fase de Finalización**
   - El torneo se marca como **finalizado** una vez que se oficializa el resultado de la final.

---

## Roles

### Administrador
- **Permisos**:
  - Crear, editar y eliminar administradores, organizadores, jueces y jugadores.
  - Ver y cancelar torneos.
- **Restricciones**:
  - Debe existir al menos un administrador en la base de datos.
  - No se pueden registrar administradores directamente.

### Organizador
- **Permisos**:
  - Crear, editar y cancelar torneos.
  - Crear jueces.
  - Avanzar el torneo entre fases.
  - Modificar juegos del torneo.
- **Restricciones**:
  - Solo puede ser creado por un administrador.

### Juez
- **Permisos**:
  - Oficializar el resultado de un juego.
  - Descalificar a un jugador de un torneo.
- **Restricciones**:
  - Solo puede ser creado por un administrador o un juez autorizado.

### Jugador
- **Permisos**:
  - Registrar las cartas que posee en su colección.
  - Inscribirse en un torneo.
  - Armar un mazo de cartas con su colección.
- **Restricciones**:
  - Solo pueden registrarse en torneos habilitados.

---

## Información Básica a Guardar

### Jugador
- Nombre y apellido.
- Alias (único).
- País.
- Email.
- Juegos ganados y perdidos.
- Torneos ganados.
- Descalificaciones y sus razones.
- Foto/avatar.
- Lista de cartas que posee.

### Juez
- Nombre y apellido.
- Alias (único).
- Email.
- País.
- Torneos que oficializó.
- Foto/avatar.

### Organizador
- Nombre y apellido.
- Email.
- País.
- Torneos organizados.

### Administrador
- Usuario.

### Torneo
- Fecha y hora de inicio.
- Fecha y hora de fin.
- País.
- Lista de jueces.
- Series de cartas habilitadas.
- Fase actual.
- Jugadores inscritos y sus mazos.
- Resultados de los juegos.
- Ganador.

### Juegos
- Fecha y hora de inicio.
- Fecha y hora de fin.
- Jugadores participantes.
- Torneo al que pertenece.
- Ganador.

### Cartas
- Ilustración.
- Ataque.
- Defensa.
- Series a las que pertenece.

### Series
- Nombre.
- Lista de cartas que pertenecen a la serie.
- Fecha de salida.

---

## Notas Finales
- El administrador debe poder ver quién creó a cada organizador/juez.
- Los jueces solo pueden oficializar juegos de torneos en los que están autorizados y después de que hayan comenzado.
- Los jugadores solo pueden ver el alias de otros jugadores y jueces. Solo los organizadores y administradores pueden ver nombres y apellidos.
- El alias de jugadores y jueces debe ser **único**.

