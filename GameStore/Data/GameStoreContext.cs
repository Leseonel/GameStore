using GameStore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace GameStore.Data
{
    public class GameStoreContext : IdentityDbContext<UserModel>
    {
        public GameStoreContext(DbContextOptions<GameStoreContext> options) : base(options)
        {
        }
        public DbSet<PaymentTypeModel> PaymentTypes { get; set; }
        public DbSet<OrderModel> Orders { get; set; }
        public DbSet<OrderedGamesModel> OrderedGames { get; set; }
        public DbSet<GenreModel> Genres { get; set; }
        public DbSet<GenderModel> Genders { get; set; }
        public DbSet<GameModel> Games { get; set; }
        public DbSet<CurrencyModel> Currencys { get; set; }
        public DbSet<CommentModel> Comments { get; set; }
        public DbSet<GamesAndGenresModel> GamesAndGenres { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<GenreModel>()
                .HasMany(e => e.Children)
                .WithOne(e => e.Parent)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<GamesAndGenresModel>()
                .HasIndex(u => new { u.GameId, u.GenreId })
                .IsUnique();
            builder.Entity<GamesAndGenresModel>()
                .HasKey(x => x.GamesAndGenresId);

            builder.Entity<GamesAndGenresModel>()
                .HasOne<GameModel>(x => x.Game)
                .WithMany(x => x.GameAndGenre)
                .HasForeignKey(x => x.GameId);
            builder.Entity<GamesAndGenresModel>()
                .HasOne<GenreModel>(x => x.Genre)
                .WithMany(x => x.GameAndGenre)
                .HasForeignKey(x => x.GenreId);

            base.OnModelCreating(builder);
        }
        public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ChangeTracker.Entries<CommentModel>()
                .Where(e => e.State == EntityState.Deleted)
                .ToList()
                .ForEach(e =>
                {
                    e.State = EntityState.Modified;
                    e.Entity.DeletedAt = DateTime.Now;

                });
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}