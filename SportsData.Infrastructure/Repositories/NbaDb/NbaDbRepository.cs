using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using SportsData.Infrastructure.Dtos.NbaDb;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SportsData.Infrastructure.Repositories.NbaDb
{
    public class NbaDbRepository: INbaDbRepository
    {
        private string LEAGUE_NAME = "NBA";

        // The Cosmos client instance
        private CosmosClient CosmosClient;

        // The container we will create.
        private Container TeamsContainer;
        private Container GamesContainer;


        IConfiguration _config;

        public NbaDbRepository(IConfiguration configuration, CosmosClient client)
        {
            _config = configuration;
            CosmosClient = client;
            string DatabaseName = _config.GetSection("NbaDatabaseName").Value;
            string TeamsContainerName = _config.GetSection("TeamsCollectionName").Value;
            string GamesContainerName = _config.GetSection("GamesCollectionName").Value;
            //string EndpointUri = _config.GetSection("NbaDatabaseUri").Value;
            //string PrimaryKey = _config.GetSection("NbaDatabasePrimaryKey").Value;
            //CosmosClient = new CosmosClient(EndpointUri, PrimaryKey, new CosmosClientOptions()
            //{
            //    ConnectionMode = Microsoft.Azure.Cosmos.ConnectionMode.Gateway
            //});
            TeamsContainer = CosmosClient.GetContainer(DatabaseName, TeamsContainerName);
            GamesContainer = CosmosClient.GetContainer(DatabaseName, GamesContainerName);
        }
        public async Task<NbaTeamPerformanceDbDto> GetNbaTeamSeasonStats(GetNbaTeamSeasonStatsRequestDto dto)
        {
            var key = string.Join("-", LEAGUE_NAME, dto.TeamName.Trim().ToUpperInvariant());
            var partitionKey = new PartitionKey(key);
            var id = $"{dto.SeasonYear.Trim().ToUpperInvariant()}-{key}";
            try
            {
                // Read the item to see if it exists.  
                ItemResponse<NbaTeamPerformanceDbDto> teamPerformanceResponse = await TeamsContainer.ReadItemAsync<NbaTeamPerformanceDbDto>(id, partitionKey);
                // Console.WriteLine("Item in database with id: {0} already exists\n", teamPerformanceResponse.Resource);
                return teamPerformanceResponse.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                throw;
            }
        }
    }
}
