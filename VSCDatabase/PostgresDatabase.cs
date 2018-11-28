using System.Collections.Generic;
using System.Data;
using Npgsql;

namespace VSC.Data
{
    internal class PostgresDatabase : ISCDatabase
    {
        public string GeneratorId { get; } = "Postgres";

        public string ConnectionString { get; private set; } = string.Empty;

        public PostgresDatabase(string connectionString)
        {
            this.ConnectionString = connectionString;
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
            return new NpgsqlConnection(this.ConnectionString);
        }

        public bool CreateDatabase()
        {
            return true;
        }

        public bool DeleteDatabase()
        {
            return true;
        }

        public List<string> GetDatabases()
        {
            return new List<string>();
        }

        public bool DatabaseExists()
        {
            return true;
        }
    }
}