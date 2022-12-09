using GameStore.CustomExceptions;
using GameStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Data.Repositories.GameCommentRepository
{
    public class GameCommentsRepository : IGameCommentsRepository
    {
        private readonly GameStoreContext _context;
        public GameCommentsRepository(GameStoreContext context)
        {
            _context = context;
        }

        public async Task<List<CommentModel>> GetAllGameAllComments()
        {
            List<CommentModel> comments = await _context.Comments.ToListAsync();
            if (comments.Count == 0)
            {
                throw new DoesNotExistsException("Comments Not Found");
            }
            return comments;
        }
        public async Task<IList<CommentModel>> GetAllCommentsForGame(int gameId)
        {
            return await _context.Comments.Where(x => x.GameId == gameId).ToListAsync();
        }
        public async Task<CommentModel> AddCommentToGame(CommentModel comment, Guid? parentCommentId)
        {
            if (comment == null || string.IsNullOrEmpty(comment.CommentText))
            {
                throw new ArgumentNullException(nameof(comment));
            }
            if (parentCommentId == null)
            {
                await _context.Comments.AddAsync(comment);
                await _context.SaveChangesAsync();
                return comment;
            }
            var parentComment = await _context.Comments.Where(x => x.CommentId == parentCommentId).Include(x => x.Children).SingleOrDefaultAsync();
            comment.ParentId = parentComment.CommentId;
            comment.Parent = parentComment;
            parentComment.Children ??= new List<CommentModel>();
            parentComment.Children.Add(comment);
            await _context.SaveChangesAsync();
            return comment;
        }
        public async Task<CommentModel> EditComment(CommentModel comment, Guid id)
        {
            var commentToUpdate = await _context.Comments.Where(com => com.CommentId == id).FirstOrDefaultAsync();
            if (commentToUpdate == null)
            {
                throw new DoesNotExistsException("Can not find a comment with that ID to edit");
            }
            commentToUpdate.CommentText = comment.CommentText;
            await _context.SaveChangesAsync();

            return commentToUpdate;
        }
        public async Task<CommentModel> RestoreComment(Guid commentId)
        {
            var commentToRestore = await _context.Comments.Where(x => x.CommentId == commentId && x.DeletedAt != null).SingleOrDefaultAsync();
            if (commentToRestore == null)
            {
                throw new DoesNotExistsException("No Comment To Restore");
            }
            commentToRestore.DeletedAt = null;
            _context.Update(commentToRestore);
            await _context.SaveChangesAsync();
            return commentToRestore;
        }
        public async Task<CommentModel> DeleteComment(Guid id)
        {
            CommentModel comment = await _context.Comments.Where(x => x.CommentId == id).FirstOrDefaultAsync();
            if (comment == null)
            {
                throw new DoesNotExistsException("Can not find a comment to delete");
            }
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
            return comment;
        }
    }
}
