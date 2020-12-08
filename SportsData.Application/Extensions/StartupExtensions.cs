using Microsoft.Extensions.DependencyInjection;
using SportsData.Application.Services.Nba;

namespace SportsData.Application.Extensions
{
    public static class StartupExtensions
    {
        public static void AddSportsDataApplicationLayer(this IServiceCollection services)
        {
            services.AddTransient<INbaApiService, NbaApiService>();
        }
    }
}
