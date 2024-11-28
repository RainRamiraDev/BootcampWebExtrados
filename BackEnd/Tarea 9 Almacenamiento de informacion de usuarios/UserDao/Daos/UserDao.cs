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

        private readonly string QueryGetById = "SELECT * FROM Users WHERE Id = @id";
        private readonly string QueryGetAll = "SELECT * FROM Users";
        private readonly string QueryInsert = "INSERT INTO Users (Nombre, Email, Contrasenia) VALUES (@Nombre, @Email, @Contrasenia)";
        private readonly string QueryUpdate = "UPDATE Users SET Nombre = @Nombre, Email = @Email, Contrasenia = @Contrasenia WHERE Id = @Id";
        private readonly string QueryDelete = "DELETE FROM Users WHERE Id = @id";
        private readonly string QueryGetByEmail = "SELECT * FROM Users WHERE email = @email";

        public UserDao(string connectionString)
        {
            _connectionString = connectionString;
        }

        private async Task<bool> EmailExistsAsync(string email)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var existingUser = await connection.QueryFirstOrDefaultAsync<UserModel>(QueryGetByEmail, new { email });
                return existingUser != null;
            }
        }

        public async Task<int> CreateAsync(UserModel user)
        {
            // Validar que no exista un usuario con el mismo email
            if (await EmailExistsAsync(user.Email))
            {
                throw new Exception("Ya existe un usuario con el mismo email.");
            }

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

        public async Task<UserModel> GetByIdAsync(int id)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var user = await connection.QueryFirstOrDefaultAsync<UserModel>(QueryGetById, new { id });
                return user;
            }
        }

        public async Task<IEnumerable<UserModel>> GetAllAsync()
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var users = await connection.QueryAsync<UserModel>(QueryGetAll);
                return users;
            }
        }

        public async Task<bool> UpdateAsync(UserModel user)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var affectedRows = await connection.ExecuteAsync(QueryUpdate, new
                {
                    user.Nombre,
                    user.Email,
                    user.Contrasenia,
                    user.Id
                });
                return affectedRows > 0;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var affectedRows = await connection.ExecuteAsync(QueryDelete, new { id });
                return affectedRows > 0;
            }
        }

        public async Task<UserModel> GetByEmailAsync(string email)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var user = await connection.QueryFirstOrDefaultAsync<UserModel>(QueryGetByEmail, new { email });
                return user;
            }
        }
    }
}
