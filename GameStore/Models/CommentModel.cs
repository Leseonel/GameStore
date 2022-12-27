using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.Models
{
    public class CommentModel
    {
        [Key]
        public Guid CommentId { get; set; }

        [MaxLength(600)]
        [Required]
        public string CommentText { get; set; }

        public DateTime CommentDate { get; set; }

        public DateTime? DeletedAt { get; set; } = null;

        [ForeignKey("UserModel")]
        public Guid UserId { get; set; }

        [ForeignKey("GameModel")]
        public Guid GameId { get; set; }

        public Guid? ParentId { get; set; }

        public CommentModel Parent { get; set; }

        public ICollection<CommentModel> Children { get; set; } = new List<CommentModel>();
    }
}