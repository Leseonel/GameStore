using GameStore.CustomExceptions;
using GameStore.Models;
using GameStore.ValidateData;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Data.Repositories.GenreRepository
{
    public class GenresRepository: IGenresRepository
    {
        private readonly GameStoreContext _context;
        public GenresRepository(GameStoreContext context)
        {
            _context = context;
        }
        public async Task<List<GenreModel>> GetAllGenres()
        {
            List<GenreModel> genres = await _context.Genres.ToListAsync();

            return genres;
        }

        public async Task<GenreModel> GetGenreById(int id)
        {
            GenreModel genre = await _context.Genres.Where(genres => genres.GenreId == id).FirstOrDefaultAsync();
            if (genre == null)
            {
                throw new DoesNotExistsException("Genre not found with that ID");
            }
            return genre;
        }
        public async Task<GenreModel> AddGenre(GenreModel genre, int? genreId)
        {
            ValidateOnNull<GenreModel>.ValidateDataOnNull(genre);
            if (genreId == null)
            {
                if (await _context.Genres.Where(x => x.GenreName == genre.GenreName).AnyAsync())
                {
                    throw new AlreadyExistsException();
                }
                await _context.Genres.AddAsync(genre);
                await _context.SaveChangesAsync();
                return genre;
            }
            var parentGenre = await _context.Genres.Where(x => x.GenreId == genreId).Include(x => x.Children).SingleOrDefaultAsync();
            genre.ParentId = parentGenre.GenreId;
            genre.Parent = parentGenre;
            parentGenre.Children ??= new List<GenreModel>();
            parentGenre.Children.Add(genre);
            await _context.SaveChangesAsync();
            return genre;
        }

        public async Task<GenreModel> EditGenre(GenreModel editedGenre, int id)
        {
            var genreToUpdate = await _context.Genres.Where(genres => genres.GenreId == id).FirstOrDefaultAsync();
            if (genreToUpdate == null)
            {
                throw new DoesNotExistsException("Can not find a genre with that ID to edit");
            }
            genreToUpdate.GenreName = editedGenre.GenreName;
            await _context.SaveChangesAsync();

            return genreToUpdate;
        }
        
        public async Task<GenreModel> DeleteGenre(int id)
        {
            GenreModel findGenre = await _context.Genres.Where(x => x.GenreId == id).FirstOrDefaultAsync();
            if (findGenre == null)
            {
                throw new DoesNotExistsException("Can not find a genre to delete");
            }
            _context.Genres.Remove(findGenre);
            await _context.SaveChangesAsync();
            return findGenre;
        }
    }
}
