using AppiumSpecflow.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppiumSpecflow.Configuration
{
    public class ConfigurationProvider
    {
        private readonly IConfiguration _configuration;

        public AppSettings GetSettings()
        {
            return _configuration.Get<AppSettings>();
        }

        public ConfigurationProvider()
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
#if DEBUG   
                .AddUserSecrets<AppSettings>()
#else
                .AddJsonFile("appsettings.json", false, true)
#endif
                .Build();

        }
    }
}
