using System;
using System.Collections.Generic;
using System.Text;

namespace SportsData.Infrastructure.Dtos.NbaDb
{
    public class GameOverUnder
    {
        public GameOverUnder(string total, int overOdds, int underOdds)
        {
            Total = total;
            OverOdds = overOdds;
            UnderOdds = underOdds;
        }

        public string Total { get; set; }
        public int OverOdds { get; set; }
        public int UnderOdds { get; set; }
    }
}
