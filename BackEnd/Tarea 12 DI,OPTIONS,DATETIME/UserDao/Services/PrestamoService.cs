using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDaoLib.Daos;
using UserDaoLib.Daos.Interfaces;
using UserDaoLib.Dto.Prestamo;
using UserDaoLib.Models;
using UserDaoLib.Services.Interfaces;

namespace UserDaoLib.Services
{
    public class PrestamoService : IPrestamoService
    {
        private readonly IPrestamoDao _prestamoDao;

        public PrestamoService(IPrestamoDao prestamoDao)
        {
            _prestamoDao = prestamoDao;
        }

        public async Task<int> CreatePrestamoAsync(PrestamoDbAlterDto prestamoDto)
        {
            var fechaVencimiento = prestamoDto.FechaPrestamo.AddDays(5);

            var prestamoModel = new PrestamoModel
            {
                IdUsuario = prestamoDto.IdUsuario,
                Isbn = prestamoDto.isbn,
                FechaPrestamo = prestamoDto.FechaPrestamo,
                FechaVencimiento = fechaVencimiento 
            };

            return await _prestamoDao.CreatePrestamoAsync(prestamoModel);
        }



        public async Task<IEnumerable<PrestamoDbReadDto>> GetAllPrestamoAsync()
        {
            var prestamos = await _prestamoDao.GetAllPrestamosAsync();

            return prestamos.Select(prestamo => new PrestamoDbReadDto
            {
                Isbn = prestamo.Isbn,
                IdUsuario = prestamo.IdUsuario,
                FechaPrestamo = prestamo.FechaPrestamo,
                FechaVencimiento = prestamo.FechaVencimiento,
            });
        }
    }
}
