using GameStore.Models;
using GameStore.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System;
using GameStore.Data.UnitOfWork;
using System.Linq;
using GameStore.CustomExceptions;
using System.Text;
using AutoMapper;
using GameStore.Services.TokenService;
using GameStore.ValidateData;

namespace GameStore.Services
{
    public class AccountsService
    {
        private readonly JwtTokenService _jwtTokenService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<UserModel> _userManager;
        private readonly SignInManager<UserModel> _signInManager;
        private readonly IMapper _mapper;
        public AccountsService(UserManager<UserModel> userManager, SignInManager<UserModel> signInManager, IUnitOfWork unitOfWork,IMapper mapper, JwtTokenService jwtTokenService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _jwtTokenService = jwtTokenService;
        }
        public async Task<UserViewModel> RegisterUser(UserRegistrationViewModel userInfo)
        {
            ValidateOnNull<UserRegistrationViewModel>.ValidateDataOnNull(userInfo);

            var user = new UserModel { UserName = userInfo.UserName, Email = userInfo.Email, FirstName = userInfo.FirstName, LastName = userInfo.LastName };
            var result = await _userManager.CreateAsync(user, userInfo.Password);

            if (result.Succeeded)
            {
                return _mapper.Map<UserViewModel>(await _userManager.FindByEmailAsync(userInfo.Email));
            }
            StringBuilder errorMessage = new StringBuilder();
            foreach (var error in result.Errors.ToList())
            {
                errorMessage.AppendLine(error.Description);
            }
            throw new CouldNotRegisterUserException(errorMessage.ToString());
        }
        public async Task<UserLoginResponseViewModel> LoginUser(UserLoginViewModel loginInput)
        {
            var user = await _userManager.FindByNameAsync(loginInput.UserName);
            var result = await _signInManager.CheckPasswordSignInAsync(user, loginInput.Password, false);

            if (result.Succeeded)
            {
                var roles = await _userManager.GetRolesAsync(user);
                var accessToken = await _jwtTokenService.GenerateJwtAccessToken(user, roles);
                await _userManager.SetAuthenticationTokenAsync(user, "JwtBearer", "Access Token", accessToken);
                var loggedUser = _mapper.Map<UserLoginResponseViewModel>(user);
                loggedUser.AccessToken = accessToken;

                return loggedUser;
            }
            if(!result.Succeeded)
            {
                throw new FailedToLoginException("Login Failed Incorrect Credintials");
            }
            return new UserLoginResponseViewModel();
        }
    }
}
