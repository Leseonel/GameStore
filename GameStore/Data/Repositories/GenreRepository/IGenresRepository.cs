using GameStore.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.Data.Repositories.GenreRepository
{
    public interface IGenresRepository
    {
        Task<List<GenreModel>> GetAllGenres();
        Task<GenreModel> GetGenreById(Guid id);
        Task<GenreModel> AddGenre(GenreModel genre, Guid? genreId);
        Task<GenreModel> EditGenre(GenreModel editedGenre, Guid id);
        Task<GenreModel> DeleteGenre(Guid id);
    }
}
