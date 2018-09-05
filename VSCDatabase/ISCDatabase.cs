using System;
using System.Data;

namespace VSC.Data
{
    public enum DBType
    {
        None = 0,
        MySql = 1,
        Postgres = 2
    };

    public interface ISCDatabase
    {
        IDbConnection GetDBConnection();
    }
}
