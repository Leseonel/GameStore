using GameStore.Models;
using GameStore.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.Data.Repositories.GameRepository
{
    public interface IGamesRepository
    {
        Task<List<GameModel>> GetAllGames();
        Task<GameModel> GetGameById(int id);
        Task<GameModel> AddGame(CreateGameViewModel newGame);
        Task<GameModel> EditGame(EditGameViewModel editedGame, int id);
        Task<GameModel> DeleteGame(int id);
    }
}
