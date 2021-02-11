using System;
using System.Collections.Generic;
using System.Text;

namespace SportsData.Infrastructure.Dtos.NbaDb
{
    public class GameSpread
    {
        public GameSpread(string value, int odds)
        {
            Value = value;
            Odds = odds;
        }

        public string Value { get; set; }
        public int Odds { get; set; }
    }
}
