using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SportsData.Application.Entities.Dtos;
using SportsData.Application.Services.Nba;
using SportsData.Core.Entities.Nba;

namespace SportsDataApp.Api.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowAnyCorsPolicy")]
    [ApiController]
    public class NbaController : BaseController
    {
        INbaService _service;
        public NbaController(INbaService service)
        {
            _service = service;
        }

        [HttpGet("games")]
        public async Task<List<Matchup>> GetUpcomingGames()
        {
            var response = await _service.GetUpcomingGames();
            return response;
        }

        [HttpGet("games/{date}")]
        public async Task<List<Matchup>> GetGamesByDate(DateTime date)
        {
            var response = await _service.GetGamesByDate(date);
            return response;
        }

        [HttpPost("stats")]
        public async Task<TeamSeason> GetStatsByTeamName(GetStatsByTeamNameRequestDto dto)
        {
            if (string.IsNullOrEmpty(dto.SeasonYear) || string.IsNullOrEmpty(dto.TeamName))
                throw new NullReferenceException("A season year or team name was not provided");
            var response = await _service.GetSeasonStatsByTeamName(dto);
            return response;
        }


    }
}
