using System.Data;
using Npgsql;

namespace VSC.Data
{
    internal class PostgresDatabase : ISCDatabase
    {
        private string _connectionString = string.Empty;

        public PostgresDatabase(string connectionString)
        {
            _connectionString = connectionString;
        }

        public PostgresDatabase
            (
                string serverName,
                string username,
                string password,
                string databaseName
            )
        {
            NpgsqlConnectionStringBuilder postgresConnectionStringBuilder = new NpgsqlConnectionStringBuilder() 
            {
                Host = serverName,
                Username = username,
                Password = password,
                Database = databaseName
            };
        }

        public IDbConnection GetDBConnection()
        {
            return new NpgsqlConnection(_connectionString);
        }
    }
}