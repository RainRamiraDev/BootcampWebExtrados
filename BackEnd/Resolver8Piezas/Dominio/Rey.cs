using solucionador.Interface;
using System;

namespace solucionador.Dominio
{
    public class Rey : IPieza
    {
        public bool EsSeguro(int[] posicionesPiezas, int fila, int columna)
        {
            // Verifica si hay algún rey en una posición adyacente en filas anteriores
            for (int i = 0; i < fila; i++)
            {
                int otraColumna = posicionesPiezas[i];

                // Verifica las casillas adyacentes
                if (Math.Abs(otraColumna - columna) <= 1 && Math.Abs(i - fila) == 1)
                {
                    return false; // Si hay una pieza en una casilla adyacente, no es seguro
                }
            }
            return true; // Si no hay piezas adyacentes, es seguro
        }

        public string getNombre()
        {
            return "Rey";
        }
    }
}
