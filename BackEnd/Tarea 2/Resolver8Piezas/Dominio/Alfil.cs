using solucionador.Interface;
using System;

namespace solucionador.Dominio
{
    public class Alfil : IPieza
    {
        public bool EsSeguro(int[] posicionesPiezas, int fila, int columna)
        {
            // Verifica las diagonales para el alfil.
            for (int i = 0; i < fila; i++)
            {
                // Comprobamos si hay una pieza en las diagonales.
                // La fórmula para las diagonales es que la diferencia de las filas debe ser igual a la diferencia de las columnas para la diagonal principal.
                // Y la suma de las filas debe ser igual a la suma de las columnas para la diagonal secundaria.

                // Diagonal principal
                if (Math.Abs(posicionesPiezas[i] - columna) == Math.Abs(i - fila))
                {
                    return false; // Si hay una pieza en la diagonal, no es seguro.
                }

                // Diagonal secundaria
                if (posicionesPiezas[i] + i == columna + fila)
                {
                    return false; // Si hay una pieza en la diagonal secundaria, no es seguro.
                }
            }
            return true; // Si no se encontró ninguna pieza en las diagonales, es seguro.
        }


        public string getNombre()
        {
            return "Alfil";
        }
    }
}
