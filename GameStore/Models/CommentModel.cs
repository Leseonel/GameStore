using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.Models
{
    public class CommentModel
    {
        [Key]
        public int CommentId { get; set; }
        public string CommentText { get; set; }
        public DateTime CommentDate { get; set; }
        [ForeignKey("UserModel")]
        public int UserId { get; set; }
        [ForeignKey("GameModel")]
        public int GameId { get; set; }
    }
}