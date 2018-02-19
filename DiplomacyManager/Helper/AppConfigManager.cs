using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiplomacyManager.Helper
{
    public static class Globals
    {
        public static Uri Neo4jUri;
        public static string Neo4jUsername;
        public static string Neo4jPassword;
    }

    public class AppConfigManager
    {
        public static IConfigurationRoot Configuration { get; set; }
        public static void Configure()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("AppSettings.json", optional: false, reloadOnChange: true);
            Configuration = builder.Build();

            CreateNeo4jUri();
        }

        private static void CreateNeo4jUri()
        {
            Globals.Neo4jUri = new Uri(Configuration["Neo4j:Uri"]);
            Globals.Neo4jUsername = Configuration["Neo4j:Username"];
            Globals.Neo4jPassword = Configuration["Neo4j:Password"];
        }
    }
}
