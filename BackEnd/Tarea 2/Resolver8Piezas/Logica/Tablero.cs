
using System;
using System.Collections.Generic;

namespace Resolver8Piezas.Logica
{
    public class Tablero
    {
        private List<string> Coordenadas = new List<string>();

        public Tablero()
        {
            AgregarCoordenadas();
        }

        // Se llena la lista de coordenadas de un tablero 8x8
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

        // Obtiene la coordenada de ajedrez dada una fila y columna (1-8)
        public string ObtenerCoordenada(int fila, int columna)
        {
            // Verificar que fila y columna estén en el rango 1-8 antes de continuar
            if (fila < 1 || fila > 8 || columna < 1 || columna > 8)
            {
                throw new ArgumentOutOfRangeException("Fila y columna deben estar entre 1 y 8.");
            }

            int indice = (fila - 1) * 8 + (columna - 1);
            return Coordenadas[indice];
        }


        // Imprime todas las coordenadas del tablero en formato 8x8
        public void ImprimirCoordenadas()
        {
            string separadorHorizontal = "-".PadLeft(4 * 8 - 1, '-');

            Console.ForegroundColor = ConsoleColor.DarkGray;

            for (int fila = 1; fila <= 8; fila++)
            {
                for (int columna = 1; columna <= 8; columna++)
                {
                    Console.Write($"{ObtenerCoordenada(fila, columna),-3}");
                    if (columna < 8)
                        Console.Write("|");
                }
                Console.WriteLine();

                if (fila < 8)
                    Console.WriteLine(separadorHorizontal);
            }
            Console.ResetColor();
        }
    }
}
