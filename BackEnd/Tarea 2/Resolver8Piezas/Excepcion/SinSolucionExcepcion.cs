using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resolver8Piezas.Excepcion
{
    public class SinSolucionExcepcion : Exception
    {
        public SinSolucionExcepcion()
            : base("No se encontraron soluciones para el problema.") { }

    }
}
