using GameStore.Data;
using GameStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Services
{
    public class GamesService
    {
        private readonly GameStoreContext _context;
        public GamesService(GameStoreContext context)
        {
            _context = context;
        }

        public async Task<List<GameModel>> GetAllGames()
        {
            return await _context.Games.ToListAsync();
        }
        public async Task<GameModel> GetGameById(int id)
        {
            return await _context.Games.Where(games => games.GameId == id).FirstOrDefaultAsync();
        }
        public async Task<GameModel> AddGame(GameModel newGame)
        {
            await _context.Games.AddAsync(newGame);
            await _context.SaveChangesAsync();

            var newlyAddedGame = await _context.Games.Where(game => game.GameName == newGame.GameName && game.GamePublisher == newGame.GamePublisher).FirstOrDefaultAsync();
            return newlyAddedGame;
        }
        public async Task<GameModel> EditGame([FromBody] GameModel game)
        {
            var editgame = await _context.Games.Where(games => games.GameId == game.GameId).FirstOrDefaultAsync();
            _context.Update(editgame.GameName);
            await _context.SaveChangesAsync();

            return editgame;
        }
        public async Task<GameModel> DeleteGame(int id)
        {
            var findGame = await _context.Games.Where(x => x.GameId == id).FirstOrDefaultAsync();
            _context.Games.Remove(findGame);
            await _context.SaveChangesAsync();
            return findGame;
        }
    }
}