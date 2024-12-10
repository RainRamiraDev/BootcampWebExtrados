
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
    public class LibroDao : ILibroDao
    {
        private readonly string _connectionString;

        private readonly string QueryGetAll = "SELECT * FROM libros";


        public LibroDao(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<LibroModel>> GetAllAsync()
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var libros = await connection.QueryAsync<LibroModel>(QueryGetAll);
                return libros;
            }
        }
    }
}
