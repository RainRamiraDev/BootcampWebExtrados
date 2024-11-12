using solucionador.Interface;  // Correcto, para acceder a IPieza
using solucionador.Dominio;    // Correcto, para acceder a Reina
using Resolver8Piezas.Logica;            // Correcto, para acceder a Resolver8Piezas


Tablero presentacion = new Tablero();
presentacion.ImprimirCoordenadas();


IPieza pieza = new Alfil();
OchoPiezas solucionador = new OchoPiezas(pieza);
solucionador.Resolver();




