using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using SportsData.Infrastructure.Dtos.NbaApi;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SportsData.Infrastructure.Repositories.Nba
{
    public class NbaApiRepository : INbaApiRepository
    {
        HttpClient _client;
        IConfiguration _config;
        private readonly string NBA_API_URI;
        private readonly string NBA_API_KEY;
        public NbaApiRepository(IHttpClientFactory factory, IConfiguration configuration)
        {
            _client = factory.CreateClient();
            _config = configuration;
            NBA_API_URI = _config.GetSection("NbaApiUri").Value;
            NBA_API_KEY = _config.GetSection("NbaApiKey").Value;
        }
        public async Task<GetGamesByDateDtoResponse> GetGamesByDate(DateTime date)
        {
            var formattedDate = date.ToString("yyyy-MM-dd");
            var nbaApiUrl = $"https://{NBA_API_URI}/games/date/{formattedDate}";
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(nbaApiUrl),
                Headers =
                {
                    { "x-rapidapi-key", NBA_API_KEY },
                    { "x-rapidapi-host", NBA_API_URI },
                },
            };
            using (var response = await _client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Console.WriteLine(body);
                var games = JObject.Parse(body).SelectToken("api").ToObject<GetGamesByDateDtoResponse>();
                return games;
            }
        }
    }
}
