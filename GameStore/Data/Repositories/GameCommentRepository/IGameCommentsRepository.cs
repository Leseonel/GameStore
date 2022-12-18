using GameStore.Models;
using GameStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.Data.Repositories.GameCommentRepository
{
    public interface IGameCommentsRepository
    {
        Task<List<CommentModel>> GetAllGameAllComments();
        Task<IList<CommentModel>> GetAllCommentsForGame(Guid gameId);
        Task<CommentViewModel> AddCommentToGame(CommentViewModel comment, Guid? parentCommentId);
        Task<CommentModel> EditComment(CommentModel comment, Guid id);
        Task<CommentModel> RestoreComment(Guid commentId);
        Task<CommentModel> DeleteComment(Guid id);
        Task<CommentModel> DeleteCommentForUser(Guid id);
    }
}
