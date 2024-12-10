using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserDaoLib.Models
{
    public class PrestamoModel
    {
        public PrestamoModel(int idUsuario, long isbn, DateTime fechaPrestamo, DateTime fechaVencimiento)
        {
            IdUsuario = idUsuario;
            Isbn = isbn;
            FechaPrestamo = fechaPrestamo;
            FechaVencimiento = fechaVencimiento;
        }

        public int IdUsuario { get; set; }
        public long Isbn { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaVencimiento { get; set; }

        public PrestamoModel()
        {
            

        }



    }
}
