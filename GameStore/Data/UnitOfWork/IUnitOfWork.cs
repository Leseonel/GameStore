using GameStore.Data.Repositories.RepositoryInterfaces;
using System;

namespace GameStore.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IGamesRepository Games { get; }
        IGenresRepository Genres { get; }
        IFilterRepository Filters { get; }
        IUsersRepository Users { get; }
        IGameCommentsRepository Comments { get; }
        ICartRepository Carts { get; }
        int Complete();
    }
}
