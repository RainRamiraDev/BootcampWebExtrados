using Dapper;
using MySql.Data.MySqlClient;
using RefreshTokenApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDaoLib.Daos.Interfaces;

namespace UserDaoLib.Daos
{
    public class RefreshTokenDao : IRefreshTokenDao
    {
        private readonly string _connectionString;

        private const string QueryVerifyToken = "SELECT COUNT(1) FROM refresh_tokens WHERE refresh_token = @Token AND expiration_date > @Now";
        private const string QueryDeleteToken = "DELETE FROM refresh_tokens WHERE refresh_token = @Token";
        private const string QuerySaveToken = "INSERT INTO refresh_tokens (refresh_token, user_id, expiration_date) VALUES (@Token, @UserId, @ExpirationDate)";

        public RefreshTokenDao(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<bool> VerifyTokenAsync(Guid token)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var count = await connection.ExecuteScalarAsync<int>(QueryVerifyToken, new { Token = token, Now = DateTime.UtcNow });
                return count > 0;
            }
        }

     

        public async Task<int> DeleteRefreshTokenAsync(Guid token)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                return await connection.ExecuteAsync(QueryDeleteToken, new { Token = token });
            }
        }

        public async Task<int> SaveRefreshTokenAsync(Guid token, int userId, DateTime expirationDate)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                return await connection.ExecuteAsync(QuerySaveToken, new { Token = token, UserId = userId, ExpirationDate = expirationDate });
            }
        }

        public async Task<Guid> GetRefreshTokenAsync(int userId)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                return await connection.ExecuteScalarAsync<Guid>(QueryGetToken, new { UserId = userId });
            }
        }
    }
}
