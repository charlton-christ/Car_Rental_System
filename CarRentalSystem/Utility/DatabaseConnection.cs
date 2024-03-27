using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CarRentalSystem.Utility
{
	internal static class DatabaseConnection
	{
        private static IConfiguration _iconfiguration;

        static DatabaseConnection()
        {
            GetAppSettings();
        }

        public static void GetAppSettings()
        {
            var connection = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("configs.json");
            _iconfiguration = connection.Build();
        }

        public static string GetConnectionString()
        {
            return _iconfiguration.GetConnectionString("LocalConnectionString");
        }
    }
}

