using Microsoft.Extensions.DependencyInjection;
using SportsData.Infrastructure.Repositories.Nba;

namespace SportsData.Infrastructure.Extensions
{
    public static class StartupExtensions
    {
        public static void AddSportsDataInfrastructureLayer(this IServiceCollection services)
        {
            services.AddTransient<INbaApiRepository, NbaApiRepository>();
        }
    }
}
