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
        public NbaApiRepository()
        {
            _client = new HttpClient();
        }
        public async Task<GetGamesByDateDtoResponse> GetGamesByDate(DateTime date)
        {
            var formattedDate = date.ToString("yyyy-MM-dd");
            var nbaApiUrl = $"https://api-nba-v1.p.rapidapi.com/games/date/{formattedDate}";
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(nbaApiUrl),
                Headers =
                {
                    { "x-rapidapi-key", "ea61dbc290msh26d23555f5b2f27p15cf70jsn8fce5f15677a" },
                    { "x-rapidapi-host", "api-nba-v1.p.rapidapi.com" },
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
