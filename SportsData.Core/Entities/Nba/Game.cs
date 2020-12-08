using System;

namespace SportsData.Core.Entities.Nba
{
    public class Game
    {
        public Game(string seasonYear, string league, string gameId, DateTime startTimeUTC, DateTime endTimeUTC, string arena, string city, string country, string clock, string gameDuration, string currentPeriod, string halftime, string endOfPeriod
            , string seasonStage, string statusShortGame, string statusGame, Team vTeam, Team hTeam)
        {
            SeasonYear = seasonYear;
            League = league;
            GameId = gameId;
            StartTimeUTC = startTimeUTC;
            EndTimeUTC = endTimeUTC;
            Arena = arena;
            City = city;
            Country = country;
            Clock = clock;
            GameDuration = gameDuration;
            CurrentPeriod = currentPeriod;
            Halftime = halftime;
            EndOfPeriod = endOfPeriod;
            SeasonStage = seasonStage;
            StatusShortGame = statusShortGame;
            StatusGame = statusGame;
            VTeam = vTeam;
            HTeam = hTeam;
        }
        public string SeasonYear { get;}
        public string League { get; }
        public string GameId { get; }
        public DateTime StartTimeUTC { get; }
        public DateTime EndTimeUTC { get; }
        public string Arena { get; }
        public string City { get; }
        public string Country { get; }
        public string Clock { get; }
        public string GameDuration { get;}
        public string CurrentPeriod { get; }
        public string Halftime { get; }
        public string EndOfPeriod { get;}
        public string SeasonStage { get;}
        public string StatusShortGame { get; }
        public string StatusGame { get; }
        public Team VTeam { get; }
        public Team HTeam { get; }
    }
}
