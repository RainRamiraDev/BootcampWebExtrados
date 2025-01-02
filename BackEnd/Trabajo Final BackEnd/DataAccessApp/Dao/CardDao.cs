using Dapper;
using DataAccessApp.Interfaces;
using DataAccessApp.Models.Card;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessApp.Dao
{
    public class CardDao : ICardDao
    {
        private readonly string _connectionString;

        private readonly string QueryGetAll = "SELECT * FROM T_Card";

        public CardDao(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<CardModel>> GetAllAsync()
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var cards = await connection.QueryAsync<CardModel>(QueryGetAll);
                return cards;
            }
        }

    }
}
