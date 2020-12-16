using Newtonsoft.Json;
using SportsData.Core.Entities.Nba;
using System.Collections.Generic;

namespace SportsData.Infrastructure.Dtos.NbaApi
{
    public class GetGamesByDateDtoResponse 
    {
        public int Status { get; }
        public string Message { get; }
        public int Results { get; }
        public List<string> Filters { get; }
        public List<NbaApiGameDto> Games { get; }
        public GetGamesByDateDtoResponse(int status, string message, int results, List<string> filters, List<NbaApiGameDto> games)
        {
            Status = status;
            Message = message;
            Results = results;
            Filters = filters;
            Games = games;
        }
    }
}
