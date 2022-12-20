using GameStore.Models;
using GameStore.Services.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GameStore.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class GenresController : Controller
    {
        private readonly IGenresService _genresService;
        public GenresController(IGenresService genresService)
        {
            _genresService = genresService;
        }
        [HttpGet]
        [Route("AllGenre")]
        public async Task<IActionResult> GetAllGenres()
        {
            return new OkObjectResult(await _genresService.GetAllGenres());
        }
        [HttpGet]
        [Route("Genre/{id}")]
        public async Task<IActionResult> GetGenreById(Guid id)
        {
            return new OkObjectResult(await _genresService.GetGenreById(id));
        }
        [HttpPost]
        [Route("AddGenre")]
        public async Task<IActionResult> AddGenre([FromBody] GenreModel newGenre, Guid? genreId)
        {
            return new OkObjectResult(await _genresService.AddGenre(newGenre, genreId));
        }
        [HttpPut]
        [Route("EditGenre/{id}")]
        public async Task<IActionResult> EditGenre([FromBody] GenreModel editedGame, Guid id)
        {
            return new OkObjectResult(await _genresService.EditGenre(editedGame, id));
        }
        [HttpDelete]
        [Route("DeleteGenre/{id}")]
        public async Task<IActionResult> DeleteGenre(Guid id)
        {
            return new OkObjectResult(await _genresService.DeleteGenre(id));
        }
    }
}
