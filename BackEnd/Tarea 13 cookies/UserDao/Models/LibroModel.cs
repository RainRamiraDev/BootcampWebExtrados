using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserDaoLib.Models
{
    public class LibroModel
    {
        public LibroModel(int isbn, string nombre, string autor, string genero)
        {
            Isbn = isbn;
            Nombre = nombre;
            Autor = autor;
            Genero = genero;
        }

        public LibroModel()
        {
            
        }

        public int Isbn { get; set; }
        public string Nombre { get; set; }

        public string Autor { get; set; }

        public string Genero { get; set; }

    }
}
