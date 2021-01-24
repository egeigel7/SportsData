using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Fluent;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SportsData.Infrastructure.Repositories.Nba;
using SportsData.Infrastructure.Repositories.NbaDb;
using System;
using System.Net.Http;

namespace SportsData.Infrastructure.Extensions
{
    public static class StartupExtensions
    {
        public static void AddSportsDataInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<CosmosClient>(s => {
                var connectionString = configuration.GetConnectionString("CosmosDBConnection");
                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new InvalidOperationException(
                        "Please specify a valid CosmosDBConnection in the appSettings.json file or your Azure Functions Settings.");
                }
                var httpClientFactory = s.GetService<IHttpClientFactory>();
                CosmosClientOptions cosmosClientOptions = new CosmosClientOptions();
                cosmosClientOptions.HttpClientFactory = httpClientFactory.CreateClient;
                cosmosClientOptions.ConnectionMode = ConnectionMode.Gateway;
                return new CosmosClient(connectionString, cosmosClientOptions);
                //IHttpClientFactory httpClientFactory = s.GetRequiredService<IHttpClientFactory>();

                //CosmosClientOptions cosmosClientOptions = new CosmosClientOptions()
                //{
                //    HttpClientFactory = httpClientFactory.CreateClient
                //};
                //var connectionString = configuration.GetConnectionString("CosmosDBConnection");
                //if (string.IsNullOrEmpty(connectionString))
                //{
                //    throw new InvalidOperationException(
                //        "Please specify a valid CosmosDBConnection in the appSettings.json file or your Azure Functions Settings.");
                //}

                //return new CosmosClientBuilder(connectionString, cosmosClientOptions).
                //    .Build();
            });
            services.AddTransient<INbaApiRepository, NbaApiRepository>();
            services.AddTransient<INbaDbRepository, NbaDbRepository>();
        }
    }
}
