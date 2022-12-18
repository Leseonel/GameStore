using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace GameStore.Models
{
    public class GameModel
    {
        [Key]
        public Guid GameId { get; set; }
        [Required]
        public string GameName { get; set; }

        public string GameDeveloper { get; set; }

        public string GamePublisher { get; set; }

        public double GamePrice { get; set; }
        [Required]
        public string GameDescription { get; set; }

        public string GameImgUrl { get; set; }

        public DateTime GameReleaseDate { get; set; }

        public IList<GamesAndGenresModel> GameAndGenre { get; set; } = new List<GamesAndGenresModel>();

        public IList<CommentModel> GameAndComments { get; set; } = new List<CommentModel>();
    }
}