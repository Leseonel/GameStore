using GameStore.Data.Repositories.GenreRepository;
using GameStore.Data.UnitOfWork;
using GameStore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.Services
{
    public class GenresService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenresRepository _genresRepository;

        public GenresService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _genresRepository = _unitOfWork.Genres;
        }

        public Task<List<GenreModel>> GetAllGenres()
        {
            return _genresRepository.GetAllGenres();
        }

        public Task<GenreModel> GetGenreById(int id)
        {
            return _genresRepository.GetGenreById(id);
        }

        public Task<GenreModel> AddGenre(GenreModel genre, int? genreId)
        {
            return _genresRepository.AddGenre(genre, genreId);
        }
        public Task<GenreModel> EditGenre(GenreModel editedGenre, int id)
        {
            return _genresRepository.EditGenre(editedGenre, id);
        }

        public Task<GenreModel> DeleteGenre(int id)
        {
            return _genresRepository.DeleteGenre(id);
        }
    }
}