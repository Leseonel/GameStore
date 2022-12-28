using GameStore.Data.Repositories.RepositoryInterfaces;
using GameStore.Data.UnitOfWork;
using GameStore.Models;
using GameStore.Services.ServiceInterfaces;
using GameStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.Services
{
    public class GameCommentService : IGameCommentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGameCommentsRepository _gameCommentsRepository;

        public GameCommentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _gameCommentsRepository = _unitOfWork.Comments;
        }

        public Task<List<CommentModel>> GetAllGameAllComments()
        {
            return _gameCommentsRepository.GetAllGameAllComments();
        }

        public Task<IList<CommentModel>> GetAllCommentsForGame(Guid gameId)
        {
            return _gameCommentsRepository.GetAllCommentsForGame(gameId);
        }

        public Task<CommentViewModel> AddCommentToGame(CommentViewModel comment, Guid? parentCommentId)
        {
            return _gameCommentsRepository.AddCommentToGame(comment, parentCommentId);
        }

        public Task<CommentModel> EditComment(CommentModel comment, Guid id)
        {
            return _gameCommentsRepository.EditComment(comment, id);
        }

        public Task<CommentModel> RestoreComment(Guid commentId)
        {
            return _gameCommentsRepository.RestoreComment(commentId);
        }

        public Task<CommentModel> SoftDeleteCommentForUser(Guid id)
        {
            return _gameCommentsRepository.SoftDeleteCommentForUser(id);
        }

        public Task<CommentModel> DeleteComment(Guid id)
        {
            return _gameCommentsRepository.DeleteComment(id);
        }
    }
}
