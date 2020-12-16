using System;
using System.Collections.Generic;
using System.Text;

namespace SportsData.Infrastructure.Dtos.NbaApi
{
    public class NbaApiContestantScoreDto
    {
        public NbaApiContestantScoreDto(string points)
        {
            Points = points;
        }

        public string Points { get; }
    }
}
