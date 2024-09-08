using HamburguesitoNet.Domain.Common;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace HamburguesitoNet.Application.Common.Utils
{
    public static class VariablesUtil
    {
        public static string GetConnectionString(IConfiguration configuration)
        {
            var connection = new ConnectionString();
            connection.Server = Environment.GetEnvironmentVariable("SERVER");
            connection.Port = Environment.GetEnvironmentVariable("PORT");
            connection.Database = Environment.GetEnvironmentVariable("DATABASE");
            connection.UserId = Environment.GetEnvironmentVariable("USERID");
            connection.Password = Environment.GetEnvironmentVariable("PASSWORDDB");
            connection.Connection = $"Server={connection.Server};Port={connection.Port};Database={connection.Database};User Id={connection.UserId};Password={connection.Password}";
            if (connection.Server == null || connection.UserId == null || connection.Database == null || connection.Password == null || connection.Port == null)
            {
                connection.Connection = configuration.GetConnectionString("Connectionstring");
            }
            return connection.Connection;
        }

        //Corriendo con docker en necesario el directorio /src/WebUI, con IIS Express solo el directorio base
        public static string GetDirectoryAppSettings()
        {
            return Directory.Exists(AppContext.BaseDirectory + "src/WebUI/") ? AppContext.BaseDirectory + "src/WebUI/" : AppContext.BaseDirectory;
        }
    }
}
