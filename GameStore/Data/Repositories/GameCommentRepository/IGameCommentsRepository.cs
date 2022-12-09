using GameStore.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.Data.Repositories.GameCommentRepository
{
    public interface IGameCommentsRepository
    {
        Task<List<CommentModel>> GetAllGameAllComments();
        Task<IList<CommentModel>> GetAllCommentsForGame(int gameId);
        Task<CommentModel> AddCommentToGame(CommentModel comment, Guid? parentCommentId);
        Task<CommentModel> EditComment(CommentModel comment, Guid id);
        Task<CommentModel> RestoreComment(Guid commentId);
        Task<CommentModel> DeleteComment(Guid id);
    }
}
