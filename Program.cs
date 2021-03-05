using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Rufat_Soap_to_Rest.Extensions;

namespace Rufat_Soap_to_Rest
{
    public class Program
    {
        /// <summary>
        ///     Main function of Program.cs.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().SeedData().Run();
        }

        /// <summary>
        ///     Web host builder of Program.cs.
        /// </summary>
        /// <param name="args"></param>
        /// <returns>Returns IWebHostBuilder.</returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .Build();

            var webHost = WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseConfiguration(config);

            return webHost;
        }
    }
}
