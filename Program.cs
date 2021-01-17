<<<<<<< HEAD
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
=======
>>>>>>> InitializingDatabase
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
<<<<<<< HEAD
=======
>>>>>>> InitializingDatabase

namespace PO_implementacja_StudiaPodyplomowe
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
