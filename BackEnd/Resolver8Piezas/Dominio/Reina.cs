using solucionador.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace solucionador.Dominio
{
    public class Reina : IPieza
    {
        public bool EsSeguro(int[] posicionesPiezas, int fila, int columna)
        {
            for (int i = 0; i < fila; i++)
            {
                int otraColumna = posicionesPiezas[i];
                // La reina no puede atacar en la misma columna ni en las diagonales
                if (otraColumna == columna || Math.Abs(otraColumna - columna) == Math.Abs(i - fila))
                    return false;
            }
            return true;
        }

        public string getNombre()
        {
            string nombre = "Reina";
            return nombre;
        }

        public string ObtenerCoordenada(int fila, int columna)
        {
            throw new NotImplementedException();
        }

        public Reina()
        {
            
        }
    }
}
