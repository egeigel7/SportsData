using System;
using System.Collections.Generic;
using System.Text;

namespace SportsData.Infrastructure.Dtos.NbaDb
{
    public class NbaGameDbDto
    {
        public DateTime date { get; set; }
        public string id { get; set; }
        public string teamKey { get; set; }
        public string fullName { get; set; }
        public string logoUrl { get; set; }
        public string opponentId { get; set; }
        public string status { get; set; }
        public GameOverUnder overUnder { get; set; }
        public GameSpread spread { get; set; }
    }
}
