using SportsData.Application.Entities.Dtos;
using SportsData.Infrastructure.Dtos.NbaApi;
using System.Collections.Generic;

namespace SportsData.Application.Mappers.Nba
{
    public interface IGetGamesByDateResponseMapper
    {
        List<Matchup> Convert(GetGamesByDateDtoResponse response);
    }
}
