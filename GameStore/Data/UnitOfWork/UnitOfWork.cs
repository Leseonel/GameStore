using GameStore.Data.Repositories.FilterRepository;
using GameStore.Data.Repositories.GameCommentRepository;
using GameStore.Data.Repositories.GameRepository;
using GameStore.Data.Repositories.GenreRepository;
using GameStore.Data.Repositories.UserRepository;

#pragma warning disable S3881 //delete if using UnitOfWorks.Dispose Outside of repository

namespace GameStore.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GameStoreContext _context;
        public IGamesRepository Games { get; private set; }
        public IGenresRepository Genres { get; private set; }
        public IFilterRepository Filters { get; private set; }
        public IUsersRepository Users { get; private set; }
        public IGameCommentsRepository Comments { get; private set; }

        public UnitOfWork(GameStoreContext context)
        {
            _context = context;
            Games = new GamesRepository(_context);
            Genres = new GenresRepository(_context);
            Filters = new FilterRepository(_context);
            Users = new UsersRepository(_context);
            Comments = new GameCommentsRepository(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
             _context.Dispose();
        }
    }
}
