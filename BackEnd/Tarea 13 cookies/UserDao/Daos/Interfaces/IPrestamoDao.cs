using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDaoLib.Models;

namespace UserDaoLib.Daos.Interfaces
{
    public interface IPrestamoDao
    {
        Task<int> CreatePrestamoAsync(PrestamoModel prestamo);

        Task<IEnumerable<PrestamoModel>> GetAllPrestamosAsync();
    }
}
