using GameStore.Filters;
using GameStore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.Services.ServiceInterfaces
{
    public interface IFilterService
    {
        Task<List<GameModel>> FilterGamesByName(List<GameFilter> gamesFilters);
        Task<List<GamesAndGenresModel>> FilterGamesByGenreId(List<GameFilter> gamesFilters);
    }
}
