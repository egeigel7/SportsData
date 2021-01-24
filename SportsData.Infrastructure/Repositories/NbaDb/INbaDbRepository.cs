using SportsData.Infrastructure.Dtos.NbaDb;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SportsData.Infrastructure.Repositories.NbaDb
{
    public interface INbaDbRepository
    {
        Task<NbaTeamPerformanceDbDto> GetNbaTeamSeasonStats(GetNbaTeamSeasonStatsRequestDto request);
    }
}
