using GameStore.CustomExceptions;
using GameStore.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Data.Repositories.UserRepository
{
    public class UsersRepository: IUsersRepository
    {
        private readonly GameStoreContext _context;
        public UsersRepository(GameStoreContext context)
        {
            _context = context;
        }
    }
}
