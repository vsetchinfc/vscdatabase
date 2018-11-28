using System;
using System.Collections.Generic;
using System.Data;

namespace VSC.Data
{
    public enum DBType
    {
        None = 0,
        MySql = 1,
        Postgres = 2,
        SqlServer = 3
    };

    public interface ISCDatabase
    {
        /// <summary>
        /// Generator Id for use with Fluent Migrator 
        /// </summary>
        /// <value>string</value>
        string GeneratorId { get; }
        IDbConnection GetDBConnection();

        string ConnectionString { get; }

        bool CreateDatabase();

        bool DeleteDatabase();

        List<string> GetDatabases();

        bool DatabaseExists();
    }
}
