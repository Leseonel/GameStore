using GameStore.ViewModels;
using System.Threading.Tasks;

namespace GameStore.Services.ServiceInterfaces
{
    public interface IAccountsService
    {
        Task<UserViewModel> RegisterUser(UserRegistrationViewModel userInfo);
        Task<UserLoginResponseViewModel> LoginUser(UserLoginViewModel loginInput);
        Task<UserLoginResponseViewModel> RefreshAccesToken(string refreshToken);
    }
}
