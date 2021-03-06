using System;
using System.Data;
using Microsoft.Extensions.Configuration;
using VSC.Data.Settings;

namespace VSC.Data
{
    public static class VSCDatabase
    {
        #region GetSCDatabase
        public static ISCDatabase GetSCDatabase
        (
            DBType databaseType,
            string serverName,
            string username,
            string password,
            string databaseName
        )
        {
            ISCDatabase db = null;

            switch (databaseType)
            {
                case DBType.Postgres:
                {
                    db = new PostgresDatabase(serverName, username, password, databaseName);
                }
                break;
                case DBType.MySql:
                {
                    db = new MySqlDatabase(serverName, username, password, databaseName);
                }
                break;
                case DBType.SqlServer:
                {
                    db = new SqlServerDatabase(serverName, username, password, databaseName);
                }
                break;
                default:
                {
                    throw new NotSupportedDatabaseException();
                }
            }

            return db;
        }

        public static ISCDatabase GetSCDatabase
        (
            DBType databaseType,
            string connectionString
        )
        {
            ISCDatabase db = null;

            switch (databaseType)
            {
                case DBType.Postgres:
                {
                    db = new PostgresDatabase(connectionString);
                }
                break;
                case DBType.MySql:
                {
                    db = new MySqlDatabase(connectionString);
                }
                break;
                case DBType.SqlServer:
                {
                    db = new SqlServerDatabase(connectionString);
                }
                break;
                default:
                {
                    throw new NotSupportedDatabaseException();
                }
            }

            return db;
        }

        public static ISCDatabase GetSCInMemoryDatabase()
        {
            return new SQLiteInMemoryDatabase();
        }

        public static ISCDatabase GetSCDatabase(IConfiguration configuration)
        {
            return VSCDatabase.GetSCDatabase
                (
                    DatabaseSettingsReader.ReadDBType(configuration),
                    DatabaseSettingsReader.ReadServerName(configuration),
                    DatabaseSettingsReader.ReadUsername(configuration), 
                    DatabaseSettingsReader.ReadPassword(configuration), 
                    DatabaseSettingsReader.ReadDatabase(configuration)
                );
        }
        #endregion GetSCDatabase

        #region GetIDBConnection
        public static IDbConnection GetIDBConnection
        (
            DBType databaseType,
            string serverName,
            string username,
            string password,
            string databaseName
        )
        {
            ISCDatabase db = VSCDatabase.GetSCDatabase(databaseType, serverName, username, password, databaseName);

            return db.GetDBConnection();
        }

        public static IDbConnection GetIDBConnection
        (
            DBType databaseType,
            string connectionString
        )
        {
            ISCDatabase db = VSCDatabase.GetSCDatabase(databaseType, connectionString);

            return db.GetDBConnection();
        }

        public static IDbConnection GetInMemoryIDBConnection()
        {
            ISCDatabase db = VSCDatabase.GetSCInMemoryDatabase();

            return db.GetDBConnection();
        }

        public static IDbConnection GetIDbConnection(IConfiguration configuration)
        {
            return VSCDatabase.GetIDBConnection
                (
                    DatabaseSettingsReader.ReadDBType(configuration),
                    DatabaseSettingsReader.ReadServerName(configuration),
                    DatabaseSettingsReader.ReadUsername(configuration), 
                    DatabaseSettingsReader.ReadPassword(configuration), 
                    DatabaseSettingsReader.ReadDatabase(configuration)
                );
        }
        #endregion GetIDBConnection
    }
}