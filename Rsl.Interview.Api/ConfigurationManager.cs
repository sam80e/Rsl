using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rsl.Interview.Api
{
    public class ConfigurationManager
    {
        public static IConfiguration Configuration { get; }

        static ConfigurationManager()
        {
            Configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        }
    }
}
