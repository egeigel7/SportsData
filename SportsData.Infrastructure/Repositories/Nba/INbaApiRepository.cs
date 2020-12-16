using SportsData.Infrastructure.Dtos.NbaApi;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SportsData.Infrastructure.Repositories.Nba
{
    public interface INbaApiRepository
    {
        Task<GetGamesByDateDtoResponse> GetGamesByDate(DateTime date);
    }
}
