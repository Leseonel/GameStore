using GameStore.Filters;
using GameStore.Services.ServiceInterfaces;
using GameStore.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class GamesController : Controller
    {
        private readonly IGamesService _gamesService;
        private readonly IFilterService _filterService;
        public GamesController(IGamesService gamesService,IFilterService filterService)
        {
            _gamesService = gamesService;
            _filterService = filterService;
        }
        [AllowAnonymous]
        [HttpGet]
        [Route("AllGame")]
        public async Task<IActionResult> GetAllGames()
        {
            return new OkObjectResult(await _gamesService.GetAllGames());
        }

        [HttpGet]
        [Route("Game/{id}")]
        public async Task<IActionResult> GetGame(Guid id)
        {
            return new OkObjectResult(await _gamesService.GetGameById(id));
        }
        [HttpPost]
        [Route("AddGame")]
        public async Task<IActionResult> AddGame([FromBody] CreateGameViewModel newGame)
        {
            return new OkObjectResult(await _gamesService.AddGame(newGame));
        }
        [HttpPost]
        [Route("Filter")]
        public async Task<IActionResult> FilterGamesByGenreId([FromBody] List<GameFilter> gameFilters)
        {
            return new OkObjectResult(await _filterService.FilterGamesByGenreId(gameFilters));
        }
        [HttpPost]
        [Route("FilterName")]
        public async Task<IActionResult> FilterGamesByName([FromBody] List<GameFilter> gameFilters)
        {
            return new OkObjectResult(await _filterService.FilterGamesByName(gameFilters));
        }
        [HttpPut]
        [Route("EditGame/{id}")]
        public async Task<IActionResult> EditGame([FromBody] EditGameViewModel editedGame, Guid id)
        {
            return new OkObjectResult(await _gamesService.EditGame(editedGame, id));
        }
        [HttpDelete]
        [Route("DeleteGame/{id}")]
        public async Task<IActionResult> DeleteGame(Guid id)
        {
            return new OkObjectResult(await _gamesService.DeleteGame(id));
        }
    }
}