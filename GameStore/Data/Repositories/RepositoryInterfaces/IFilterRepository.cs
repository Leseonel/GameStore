using GameStore.Filters;
using GameStore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.Data.Repositories.RepositoryInterfaces
{
    public interface IFilterRepository
    {
        Task<List<GameModel>> FilterGamesByName(List<GameFilter> gamesFilters);
        Task<List<GamesAndGenresModel>> FilterGamesByGenreId(List<GameFilter> gamesFilters);
    }
}
