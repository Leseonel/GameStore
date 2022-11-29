using GameStore.CustomExceptions;
using GameStore.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GameStore.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {

        private readonly UsersService _usersService;
        public UsersController(UsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                return new OkObjectResult(await _usersService.GetUserById(id));
            }
            catch(DoesNotExistException e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}