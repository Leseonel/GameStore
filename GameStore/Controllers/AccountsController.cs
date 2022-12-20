using GameStore.Models;
using GameStore.Services.ServiceInterfaces;
using GameStore.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GameStore.Controllers
{
    [Route("api/[controller]")]
    public class AccountsController : Controller
    {
        private readonly IAccountsService _accountsService;
        private readonly UserManager<UserModel> _userManager;
        private readonly SignInManager<UserModel> _signInManager;
        public AccountsController(UserManager<UserModel> userManager, SignInManager<UserModel> signInManager, IAccountsService accountsService)
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
        [HttpPost]
        [Route("CreateNewTokens")]
        public async Task<IActionResult> CreateNewTokensForUser(string refreshToken)
        {
            var result = await _accountsService.RefreshAccesToken(refreshToken);
            if (result == null)
            {
                return Unauthorized();
            }
            return new OkObjectResult(result);
        }
    }
}

