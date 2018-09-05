using System.Data;

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
                default:
                {
                    throw new NotSupportedDatabaseException();
                }
                break;
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
                default:
                {
                    throw new NotSupportedDatabaseException();
                }
                break;
            }

            return db;
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
        #endregion GetIDBConnection
    }
}