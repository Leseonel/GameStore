using GameStore.Models;
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
        public DbSet<GamesAndGenresModel> GamesAndGenres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GenreModel>()
                .HasMany(e => e.Children)
                .WithOne(e => e.Parent)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<GamesAndGenresModel>()
                .HasOne<GameModel>(x => x.Game)
                .WithMany(x => x.GameAndGenre)
                .HasForeignKey(x => x.GameId);
            modelBuilder.Entity<GamesAndGenresModel>()
                .HasOne<GenreModel>(x => x.Genre)
                .WithMany(x => x.GameAndGenre)
                .HasForeignKey(x => x.GenreId);
        }
    }
}