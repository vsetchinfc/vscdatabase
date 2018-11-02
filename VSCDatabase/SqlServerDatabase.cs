using System.Data;

namespace VSC.Data
{
    public class SqlServerDatabase : ISCDatabase
    {
        private string _connectionString = string.Empty;

        public SqlServerDatabase(string connectionString)
        {
            _connectionString = connectionString;
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

            _connectionString = connectionStringBuilder.ConnectionString;
        }

        public IDbConnection GetDBConnection()
        {
            return new System.Data.SqlClient.SqlConnection(_connectionString);
        }
    }
}
