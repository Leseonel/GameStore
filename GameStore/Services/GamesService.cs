using GameStore.CustomExceptions;
using GameStore.Data;
using GameStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
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
            List<GameModel> games = await _context.Games.ToListAsync();
            if (games.Count == 0)
            {
                throw new DoesNotExistException("Games Not Found");
            }
            return games;
        }
        public async Task<GameModel> GetGameById(int id)
        {
            GameModel game = await _context.Games.Where(games => games.GameId == id).FirstOrDefaultAsync();
            if (game == null)
            {
                throw new DoesNotExistException("Game not found with that ID");
            }
            return game;
        }
        public async Task<GameModel> AddGame(GameModel newGame)
        {
            if (await _context.Games.Where(g => g.GameName == newGame.GameName).AnyAsync())
            {
                throw new AlreadyExistException("This game already exists in GameStore");
            }
            await _context.Games.AddAsync(newGame);
            await _context.SaveChangesAsync();

            return newGame;
        }
        public async Task<GameModel> EditGame(GameModel editedGame, int id)
        {
            var gameToUpdate = await _context.Games.Where(game => game.GameId == id).FirstOrDefaultAsync();
            if (gameToUpdate == null)
            {
                throw new DoesNotExistException("Can not find a game with that ID to edit");
            }
            gameToUpdate.GameName = editedGame.GameName;
            gameToUpdate.GameDescription = editedGame.GameDescription;
            gameToUpdate.GameDeveloper = editedGame.GameDeveloper;
            gameToUpdate.GamePublisher = editedGame.GamePublisher;
            gameToUpdate.GamePrice = editedGame.GamePrice;
            gameToUpdate.GameReleaseDate = editedGame.GameReleaseDate;
            gameToUpdate.GameImgUrl = editedGame.GameImgUrl;
            await _context.SaveChangesAsync();

            return gameToUpdate;
        }
        public async Task<GameModel> DeleteGame(int id)
        {
            GameModel findGame = await _context.Games.Where(x => x.GameId == id).FirstOrDefaultAsync();
            if (findGame == null)
            {
                throw new DoesNotExistException("Can not find a game to delete");
            }
            _context.Games.Remove(findGame);
            await _context.SaveChangesAsync();
            return findGame;
        }
        public async Task<List<GameModel>> FilterGamesByGenresAndName(List<int> genres, string name)
        {
            var result = new List<GameModel>();
            if (!string.IsNullOrEmpty(name))
            {
                result = name.Length < 3 ? result :
                    await _context.Games.Where(game => game.GameName.Contains(name)).ToListAsync();
            }
            else if (genres.Count != 0 && string.IsNullOrEmpty(name))
            {
                var filterGenres = _context.GamesAndGenres.Where(g => genres.Contains(g.GenreId));
                result = await _context.Games.Where(game => filterGenres.Any(gen => gen.GameId == game.GameId)).ToListAsync();
            }
            else
            {
                var filterGenres = _context.GamesAndGenres.Where(g => genres.Contains(g.GenreId));
                result = name.Length >= 3 ? await _context.Games.Where(game => filterGenres.Any(gen => gen.GameId == game.GameId) && game.GameName.Contains(name)).ToListAsync()
                    : await _context.Games.Where(game => filterGenres.Any(gen => gen.GameId == game.GameId)).ToListAsync();
            }
            if (result.Count == 0)
            {
                throw new DoesNotExistException();
            }
            return result;
        }
    }
}