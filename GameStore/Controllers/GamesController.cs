using GameStore.Data;
using GameStore.Models;
using GameStore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
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
        public async Task<IActionResult> GetAllGames()
        {
            return new OkObjectResult(await _gamesService.GetAllGames());
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetGame(int id)
        {
            return new OkObjectResult(await _gamesService.GetGameById(id));
        }
        [HttpPost]
        public async Task<IActionResult> AddGame([FromBody] GameModel newGame)
        {
            return new OkObjectResult(await _gamesService.AddGame(newGame));
        }
        [HttpPut]
        public async Task<IActionResult> EditGame([FromBody] GameModel game)
        {
            return new OkObjectResult(await _gamesService.AddGame(game));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteGame(int id)
        {
            return new OkObjectResult(await _gamesService.DeleteGame(id));
        }
    }
}