using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Npgsql;

namespace graduationProject
{
    internal class WorkersRepository
    {
        private readonly string _connectionString;
        public WorkersRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

    }
}
