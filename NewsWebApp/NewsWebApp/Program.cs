using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NewsWebApp.Core;
using NewsWebApp.Data;

namespace NewsWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
           IWebHost webHost =  CreateWebHostBuilder(args).Build();
            using (IServiceScope scope = webHost.Services.CreateScope())
            {
                using(NewsDbContext db = scope.ServiceProvider.GetRequiredService<NewsDbContext>())
                {
                    Seed.InvokeAsync(scope, db).Wait();
                }
            }
            webHost.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
