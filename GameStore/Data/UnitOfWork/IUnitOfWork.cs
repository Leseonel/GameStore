using GameStore.Data.Repositories;
using GameStore.Data.Repositories.FilterRepository;
using GameStore.Data.Repositories.GameRepository;
using GameStore.Data.Repositories.GenreRepository;
using GameStore.Data.Repositories.UserRepository;
using System;

namespace GameStore.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IGamesRepository Games { get; }
        IGenresRepository Genres { get; }
        IFilterRepository Filters { get; }
        IUsersRepository Users { get; }

        int Complete();
    }
}
