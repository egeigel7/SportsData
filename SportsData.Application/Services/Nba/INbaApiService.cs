using SportsData.Infrastructure.Dtos.NbaApi;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SportsData.Application.Services.Nba
{
    public interface INbaApiService
    {
        Task<GetGamesByDateDtoResponse> GetGamesByDate(DateTime date);
    }
}
