using System.Data;
using MySql.Data.MySqlClient;

namespace VSC.Data
{
    internal class MySqlDatabase : ISCDatabase
    {
        private string _connectionString = string.Empty;

        public MySqlDatabase(string connectionString)
        {
            _connectionString = connectionString;
        }

        public MySqlDatabase
            (
                string serverName,
                string username,
                string password,
                string databaseName
            )
        {
            MySqlConnectionStringBuilder mySqlConnectionStringBuilder = new MySqlConnectionStringBuilder() 
            {
                Server = serverName,
                UserID = username,
                Password = password,
                Database = databaseName
            };

            _connectionString = mySqlConnectionStringBuilder.ToString();
        }

        public IDbConnection GetDBConnection()
        {
            return new MySqlConnection(_connectionString);
        }
    }
}