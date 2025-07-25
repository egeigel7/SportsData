﻿using SportsData.Core.Entities.Nba;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportsData.Application.Entities
{
    public class ContestantsSeasonRecord
    {
        public ContestantsSeasonRecord(string teamId, string shortName, string fullName, string nickName, string logo, string record, string ats, string overUnder, Score score)
        {
            TeamId = teamId;
            ShortName = shortName;
            FullName = fullName;
            NickName = nickName;
            Logo = logo;
            Record = record;
            ATS = ats;
            OverUnder = overUnder;
            Score = score;
        }

        public string TeamId { get; set; }
        public string ShortName { get; set; }
        public string FullName { get; set; }
        public string NickName { get; set; }
        public string Logo { get; set; }
        public string Record { get; set; }
        public string ATS { get; set; }
        public string OverUnder { get; set; }
        public string GameSpread { get; set; }
        public string GameOverUnder { get; set; }
        public int OverOdds { get; set; }
        public int UnderOdds { get; set; }
        public int SpreadOdds { get; set; }

        public Score Score { get; set; }
    }
}
