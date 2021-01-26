using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace SportsDataApp.Api
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
                    webBuilder.ConfigureAppConfiguration((hostingContext, config) =>
                    {
                        var envName = hostingContext.HostingEnvironment.EnvironmentName;
                        var settings = config.Build();
                        var connection = settings.GetConnectionString("AppConfig");
                        config.AddJsonFile("appsettings.json", true, true);
                        var credentials = new ManagedIdentityCredential();
                        if (envName.Equals("Development"))
                        {
                            config.AddJsonFile($"appsettings.{envName}.json", true, true);
                        }
                        else
                        {
                            config.AddAzureAppConfiguration(options =>
                            {
                                options.Connect(connection)
                                        .ConfigureKeyVault(kv =>
                                        {
                                            kv.SetCredential(credentials);
                                        });
                            });
                        }
                    }
                        );
                });
    }
}