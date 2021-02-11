using System;
using System.Collections.Generic;
using System.Text;

namespace SportsData.Infrastructure.Dtos.NbaDb
{
    public class GetGamesByDateDbResponse
    {
        public GetGamesByDateDbResponse(List<NbaGameDbDto> games)
        {
            Games = games;
        }
        public List<NbaGameDbDto> Games { get; set; }
    }
}
