using solucionador.Interface;
using System;

namespace solucionador.Dominio
{
    public class Peon : IPieza
    {
        public bool EsSeguro(int[] posicionesPiezas, int fila, int columna)
        {
            // Verificar si hay otro peón en la misma columna o en las diagonales inmediatas de la fila anterior
            for (int i = 0; i < fila; i++)
            {
                int otraColumna = posicionesPiezas[i];

                // Misma columna o una de las diagonales de ataque
                if (columna == otraColumna ||
                    Math.Abs(otraColumna - columna) == 1 && Math.Abs(i - fila) == 1)
                {
                    return false;
                }
            }
            return true;
        }

        public string getNombre()
        {
            return "Peon";
        }
    }
}
