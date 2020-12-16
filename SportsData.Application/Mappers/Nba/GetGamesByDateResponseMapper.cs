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

        public List<Game> Convert(GetGamesByDateDtoResponse response)
        {
            List<Game> listOfGames = new List<Game>();
            var games = response.Games;
            foreach (NbaApiGameDto game in games)
            {
                Game gameToAdd = new Game(
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
                    new Contestant(game.VTeam.TeamId, game.VTeam.ShortName, game.VTeam.FullName, game.VTeam.NickName, game.VTeam.Logo, 
                        new Score(game.VTeam.Score.Points)
                    ),
                    new Contestant(game.HTeam.TeamId, game.HTeam.ShortName, game.HTeam.FullName, game.HTeam.NickName, game.HTeam.Logo,
                        new Score(game.HTeam.Score.Points)
                    )
                );
                listOfGames.Add(gameToAdd);
            }
            return listOfGames;
        }
    }
}
