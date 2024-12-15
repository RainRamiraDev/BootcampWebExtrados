using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserDaoLib.Dto.Libro
{
    public class LibroDbAlterDto
    {
        public LibroDbAlterDto(int isbn, string nombre, string autor, string genero)
        {
            Isbn = isbn;
            Nombre = nombre;
            Autor = autor;
            Genero = genero;
        }

        public LibroDbAlterDto()
        {
            
        }

        public int Isbn { get; set; }

        public string Nombre { get; set; }

        public string Autor { get; set; }

        public string Genero { get; set; }

    }
}
