using SportsData.Application.Entities.Dtos;
using SportsData.Core.Entities.Nba;
using SportsData.Infrastructure.Dtos.NbaApi;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SportsData.Application.Services.Nba
{
    public interface INbaService
    {
        Task<List<Matchup>> GetGamesByDate(DateTime date);
        Task<TeamSeason> GetSeasonStatsByTeamName(GetStatsByTeamNameRequestDto dto);
        Task<List<Matchup>> GetUpcomingGames();
    }
}
