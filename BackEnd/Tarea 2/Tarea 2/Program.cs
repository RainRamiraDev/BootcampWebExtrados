using solucionador.Interface;  
using solucionador.Dominio;   
using Resolver8Piezas.Logica;
using Resolver8Piezas.Dominio;


Tablero presentacion = new Tablero();
presentacion.ImprimirCoordenadas();



IPieza pieza = new SinSolucion();
OchoPiezas solucionador = new OchoPiezas(pieza);
solucionador.Resolver();




