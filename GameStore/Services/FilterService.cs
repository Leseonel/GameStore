using GameStore.Data;
using GameStore.Filters.Enums;
using GameStore.Filters;
using GameStore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using GameStore.Data.Repositories.GameRepository;
using GameStore.Data.UnitOfWork;
using GameStore.Data.Repositories.FilterRepository;
using Nest;

namespace GameStore.Services
{
    public class FilterService
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
