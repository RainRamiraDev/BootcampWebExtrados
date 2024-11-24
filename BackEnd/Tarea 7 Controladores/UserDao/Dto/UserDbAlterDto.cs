using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserDaoLib.Dto
{
    public class UserDbAlterDto
    {
        public string Nombre { get; set; }
        public string Email { get; set; }
        public int Edad { get; set; }
        public UserDbAlterDto( string nombre, string email, int edad)
        {
            Nombre = nombre;
            Email = email;
            Edad = edad;
        }
        public UserDbAlterDto()
        {

        }
    }
}
