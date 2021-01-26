using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SportsData.Application.Entities.Dtos;
using SportsData.Application.Mappers.Nba;
using SportsData.Core.Entities.Nba;
using SportsData.Infrastructure.Dtos.NbaApi;
using SportsData.Infrastructure.Dtos.NbaDb;
using SportsData.Infrastructure.Repositories.Nba;
using SportsData.Infrastructure.Repositories.NbaDb;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SportsData.Application.Services.Nba
{
    public class NbaService : INbaService
    {
        private readonly INbaApiRepository _repository;
        private readonly INbaDbRepository _nbaDbRepository;
        private readonly IGetGamesByDateResponseMapper _mapper;
        public NbaService(INbaApiRepository repository, INbaDbRepository nbaDbRepository, IGetGamesByDateResponseMapper mapper)
        {
            _repository = repository;
            _nbaDbRepository = nbaDbRepository;
            _mapper = mapper;
        }

        public async Task<List<Matchup>> GetGamesByDate(DateTime date)
        {
            var response = await _repository.GetGamesByDate(date);
            var mappedGames = _mapper.Convert(response);
            return mappedGames;
        }

        public async Task<TeamSeason> GetSeasonStatsByTeamName(GetStatsByTeamNameRequestDto dto)
        {
            GetNbaTeamSeasonStatsRequestDto dbDto = new GetNbaTeamSeasonStatsRequestDto(dto.SeasonYear, dto.TeamName);
            var response = await _nbaDbRepository.GetNbaTeamSeasonStats(dbDto);
            TeamSeason seasonStats = new TeamSeason(
                response.SeasonYear,
                response.ShortName,
                response.FullName,
                response.Nickname,
                response.LogoUrl,
                response.GamesPlayed,
                new Statistics(
                    (response.Stats.PointsFor/response.GamesPlayed),
                    (response.Stats.PointsAgainst/response.GamesPlayed),
                    response.Stats.FastBreakPoints / response.GamesPlayed,
                    response.Stats.PointsInPaint / response.GamesPlayed,
                    response.Stats.BiggestLead,
                    response.Stats.SecondChancePoints / response.GamesPlayed,
                    response.Stats.PointsOffTurnovers / response.GamesPlayed,
                    response.Stats.LongestRun,
                    response.Stats.FGM / response.GamesPlayed,
                    response.Stats.FGA / response.GamesPlayed,
                    response.Stats.FGP,
                    response.Stats.FTM / response.GamesPlayed,
                    response.Stats.FTA / response.GamesPlayed,
                    response.Stats.FTP,
                    response.Stats.TPM / response.GamesPlayed,
                    response.Stats.TPA / response.GamesPlayed,
                    response.Stats.TPP,
                    response.Stats.OffReb / response.GamesPlayed,
                    response.Stats.DefReb / response.GamesPlayed,
                    response.Stats.TotReb / response.GamesPlayed,
                    response.Stats.Assists / response.GamesPlayed,
                    response.Stats.PFouls / response.GamesPlayed,
                    response.Stats.Steals / response.GamesPlayed,
                    response.Stats.Turnovers / response.GamesPlayed,
                    response.Stats.Blocks / response.GamesPlayed,
                    response.Stats.PlusMinus,
                    response.Stats.Min
                )
            );
            return seasonStats;
        }
    }
}
