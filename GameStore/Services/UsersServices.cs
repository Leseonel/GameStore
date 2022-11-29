using GameStore.CustomExceptions;
using GameStore.Data;
using GameStore.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Services
{
    public class UsersService
    {
        private readonly GameStoreContext _context;
        public UsersService(GameStoreContext context)
        {
            _context = context;
        }
        public async Task<UserModel> GetUserById(int id)
        {

            UserModel user = await _context.Users.Where(users => users.UserId == id).FirstOrDefaultAsync();
            if(user == null)
            {
                throw new DoesNotExistException("User with that ID not found ");
            }
            return user;
        }
    }
}