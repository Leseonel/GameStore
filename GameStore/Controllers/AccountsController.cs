using GameStore.Models;
using GameStore.Services;
using GameStore.ViewModels;
using Microsoft.AspNetCore.Authorization;
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
        private readonly SignInManager<UserModel> _signInManager;
        public AccountsController(UserManager<UserModel> userManager, SignInManager<UserModel> signInManager, AccountsService accountsService)
        {
            _accountsService = accountsService;
            _userManager = userManager;
            _signInManager = signInManager;
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
        [Authorize]
        [HttpPost]
        [Route("SignOutUser")]
        public async Task<IActionResult> SignOutUser()
        {
            await _signInManager.SignOutAsync();
            return Ok(); 
        }

    }
}

