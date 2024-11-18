using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuardasApp
{
    public class Usuario
    {
        public string Nombre { get; set; }

        public int Edad { get; set; }

        public Usuario()
        {
            
        }

        public Usuario(string nombre,int edad)
        {
            this.Nombre = nombre;
            this.Edad = edad;

        }

        public bool MayorDeEdad(Usuario usuario)
        {
            return usuario.Edad >= 18;
        }

    }
}
