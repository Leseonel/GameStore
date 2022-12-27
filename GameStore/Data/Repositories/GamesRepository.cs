using GameStore.CustomExceptions;
using GameStore.Data.Repositories.RepositoryInterfaces;
using GameStore.Filters.Enums;
using GameStore.Models;
using GameStore.ValidateData;
using GameStore.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Data.Repositories
{
    public class GamesRepository : IGamesRepository
    {
        private readonly GameStoreContext _context;
        public GamesRepository(GameStoreContext context)
        {
            _context = context;
        }

        public Task<List<GameModel>> GetAllGames()
        {
            return _context.Games.ToListAsync();
        }

        public async Task<GameModel> GetGameById(Guid id)
        {
            GameModel game = await _context.Games.Where(games => games.GameId == id).FirstOrDefaultAsync();
            ValidateOnNull<GameModel>.ValidateDataOnNull(game);

            return game;
        }
        public async Task<GameModel> AddGame(CreateGameViewModel newGame)
        {
            ValidateOnNull<CreateGameViewModel>.ValidateDataOnNull(newGame);
            ValidateOnNullAndEmpty<string>.ValidateDataOnNullAndEmpty(newGame.GameName);

            if (await _context.Games.Where(g => g.GameName == newGame.GameName).AnyAsync())
            {
                throw new AlreadyExistsException("This game already exists in GameStore");
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
                savedGame = await AddGenresToGame(savedGame, newGame.GenreIds);
            }

            await _context.SaveChangesAsync();

            return savedGame;
        }
        private async Task<GameModel> AddGenresToGame(GameModel game, List<Guid> genreIds)
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

            return game;
        }
        public async Task<GameModel> EditGame(EditGameViewModel editedGame, Guid id)
        {
            var gameToUpdate = await _context.Games.Where(game => game.GameId == id).Include(x => x.GameAndGenre).FirstOrDefaultAsync();

            if (gameToUpdate != null)
            {
                gameToUpdate.GameName = editedGame.GameName;
                gameToUpdate.GameDescription = editedGame.GameDescription;
                gameToUpdate.GameDeveloper = editedGame.GameDeveloper;
                gameToUpdate.GamePublisher = editedGame.GamePublisher;
                gameToUpdate.GamePrice = editedGame.GamePrice;
                gameToUpdate.GameReleaseDate = editedGame.GameReleaseDate;
                gameToUpdate.GameImgUrl = editedGame.GameImgUrl;
            }

            foreach (var x in editedGame.UpdateGameGenres)
            {
                if (x.EditType == EditTypeValue.Add)
                {
                    if (!gameToUpdate.GameAndGenre.Any(g => g.GenreId == x.GenreId))
                    {
                        gameToUpdate.GameAndGenre.Add(new GamesAndGenresModel { GenreId = x.GenreId });
                    }
                }
                else if (x.EditType == EditTypeValue.Remove)
                {
                    var y = _context.GamesAndGenres.Where(game => game.GameId == gameToUpdate.GameId && game.GenreId == x.GenreId).FirstOrDefault();
                    gameToUpdate.GameAndGenre.Remove(y);
                }
            }
            await _context.SaveChangesAsync();

            return gameToUpdate;
        }
        public async Task<GameModel> DeleteGame(Guid id)
        {
            GameModel findGame = await _context.Games.Where(x => x.GameId == id).FirstOrDefaultAsync();

            if (findGame == null)
            {
                throw new DoesNotExistsException("Can not find a game to delete");
            }
            _context.Games.Remove(findGame);
            await _context.SaveChangesAsync();

            return findGame;
        }
    }
}
