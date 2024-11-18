using solucionador.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resolver8Piezas.Dominio
{
    public class SinSolucion : IPieza
    {
        public bool EsSeguro(int[] posicionesPiezas, int fila, int columna)
        {
            // Siempre retorna falso para que no sea seguro colocar esta pieza.
            return false;
        }


        public string getNombre()
        {
            return "Pieza Sin Solución";
        }
    }
}
