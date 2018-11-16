using System.Data;
using System.Data.SQLite;

namespace VSC.Data
{
    internal class SQLiteInMemoryDatabase : ISCDatabase
    {
        private string _connectionString = "Data Source=:memory:;Version=3;New=True;";
        
        public IDbConnection GetDBConnection()
        {
            return new SQLiteConnection(_connectionString);
        }
    }
}