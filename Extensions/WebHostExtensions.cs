using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Rufat_Soap_to_Rest.Models;

namespace Rufat_Soap_to_Rest.Extensions
{
    /// <summary>
    /// Description:
    /// Service to execute migrations and seeders on start.
    /// </summary>
    public static class WebHostExtensions
    {
        /// <summary>
        /// Function to seed data.
        /// </summary>
        /// <param name="host"></param>
        /// <returns>Web host for Program.cs</returns>
        public static IWebHost SeedData(this IWebHost host)
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            var _dataContext = services.GetService<DataContext>();

            _dataContext.Database.Migrate();

            _dataContext.SaveChanges();

            return host;
        }
    }
}
