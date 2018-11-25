using System.Collections.Generic;
using System.Data;

namespace VSC.Data
{
    public class SqlServerDatabase : ISCDatabase
    {
        public string ConnectionString { get; private set; } = string.Empty;

        public SqlServerDatabase(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public SqlServerDatabase
            (
                string serverName,
                string username,
                string password,
                string databaseName
            )
        {
            System.Data.SqlClient.SqlConnectionStringBuilder connectionStringBuilder = new System.Data.SqlClient.SqlConnectionStringBuilder()
            {
                DataSource = serverName,
                UserID = username,
                Password = password,
                InitialCatalog = databaseName
            };

            this.ConnectionString = connectionStringBuilder.ConnectionString;
        }

        public IDbConnection GetDBConnection()
        {
            return new System.Data.SqlClient.SqlConnection(this.ConnectionString);
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
