using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDaoLib.Daos.Interfaces;
using UserDaoLib.Models;

namespace UserDaoLib.Daos
{
    public class PrestamoDao : IPrestamoDao
    {
        private readonly string _connectionString;


        private readonly string QueryGetAll = @"
                    SELECT 
    p.id_usuario AS IdUsuario,
    p.isbn AS Isbn,
    p.fecha_prestamo AS FechaPrestamo,
    p.fecha_vencimiento AS FechaVencimiento
FROM prestamos p;

";

        private readonly string QueryInsert = @"
            INSERT INTO prestamos (id_usuario, isbn, fecha_prestamo, fecha_vencimiento) 
            VALUES (@IdUsuario, @Isbn, @FechaPrestamo, @FechaVencimiento);";
        
        public PrestamoDao(string connectionString)
        {
            _connectionString = connectionString;
        }

       


        public async Task<int> CreatePrestamoAsync(PrestamoModel prestamo)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var affectedRows = await connection.ExecuteAsync(QueryInsert, new
                {

                    prestamo.IdUsuario,
                    prestamo.Isbn,
                    prestamo.FechaPrestamo,
                    prestamo.FechaVencimiento


                });

                return affectedRows;
            }
        }


        public async Task<IEnumerable<PrestamoModel>> GetAllPrestamosAsync()
        {


            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var prestamos = await connection.QueryAsync<PrestamoModel>(QueryGetAll);

                return prestamos;
            }

        }
    }
}
