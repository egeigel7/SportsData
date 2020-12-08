using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportsData.Application.Services.Nba;
using SportsData.Infrastructure.Dtos.NbaApi;
using unirest_net.http;

namespace SportsDataApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NbaController : BaseController
    {
        INbaApiService _service;
        public NbaController(INbaApiService service)
        {
            _service = service;
        }

        [HttpGet("games/{date}")]
        public async Task<GetGamesByDateDtoResponse> GetGamesByDate(DateTime date)
        {
            // var rundownApiUrl = $"https://therundown-therundown-v1.p.rapidapi.com/sports/{nbaSportsId}/events/{date}?includescores&offset=0";
            var response = await _service.GetGamesByDate(date);
            return response;
        }
    }
}
