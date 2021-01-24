using System;
using System.Collections.Generic;
using System.Text;

namespace SportsData.Infrastructure.Dtos.NbaDb
{
    public class GetNbaTeamSeasonStatsRequestDto
    {
        public GetNbaTeamSeasonStatsRequestDto(string seasonYear, string teamName)
        {
            SeasonYear = seasonYear;
            TeamName = teamName;
        }
        public string SeasonYear { get; }
        public string TeamName { get; }
        public string TeamId { get { return $"{SeasonYear}-{PartitionKey}"; } }

        public string PartitionKey { get { return $"NBA-{TeamName.Trim().ToUpperInvariant()}"; } }
    }
}
