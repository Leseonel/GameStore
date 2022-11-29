using GameStore.CustomExceptions;
using GameStore.Models;
using GameStore.Services;
using Microsoft.AspNetCore.Mvc;
using Nest;
using NLog;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.Controllers
{
    [Route("api/[controller]")]
    public class GamesController : Controller
    {
        private readonly GamesService _gamesService;
        public GamesController(GamesService gamesService)
        {
            _gamesService = gamesService;
        }
        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> GetAllGames()
        {
            return new OkObjectResult(await _gamesService.GetAllGames());
        }

        [HttpGet]
        [Route("Game/{id}")]
        public async Task<IActionResult> GetGame(int id)
        {
            return new OkObjectResult(await _gamesService.GetGameById(id));
        }

        [HttpPost]
        [Route("AddGame")]
        public async Task<IActionResult> AddGame([FromBody] GameModel newGame)
        {
            return new OkObjectResult(await _gamesService.AddGame(newGame));
        }

        [HttpPost]
        [Route("Filter")]
        public async Task<IActionResult> FilterGamesByGenresAndName([FromBody] List<int> genresId, string name)
        {
            return new OkObjectResult(await _gamesService.FilterGamesByGenresAndName(genresId, name));
        }

        [HttpPut]
        [Route("Edit/{id}")]
        public async Task<IActionResult> EditGame([FromBody] GameModel editedGame, int id)
        {
            return new OkObjectResult(await _gamesService.EditGame(editedGame, id));
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteGame(int id)
        {
            return new OkObjectResult(await _gamesService.DeleteGame(id));
        }
    }
}