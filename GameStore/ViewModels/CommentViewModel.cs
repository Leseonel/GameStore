using GameStore.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace GameStore.ViewModels
{
    public class CommentViewModel
    {
        public Guid CommentId { get; set; }
        [MaxLength(600)]
        [Required]
        public string CommentText { get; set; }

        public DateTime CommentDate { get; set; }

        public DateTime CommentDateLeft { get; set; }

        public bool IsDeleted { get; set; } = false;

        public Guid UserId { get; set; }

        public Guid GameId { get; set; }

        public Guid? ParentId { get; set; }

        public ICollection<CommentModel> Children { get; set; } = new List<CommentModel>();
    }
}
