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
