using System.ComponentModel.DataAnnotations;
using System;
namespace GameStore.Models
{
    public class GameModel
    {
        [Key]
        public int GameId { get; set; }
        [Required]
        public string GameName { get; set; }
        public string GameDeveloper { get; set; }
        public string GamePublisher { get; set; }
        public double GamePrice { get; set; }
        [Required]
        public string GameDescription { get; set; }
        public string GameImgUrl { get; set; }
        public DateTime GameReleaseDate { get; set; }
    }
}