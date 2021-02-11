using SportsData.Application.Entities;
using SportsData.Application.Entities.Dtos;
using SportsData.Core.Entities.Nba;
using SportsData.Infrastructure.Dtos.NbaApi;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportsData.Application.Mappers.Nba
{
    public class GetGamesByDateResponseMapper : IGetGamesByDateResponseMapper
    {
        public GetGamesByDateResponseMapper()
        {

        }

        public List<Matchup> Convert(GetGamesByDateDtoResponse response)
        {
            List<Matchup> listOfGames = new List<Matchup>();
            var games = response.Games;
            foreach (NbaApiGameDto game in games)
            {
                Matchup gameToAdd = new Matchup(
                    game.SeasonYear,
                    game.League,
                    game.GameId,
                    game.StartTimeUTC,
                    game.EndTimeUTC,
                    game.Arena,
                    game.City,
                    game.Country,
                    game.Clock,
                    game.GameDuration,
                    game.CurrentPeriod,
                    game.Halftime,
                    game.EndOfPeriod,
                    game.SeasonStage,
                    game.StatusShortGame,
                    game.StatusGame,
                    new ContestantsSeasonRecord(game.VTeam.TeamId, game.VTeam.ShortName, game.VTeam.FullName, game.VTeam.NickName, game.VTeam.Logo, "", "", "",
                        new Score(game.VTeam.Score.Points)
                    ),
                    new ContestantsSeasonRecord(game.HTeam.TeamId, game.HTeam.ShortName, game.HTeam.FullName, game.HTeam.NickName, game.HTeam.Logo, "", "", "",
                        new Score(game.HTeam.Score.Points)
                    )
                );
                listOfGames.Add(gameToAdd);
            }
            return listOfGames;
        }
    }
}
