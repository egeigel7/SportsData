using Microsoft.Extensions.DependencyInjection;
using SportsData.Application.Mappers.Nba;
using SportsData.Application.Services.Nba;

namespace SportsData.Application.Extensions
{
    public static class StartupExtensions
    {
        public static void AddSportsDataApplicationLayer(this IServiceCollection services)
        {
            services.AddTransient<INbaService, NbaService>();
            services.AddTransient<IGetGamesByDateResponseMapper, GetGamesByDateResponseMapper>();
        }
    }
}
