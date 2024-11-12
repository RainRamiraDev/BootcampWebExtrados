using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace solucionador.Interface
{
    public interface IPieza
    {
        string getNombre();
        bool EsSeguro(int[] posicionesPiezas, int fila, int columna);

    }
}
