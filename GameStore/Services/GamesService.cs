using GameStore.CustomExceptions;
using GameStore.Data;
using GameStore.Models;
using GameStore.ViewModels;
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
        public async Task<GameModel> AddGame(CreateGameDto newGame)
        {
            if (newGame == null || string.IsNullOrEmpty(newGame.GameName))
            {
                throw new ArgumentNullException(nameof(newGame));
            }
            if (await _context.Games.Where(g => g.GameName == newGame.GameName).AnyAsync())
            {
                throw new AlreadyExistException("This game already exists in GameStore");
            }
            GameModel game = new GameModel()
            {
                GameName = newGame.GameName,
                GameDeveloper = newGame.GameDeveloper,
                GamePublisher = newGame.GamePublisher,
                GamePrice = newGame.GamePrice,
                GameDescription = newGame.GameDescription,
                GameImgUrl = newGame.GameImgUrl,
                GameReleaseDate = newGame.GameReleaseDate
            };
            await _context.Games.AddAsync(game);
            await _context.SaveChangesAsync();

            var savedGame = await _context.Games.Where(x => x.GameName == game.GameName).SingleOrDefaultAsync();
            if (newGame.GenreIds != null && newGame.GenreIds.Count != 0)
            {
                return await AddGenresToGame(savedGame, newGame.GenreIds);
            }
            return savedGame;
        }
        public async Task<GameModel> AddGenresToGame(GameModel game, List<int> genreIds)
        {
            game.GameAndGenre = new List<GamesAndGenresModel>();
            foreach (var genreId in genreIds)
            {
                var genre = await _context.Genres.Where(x => x.GenreId == genreId).SingleOrDefaultAsync();
                if (genre != null)
                {
                    game.GameAndGenre.Add(new GamesAndGenresModel() { GameId = game.GameId, GenreId = genre.GenreId });
                }
            }
            await _context.SaveChangesAsync();


            return game;
        }
        public async Task<GameModel> EditGame(CreateGameDto editedGame, int id)
        {
            var gameToUpdate = await _context.Games.Where(game => game.GameId == id).Include(x => x.GameAndGenre).FirstOrDefaultAsync();
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
            if (editedGame.GenreIds != null && editedGame.GenreIds.Count != 0)
            {
                gameToUpdate.GameAndGenre = await UpdateGameGenres(gameToUpdate, editedGame.GenreIds);
            }
            await _context.SaveChangesAsync();

            return gameToUpdate;
        }
        public async Task<IList<GamesAndGenresModel>> UpdateGameGenres(GameModel gameToUpdate, List<int> genreIds)
        {
            if (gameToUpdate.GameAndGenre == null || gameToUpdate.GameAndGenre.Count == 0)
            {
                gameToUpdate.GameAndGenre = new List<GamesAndGenresModel>();
                foreach (var genreId in genreIds)
                {
                    var genre = await _context.Genres.Where(x => x.GenreId == genreId).SingleOrDefaultAsync();
                    if (genre != null)
                    {
                        gameToUpdate.GameAndGenre.Add(new GamesAndGenresModel() { GameId = gameToUpdate.GameId, GenreId = genre.GenreId });
                    }
                }
                return gameToUpdate.GameAndGenre;
            }
            foreach (var genreId in genreIds)
            {
                if (gameToUpdate.GameAndGenre.Any(x => x.GenreId != genreId))
                {
                    var genre = await _context.Genres.Where(x => x.GenreId == genreId).SingleOrDefaultAsync(); 
                    if (genre != null) { gameToUpdate.GameAndGenre.Add(new GamesAndGenresModel() 
                    { 
                        GameId = gameToUpdate.GameId, GenreId = genre.GenreId });
                    }
                }
            }
            foreach (var genre in gameToUpdate.GameAndGenre)
            {
                if (!genreIds.Contains(genre.GenreId))
                {
                    gameToUpdate.GameAndGenre.Remove(genre);
                }
            }
            return gameToUpdate.GameAndGenre;
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
    }
}