using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiplomacyManager.Helper
{
    public class AppConfigManager
    {
        public static IConfigurationRoot Configuration { get; set; }
        public static void Configure(bool withDebug)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("AppSettings.json", optional: false, reloadOnChange: true);
            Configuration = builder.Build();
        }
    }
}
