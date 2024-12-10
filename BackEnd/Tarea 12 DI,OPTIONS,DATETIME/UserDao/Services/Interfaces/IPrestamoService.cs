using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDaoLib.Dto.Prestamo;

namespace UserDaoLib.Services.Interfaces
{
    public interface IPrestamoService
    {
        Task<int> CreatePrestamoAsync(PrestamoDbAlterDto prestamoDto);
        Task<IEnumerable<PrestamoDbReadDto>> GetAllPrestamoAsync();

    }
}
