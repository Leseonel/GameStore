using GameStore.Models;
using GameStore.ViewModels;
using System.Threading.Tasks;

namespace GameStore.Data.Repositories.UserRepository
{
    public interface IUsersRepository
    {
        Task<UserViewModel> EditUser(UserViewModel user);
    }
}
