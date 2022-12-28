using AutoMapper;
using GameStore.CustomExceptions;
using GameStore.Data.Repositories.RepositoryInterfaces;
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
    public class GameCommentsRepository : IGameCommentsRepository
    {
        const int CommentMaxLength = 600;
        private readonly GameStoreContext _context;
        private readonly IMapper _mapper;
        public GameCommentsRepository(GameStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CommentModel>> GetAllGameAllComments()
        {
            List<CommentModel> comments = await _context.Comments.ToListAsync();

            return comments;
        }
        public async Task<IList<CommentModel>> GetAllCommentsForGame(Guid gameId)
        {
            return await _context.Comments.Where(x => x.GameId == gameId && !x.IsDeleted).ToListAsync();
        }
        public async Task<CommentViewModel> AddCommentToGame(CommentViewModel comment, Guid? parentCommentId)
        {
            var commentToSave = _mapper.Map<CommentModel>(comment);
            ValidateOnNull<CommentModel>.ValidateDataOnNull(commentToSave);
            ValidateOnNullAndEmpty<string>.ValidateDataOnNullAndEmpty(commentToSave.CommentText);

            if (commentToSave.CommentText.Length > CommentMaxLength)
            {
                throw new CouldNotAddException("Text is too long!. Comment can contain only 600 characters");
            }
            commentToSave.CommentDate = DateTime.UtcNow;

            if (parentCommentId == null)
            {
                await _context.Comments.AddAsync(commentToSave);
                await _context.SaveChangesAsync();
                return comment;
            }
            var parentComment = await _context.Comments.Where(x => x.CommentId == parentCommentId).Include(x => x.Children).SingleOrDefaultAsync();

            commentToSave.ParentId = parentComment.CommentId;
            commentToSave.Parent = parentComment;

            parentComment.Children ??= new List<CommentModel>();
            parentComment.Children.Add(commentToSave);

            await _context.SaveChangesAsync();
            var mapToReverse = _mapper.Map<CommentViewModel>(commentToSave);
            return mapToReverse;
        }
        public async Task<CommentModel> EditComment(CommentModel comment, Guid id)
        {
            if (comment.CommentText.Length > CommentMaxLength)
            {
                throw new CouldNotAddException("Text is too long! Comment can contain only 600 characters");
            }
            var commentToUpdate = await _context.Comments.Where(com => com.CommentId == id).FirstOrDefaultAsync();

            ValidateOnNull<CommentModel>.ValidateDataOnNull(commentToUpdate);
            commentToUpdate.CommentText = comment.CommentText;

            await _context.SaveChangesAsync();

            return commentToUpdate;
        }
        public async Task<CommentModel> RestoreComment(Guid commentId)
        {
            var commentToRestore = await _context.Comments.Where(x => x.CommentId == commentId && !x.IsDeleted).SingleOrDefaultAsync();

            ValidateOnNull<CommentModel>.ValidateDataOnNull(commentToRestore);

            commentToRestore.IsDeleted = false;
            _context.Update(commentToRestore);
            await _context.SaveChangesAsync();

            return commentToRestore;
        }
        public async Task<CommentModel> SoftDeleteCommentForUser(Guid id)
        {
            CommentModel comment = await _context.Comments.Where(x => x.CommentId == id).FirstOrDefaultAsync();

            ValidateOnNull<CommentModel>.ValidateDataOnNull(comment);

            comment.IsDeleted = true;
            _context.Comments.Update(comment);
            await _context.SaveChangesAsync();

            return comment;
        }
        public async Task<CommentModel> DeleteComment(Guid id)
        {
            CommentModel comment = await _context.Comments.Where(x => x.CommentId == id).FirstOrDefaultAsync();

            ValidateOnNull<CommentModel>.ValidateDataOnNull(comment);

            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();

            return comment;
        }
    }
}
