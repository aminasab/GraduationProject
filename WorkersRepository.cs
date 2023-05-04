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
        public List <Worker> GetWorkers()
        {
            using var con = new NpgsqlConnection(_connectionString);
            {
                return con.Query<Worker>("SELECT * FROM Workers").ToList();
            }
        }

        /// <summary>
        /// Вставка данных пользователя в базу данных.
        /// </summary>
        public async Task InsertData(Worker worker)
        {
            try
            {
                await using var con = new NpgsqlConnection(_connectionString);
                {
                    var query = "INSERT INTO Workers (TelegramId, FirstName, LastName, UserName, CallBackOfInlineButton, DateCreated) VALUES (@TelegramId, @FirstName, @LastName, @UserName, @CallBackOfInlineButton, @DateCreated)";
                    con.Execute(query,worker);
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        } 

    }
}
