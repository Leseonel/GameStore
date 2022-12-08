using GameStore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.Data.Repositories.GenreRepository
{
    public interface IGenresRepository
    {
        Task<List<GenreModel>> GetAllGenres();
        Task<GenreModel> GetGenreById(int id);
        Task<GenreModel> AddGenre(GenreModel genre, int? genreId);
        Task<GenreModel> EditGenre(GenreModel editedGenre, int id);
        Task<GenreModel> DeleteGenre(int id);
    }
}
