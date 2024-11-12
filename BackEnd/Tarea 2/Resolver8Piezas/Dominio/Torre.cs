using solucionador.Interface;
using System;

namespace solucionador.Dominio
{
    public class Torre : IPieza
    {
        public bool EsSeguro(int[] posicionesPiezas, int fila, int columna)
        {
            // La torre puede atacar solo en su fila y columna, pero no en las diagonales
            for (int i = 0; i < fila; i++)
            {
                int otraColumna = posicionesPiezas[i];
                if (otraColumna == columna) // Columna conflictiva
                    return false;
            }
            return true; // Si no hay conflicto en la columna, es seguro
        }

        public string getNombre()
        {
            return "Torre";
        }

        public string ObtenerCoordenada(int fila, int columna)
        {
            throw new NotImplementedException();
        }
    }
}
