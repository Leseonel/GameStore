using GameStore.Models;
using GameStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.Data.Repositories.RepositoryInterfaces
{
    public interface IGameCommentsRepository
    {
        Task<List<CommentModel>> GetAllGameAllComments();
        Task<IList<CommentModel>> GetAllCommentsForGame(Guid gameId);
        Task<CommentViewModel> AddCommentToGame(CommentViewModel comment, Guid? parentCommentId);
        Task<CommentModel> EditComment(CommentModel comment, Guid id);
        Task<CommentModel> RestoreComment(Guid commentId);
        Task<CommentModel> SoftDeleteCommentForUser(Guid id);
        Task<CommentModel> DeleteComment(Guid id);
    }
}
