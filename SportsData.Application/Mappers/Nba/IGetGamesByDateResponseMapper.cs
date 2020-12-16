using SportsData.Core.Entities.Nba;
using SportsData.Infrastructure.Dtos.NbaApi;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportsData.Application.Mappers.Nba
{
    public interface IGetGamesByDateResponseMapper
    {
        List<Game> Convert(GetGamesByDateDtoResponse response);
    }
}
