using GameStore.CustomExceptions;
using GameStore.Models;
using GameStore.Services;
using GameStore.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GameStore.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class UsersController : Controller
    {

        private readonly UsersService _usersService;
        public UsersController(UsersService usersService)
        {
            _usersService = usersService;
        }
        [HttpPut]
        [Route("EditUser")]
        public async Task<IActionResult> EditUser([FromBody] UserViewModel editedUser)
        {
            return new OkObjectResult(await _usersService.EditUser(editedUser));
        }
    }
}