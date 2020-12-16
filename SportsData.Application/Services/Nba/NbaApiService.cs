using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SportsData.Application.Mappers.Nba;
using SportsData.Core.Entities.Nba;
using SportsData.Infrastructure.Dtos.NbaApi;
using SportsData.Infrastructure.Repositories.Nba;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SportsData.Application.Services.Nba
{
    public class NbaApiService : INbaApiService
    {
        private readonly INbaApiRepository _repository;
        private readonly IGetGamesByDateResponseMapper _mapper;
        private readonly int nbaSportsId = 4;
        public NbaApiService(INbaApiRepository repository, IGetGamesByDateResponseMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<Game>> GetGamesByDate(DateTime date)
        {
            var response = await _repository.GetGamesByDate(date);
            var mappedGames = _mapper.Convert(response);
            return mappedGames;

        }
    }
}
