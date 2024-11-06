using System;
using System.Collections.Generic;

namespace Tarea1
{
    internal class Tablero
    {
        private List<string> Coordenadas = new List<string>();

        public Tablero()
        {
            AgregarCoordenadas();
        }


        //Se llena la lista de coordenadas de un tablero 8x8
        public void AgregarCoordenadas()
        {
            string[] columnas = { "a", "b", "c", "d", "e", "f", "g", "h" };
            for (int fila = 1; fila <= 8; fila++)
            {
                foreach (string columna in columnas)
                {
                    Coordenadas.Add($"{columna}{fila}");
                }
            }
        }

        // Obtiene la coordenada de ajedrez dada una fila y columna
        public string ObtenerCoordenada(int fila, int columna)
        {
            return Coordenadas[fila * 8 + columna];
        }

        // Imprime todas las coordenadas del tablero en formato 8x8
        public void ImprimirCoordenadas()
        {
            string separadorHorizontal = "-".PadLeft(4 * 8 - 1, '-');

            Console.ForegroundColor = ConsoleColor.DarkGray;

            for (int fila = 0; fila < 8; fila++)
            {
                for (int columna = 0; columna < 8; columna++)
                {
                    Console.Write($"{ObtenerCoordenada(fila, columna),-3}");
                    if (columna < 7)
                        Console.Write("|");
                }
                Console.WriteLine();

                if (fila < 7)
                    Console.WriteLine(separadorHorizontal);
            }
        }
    }
}
