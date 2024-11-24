using Dapper;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserDaoLib.Daos.Interfaces;
using UserDaoLib.Models;

namespace UserDaoLib.Daos
{
    public class UserDao : IUserDao
    {
        private readonly string _connectionString;

        private readonly string QueryGetById = "SELECT * FROM Users WHERE Id = @id";
        private readonly string QueryGetAll = "SELECT * FROM Users";
        private readonly string QueryInsert = "INSERT INTO Users (Nombre, Email, Edad) VALUES (@Nombre, @Email, @Edad)";
        private readonly string QueryUpdate = "UPDATE Users SET Nombre = @Nombre, Email = @Email, Edad = @Edad WHERE Id = @Id";
        private readonly string QueryDelete = "DELETE FROM Users WHERE Id = @id";
        private readonly string QueryGetByEmail = "SELECT * FROM Users WHERE email = @email";

        public UserDao(string connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<int> CreateAsync(UserModel user)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var affectedRows = await connection.ExecuteAsync(QueryInsert, new { user.Nombre, user.Email, user.Edad });
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
                var affectedRows = await connection.ExecuteAsync(QueryUpdate, new { user.Nombre, user.Email, user.Edad, user.Id });
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
