using solucionador.Interface;  
using solucionador.Dominio;   
using Resolver8Piezas.Logica; 


Tablero presentacion = new Tablero();
presentacion.ImprimirCoordenadas();


IPieza pieza = new Alfil();
OchoPiezas solucionador = new OchoPiezas(pieza);
solucionador.Resolver();




