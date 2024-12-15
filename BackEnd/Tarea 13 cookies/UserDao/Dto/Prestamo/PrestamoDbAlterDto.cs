using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserDaoLib.Dto.Prestamo
{
    public class PrestamoDbAlterDto
    {
        public PrestamoDbAlterDto(int idUsuario, int isbn, DateTime fechaPrestamo)
        {
            IdUsuario = idUsuario;
            this.isbn = isbn;
            FechaPrestamo = fechaPrestamo;
        }

        public PrestamoDbAlterDto()
        {

        }

        public int IdUsuario { get; set; }
        public int isbn { get; set; }
        public DateTime FechaPrestamo { get; set; }


    }
}
