using System;
using System.Collections.Generic;
using System.Text;

namespace SportsData.Core.Entities.Nba
{
    public class Team
    {
        public string TeamId { get; set; }
        public string ShortName { get; set; }
        public string FullName { get; set; }
        public string NickName { get; set; }
        public string Logo { get; set; }
        public Score Score { get; set; }
    }
}
