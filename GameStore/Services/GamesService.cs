using GameStore.Data.Repositories;
using GameStore.Data.Repositories.GameRepository;
using GameStore.Data.UnitOfWork;
using GameStore.Models;
using GameStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.Services
{
    public class GamesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGamesRepository _gamesRepository;

        public GamesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _gamesRepository = _unitOfWork.Games;
        }
        public Task<List<GameModel>> GetAllGames()
        {
            return _gamesRepository.GetAllGames();
        }
        public Task<GameModel> GetGameById(Guid id)
        {
            return _gamesRepository.GetGameById(id);
        }
        public Task<GameModel> AddGame(CreateGameViewModel newGame)
        {
            return _gamesRepository.AddGame(newGame);
        }
        public Task<GameModel> EditGame(EditGameViewModel editedGame, Guid id)
        {
            return _gamesRepository.EditGame(editedGame, id);
        }
        public Task<GameModel> DeleteGame(Guid id)
        {
            return _gamesRepository.DeleteGame(id);
        }
    }
}