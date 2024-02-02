using Dapper;
using MySqlConnector;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DALLibrary
{
    public class SqlDataAccess
    {
        private readonly string _connectionString;

        public SqlDataAccess(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<T> LoadData<T, U>(string sqlStatement, U parameters)
        {
            using (IDbConnection connection = new MySqlConnection(_connectionString))
            {
                List<T> rows = connection.Query<T>(sqlStatement, parameters).ToList();
                return rows;
            }
        }

        public void PersistData<T>(string sqlStatement, T parameters)
        {
            using (IDbConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Execute(sqlStatement, parameters);
            }
        }
    }
}
