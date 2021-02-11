using System;
using System.Collections.Generic;
using System.Text;

namespace SportsData.Application.Entities
{
    public class UpcomingMatchup
    {
        public UpcomingMatchup(DateTime startTimeUtc, ContestantsSeasonRecord visitingTeam, ContestantsSeasonRecord homeTeam)
        {
            StartTimeUtc = startTimeUtc;
            VisitingTeam = visitingTeam;
            HomeTeam = homeTeam;
        }

        public DateTime StartTimeUtc { get; set; }
        public ContestantsSeasonRecord VisitingTeam { get; }
        public ContestantsSeasonRecord HomeTeam { get; }
    }
}
