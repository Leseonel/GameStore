using GameStore.Filters;
using GameStore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameStore.Data.UnitOfWork;
using GameStore.Data.Repositories.FilterRepository;
using GameStore.Services.ServiceInterfaces;

namespace GameStore.Services
{
    public class FilterService : IFilterService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFilterRepository _filterRepository;

        public FilterService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _filterRepository = _unitOfWork.Filters;
        }
        public Task<List<GameModel>> FilterGamesByName(List<GameFilter> gamesFilters)
        {
            return _filterRepository.FilterGamesByName(gamesFilters);
        }
        public Task<List<GamesAndGenresModel>> FilterGamesByGenreId(List<GameFilter> gamesFilters)
        {
            return _filterRepository.FilterGamesByGenreId(gamesFilters);
        }
    }
}
