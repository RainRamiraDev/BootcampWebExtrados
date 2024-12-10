using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserDaoLib.Dto.Prestamo
{
    public class PrestamoDbReadDto
    {
        public PrestamoDbReadDto(int idUsuario, int isbn, DateTime fechaPrestamo, DateTime fechaVencimiento)
        {
            IdUsuario = idUsuario;
            this.Isbn = isbn;
            FechaPrestamo = fechaPrestamo;
            FechaVencimiento = fechaVencimiento;
        }

        public PrestamoDbReadDto()
        {

        }

        public int IdUsuario { get; set; }

        public long Isbn { get; set; }

        public DateTime FechaPrestamo { get; set; }

        public DateTime FechaVencimiento { get; set; }
    }
}
