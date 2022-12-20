using GameStore.Models;
using GameStore.Services;
using GameStore.Services.ServiceInterfaces;
using GameStore.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GameStore.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class GameCommentController : Controller
    {
        private readonly IGameCommentService _gameCommentsService;
        public GameCommentController(IGameCommentService gameCommentService)
        {
            _gameCommentsService = gameCommentService;
        }
        [AllowAnonymous]
        [HttpGet]
        [Route("AllGameComments")]
        public async Task<IActionResult> GetAllGameAllComments()
        {
            return new OkObjectResult(await _gameCommentsService.GetAllGameAllComments());
        }
        [HttpGet]
        [Route("AllGameCommentsForGame")]
        public async Task<IActionResult> GetAllCommentsForGame(Guid gameId)
        {
            return new OkObjectResult(await _gameCommentsService.GetAllCommentsForGame(gameId));
        }
        [HttpPost]
        [Route("AddCommentToGame")]
        public async Task<IActionResult> AddCommentToGame([FromBody] CommentViewModel comment, Guid? parentCommentId)
        {
            return new OkObjectResult(await _gameCommentsService.AddCommentToGame(comment, parentCommentId));
        }
        [HttpPut]
        [Route("EditComment")]
        public async Task<IActionResult> EditComment([FromBody] CommentModel editedComment, Guid id)
        {
            return new OkObjectResult(await _gameCommentsService.EditComment(editedComment, id));
        }
        [HttpPut]
        [Route("RestoreComment")]
        public async Task<IActionResult> RestoreComment(Guid id)
        {
            return new OkObjectResult(await _gameCommentsService.RestoreComment(id));
        }

        [HttpDelete]
        [Route("DeleteComment/{id}")]
        public async Task<IActionResult> DeleteComment(Guid id)
        {
            return new OkObjectResult(await _gameCommentsService.DeleteComment(id));
        }
        [HttpDelete]
        [Route("DeleteCommentForUser/{id}")]
        public async Task<IActionResult> DeleteCommentForUser(Guid id)
        {
            return new OkObjectResult(await _gameCommentsService.DeleteCommentForUser(id));
        }
    }
}