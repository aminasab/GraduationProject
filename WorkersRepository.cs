using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Npgsql;
using Telegram.Bot.Types;

namespace graduationProject
{
    internal class WorkersRepository
    {
        private readonly string _connectionString;
        public WorkersRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Заполнение коллекции строками из базы данных таблицы Workers.
        /// </summary>
        public List <Workers> GetWorkers()
        {
            using var con = new NpgsqlConnection(_connectionString);
            {
                return con.Query<Workers>("SELECT * FROM Workers").ToList();
            }
        }

        /// <summary>
        /// Вставка данных нового пользователя в базу данных.
        /// </summary>
        public async Task InsertData(Workers worker)
        {
            await using var con = new NpgsqlConnection(_connectionString);
            {
                var query = "INSERT INTO Workers (UserName, UserRole, UserState, UserId)";
                con.Execute(query, worker);
            }
        } 

    }
}
