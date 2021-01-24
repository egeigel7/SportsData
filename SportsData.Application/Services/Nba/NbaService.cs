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
                    response.Stats.PointsFor,
                    response.Stats.PointsAgainst,
                    response.Stats.FastBreakPoints,
                    response.Stats.PointsInPaint,
                    response.Stats.BiggestLead,
                    response.Stats.SecondChancePoints,
                    response.Stats.PointsOffTurnovers,
                    response.Stats.LongestRun,
                    response.Stats.FGM,
                    response.Stats.FGA,
                    response.Stats.FGP,
                    response.Stats.FTM,
                    response.Stats.FTA,
                    response.Stats.FTP,
                    response.Stats.TPM,
                    response.Stats.TPA,
                    response.Stats.TPP,
                    response.Stats.OffReb,
                    response.Stats.DefReb,
                    response.Stats.TotReb,
                    response.Stats.Assists,
                    response.Stats.PFouls,
                    response.Stats.Steals,
                    response.Stats.Turnovers,
                    response.Stats.Blocks,
                    response.Stats.PlusMinus,
                    response.Stats.Min
                )
            );
            return seasonStats;
        }
    }
}
