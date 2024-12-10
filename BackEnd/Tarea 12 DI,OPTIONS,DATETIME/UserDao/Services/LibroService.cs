using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDaoLib.Daos;
using UserDaoLib.Daos.Interfaces;
using UserDaoLib.Dto.Libro;
using UserDaoLib.Services.Interfaces;

namespace UserDaoLib.Services
{
    public class LibroService : ILibroService
    {

        private readonly ILibroDao _libroDao;

        public LibroService(ILibroDao libroDao)
        {
            _libroDao = libroDao;
        }



        public async Task<IEnumerable<LibroDbReadDto>> GetAllLibrosAsync()
        {
            var libroModels = await _libroDao.GetAllAsync();
            return libroModels.Select(libro => new LibroDbReadDto
            {
                Isbn = libro.Isbn,
                Nombre = libro.Nombre,
                Autor = libro.Autor,
                Genero = libro.Genero,
            });
        }
    }
}
