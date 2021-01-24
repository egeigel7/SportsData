using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace SportsData.Application.Entities.Dtos
{
    [DataContract]
    public class GetStatsByTeamNameRequestDto
    {
        [JsonProperty("seasonYear")]
        public string SeasonYear { get; set; }
        [JsonProperty("teamName")]
        public string TeamName { get; set;  }

    }
}
