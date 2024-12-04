using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserDaoLib.Models;
using UserDaoLib.Daos.Interfaces;

namespace UserDaoLib.Daos
{
    public class UserDao : IUserDao
    {
        private readonly string _connectionString;

        private readonly string QueryGetUserWhitToken = "SELECT * FROM Users WHERE Id = @id";
        private readonly string QueryInsert = "INSERT INTO Users (Nombre, Email, Contrasenia) VALUES (@Nombre, @Email, @Contrasenia)";
        private readonly string QueryLogin = "SELECT * FROM Users WHERE Nombre = @Nombre";


        public async Task<UserModel> LogInAsync(string nombre)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var user = await connection.QueryFirstOrDefaultAsync<UserModel>(QueryLogin, new { nombre });
                return user;
            }
        }


        public UserDao(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<int> CreateWhitHashedPasswordAsync(UserModel user)
        {

            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var affectedRows = await connection.ExecuteAsync(QueryInsert, new
                {
                    user.Nombre,
                    user.Email,
                    user.Contrasenia
                });
                return affectedRows;
            }
        }

        public async Task<UserModel> GetUserWhitTokenAsync(int id)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var user = await connection.QueryFirstOrDefaultAsync<UserModel>(QueryGetUserWhitToken, new { id });
                return user;
            }
        }

       
    }
}
