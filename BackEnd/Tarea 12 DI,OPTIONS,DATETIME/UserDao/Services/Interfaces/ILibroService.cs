using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDaoLib.Dto.Libro;

namespace UserDaoLib.Services.Interfaces
{
    public interface ILibroService
    {
        Task<IEnumerable<LibroDbReadDto>> GetAllLibrosAsync();
    }
}
