using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace VSC.Data
{
    internal class SQLiteInMemoryDatabase : ISCDatabase
    {
        private const string TestDBName = "slt_test.db";
        public string GeneratorId { get; } = "Sqlite";

        public string ConnectionString { get; private set; } = string.Format("Data Source={0}", TestDBName); // "Data Source=:memory:;Version=3;New=True;";
        
        public SQLiteInMemoryDatabase()
        {
            if (File.Exists(TestDBName))
            {
                File.Delete(TestDBName);
            }
        }

        public IDbConnection GetDBConnection()
        {
            return new SQLiteConnection(this.ConnectionString);
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