using GameStore.CustomExceptions;
using GameStore.Data.Repositories.RepositoryInterfaces;
using GameStore.Models;
using GameStore.ValidateData;
using GameStore.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Data.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly GameStoreContext _context;
        public UsersRepository(GameStoreContext context)
        {
            _context = context;
        }
        public async Task<UserViewModel> EditUser(UserViewModel user)
        {
            ValidateOnNull<UserViewModel>.ValidateDataOnNull(user);
            var userToUpdate = await _context.Users.Where(x => x.Id == user.UserId.ToString()).FirstOrDefaultAsync();
            ValidateOnNull<UserModel>.ValidateDataOnNull(userToUpdate);
            if (_context.Users.Any(x => x.Email == user.Email))
            {
                throw new CouldNotUpdateUserException("User with this email already exists");
            }
            if (_context.Users.Any(x => x.UserName == user.UserName))
            {
                throw new CouldNotUpdateUserException("User with this UserName already exists");
            }

            userToUpdate.UserName = user.UserName;
            userToUpdate.FirstName = user.FirstName;
            userToUpdate.LastName = user.LastName;
            userToUpdate.Country = user.Country;
            userToUpdate.ZipCode = user.ZipCode;
            userToUpdate.Email = user.Email;
            userToUpdate.PhoneNumber = user.PhoneNumber;
            userToUpdate.AvatarUrl = user.AvatarUrl;
            userToUpdate.GenderId = user.GenderId;

            await _context.SaveChangesAsync();

            return user;
        }
    }
}
