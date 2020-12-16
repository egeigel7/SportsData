using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsData.Application.Services.Nba;
using SportsData.Core.Entities.Nba;

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
        public async Task<List<Game>> GetGamesByDate(DateTime date)
        {
            // var rundownApiUrl = $"https://therundown-therundown-v1.p.rapidapi.com/sports/{nbaSportsId}/events/{date}?includescores&offset=0";
            var response = await _service.GetGamesByDate(date);
            return response;
        }


    }
}
