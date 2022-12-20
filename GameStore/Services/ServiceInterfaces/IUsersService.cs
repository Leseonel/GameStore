using GameStore.ViewModels;
using System.Threading.Tasks;

namespace GameStore.Services.ServiceInterfaces
{
    public interface IUsersService
    {
        Task<UserViewModel> EditUser(UserViewModel user);
    }
}
