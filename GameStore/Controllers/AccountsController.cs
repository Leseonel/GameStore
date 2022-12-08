using GameStore.Models;
using GameStore.Services;
using GameStore.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Controllers
{
    [Route("api/[controller]")]
    public class AccountsController : Controller
    {
        private readonly AccountsService _accountsService;
        private readonly UserManager<UserModel> _userManager;
        public AccountsController(UserManager<UserModel> userManager,AccountsService accountsService)
        {
            _accountsService = accountsService;
            _userManager = userManager;
        }
        [HttpPost]
        [Route("RegisterUser")]
        public async Task<IActionResult> RegisterUser(UserRegistrationViewModel userInfo)
        {
            return new OkObjectResult(await _accountsService.RegisterUser(userInfo));
        }
        [HttpPost]
        [Route("LoginUser")]
        public async Task<IActionResult> LoginUser(UserLoginViewModel loginInput)
        {
            return new OkObjectResult(await _accountsService.LoginUser(loginInput));
        }
    }
}

