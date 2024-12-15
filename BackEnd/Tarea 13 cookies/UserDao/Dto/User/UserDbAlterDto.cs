using System;

namespace UserDaoLib.Dto
{
    public class UserDbAlterDto
    {
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Contrasenia { get; set; } 

        public UserDbAlterDto(string nombre, string email, string contrasenia)
        {
            Nombre = nombre;
            Email = email;
            Contrasenia = contrasenia;
        }


        public UserDbAlterDto()
        {
        }
    }
}

