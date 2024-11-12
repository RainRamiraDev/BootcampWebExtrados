using solucionador.Interface;
using System;

namespace solucionador.Dominio
{
    public class Caballo : IPieza
    {
        public bool EsSeguro(int[] posicionesPiezas, int fila, int columna)
        {
            // Movimientos del caballo (fila, columna)
            int[] filaMovimientos = new int[] { -2, -1, 1, 2, 2, 1, -1, -2 };
            int[] colMovimientos = new int[] { 1, 2, 2, 1, -1, -2, -2, -1 };

            // Verificar que la posición no esté en una posición alcanzable por otro caballo
            for (int i = 0; i < fila; i++)
            {
                int otraColumna = posicionesPiezas[i];

                for (int j = 0; j < 8; j++)
                {
                    int nuevaFila = i + filaMovimientos[j];
                    int nuevaColumna = otraColumna + colMovimientos[j];

                    if (nuevaFila == fila && nuevaColumna == columna)
                        return false;
                }
            }

            return true;
        }

        public string getNombre()
        {
            return "Caballo";
        }
    }
}
