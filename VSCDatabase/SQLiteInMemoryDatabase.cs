using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.IO;

namespace VSC.Data
{
    internal class SQLiteInMemoryDatabase : ISCDatabase
    {
        public string GeneratorId { get; } = "Sqlite";

        public string ConnectionString { get; private set; } = "FullUri=file::memory:?cache=shared";
        
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