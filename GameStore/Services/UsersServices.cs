using GameStore.Data;
using GameStore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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
        public async Task<List<UserModel>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task<UserModel> GetUserById(int id)
        {
            return await _context.Users.Where(users => users.UserId == id).FirstOrDefaultAsync();
        }
    }
}