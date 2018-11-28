using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace VSC.Data
{
    internal class MySqlDatabase : ISCDatabase
    {
        public string GeneratorId { get; } = "MySql";
        
        public string ConnectionString { get; private set; } = string.Empty;

        public MySqlDatabase(string connectionString)
        {
            this.ConnectionString = connectionString;
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

            this.ConnectionString = mySqlConnectionStringBuilder.ToString();
        }

        public IDbConnection GetDBConnection()
        {
            return new MySqlConnection(this.ConnectionString);
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