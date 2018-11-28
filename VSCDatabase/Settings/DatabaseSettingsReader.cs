using System;
using System.Data;
using Microsoft.Extensions.Configuration;

namespace VSC.Data.Settings
{
    internal class DatabaseSettingsReader
    {
        public static DBType ReadDBType(IConfiguration configuration)
        {
            DBType dbType = (DBType) configuration.GetValue<int>("DBConnection:DBType");
            
            return dbType;
        }

        public static string ReadServerName(IConfiguration configuration)
        {
            string serverName = configuration.GetValue<string>("DBConnection:ServerName");
            
            return serverName;
        }

        public static string ReadUsername(IConfiguration configuration)
        {
            string username = configuration.GetValue<string>("DBConnection:Username");
            
            return username;
        }

        public   static string ReadPassword(IConfiguration configuration)
        {
            string password = configuration.GetValue<string>("DBConnection:Password");
            
            return password;
        }
        
        public static string ReadDatabase(IConfiguration configuration)
        {
            string database = configuration.GetValue<string>("DBConnection:Database");
            
            return database;
        }
    }
}