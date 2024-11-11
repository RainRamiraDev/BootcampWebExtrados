

using System;
using Tarea1;


Tablero nuevoTablero = new Tablero();
Console.WriteLine("Estas son las Coordenadas del tablero de ajedrez:");
nuevoTablero.ImprimirCoordenadas();

Console.WriteLine("\n");

Console.ForegroundColor = ConsoleColor.Magenta;

Reina ochoReinas = new Reina();
ochoReinas.Resolver();
