using GameStore.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Data
{
    public class GameStoreContext : DbContext
    {
        public GameStoreContext(DbContextOptions<GameStoreContext> options) : base(options)
        {
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<RoleModel> Roles { get; set; }
        public DbSet<PaymentTypeModel> PaymentTypes { get; set; }
        public DbSet<OrderModel> Orders { get; set; }
        public DbSet<OrderedGamesModel> OrderedGames { get; set; }
        public DbSet<GenreModel> Genres { get; set; }
        public DbSet<GenderModel> Genders { get; set; }
        public DbSet<GameModel> Games { get; set; }
        public DbSet<CurrencyModel> Currencys { get; set; }
        public DbSet<CommentModel> Comments { get; set; }

    }
}