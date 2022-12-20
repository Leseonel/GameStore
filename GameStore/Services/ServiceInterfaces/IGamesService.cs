using GameStore.Models;
using GameStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.Services.ServiceInterfaces
{
    public interface IGamesService
    {
        Task<List<GameModel>> GetAllGames();
        Task<GameModel> GetGameById(Guid id);
        Task<GameModel> AddGame(CreateGameViewModel newGame);
        Task<GameModel> EditGame(EditGameViewModel editedGame, Guid id);
        Task<GameModel> DeleteGame(Guid id);
    }
}
