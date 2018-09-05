using System;
using Xunit;
using VSC.Data;

namespace VSC.Tests.Data
{
    public class VSCDatabaseTester
    {
        [Fact]
        public void TestGetDBConnection()
        {
            DBType dbType = DBType.MySql;
            string connectionString = string.Empty;

            VSCDatabase.GetIDBConnection(dbType, connectionString);
        }
    }
}
