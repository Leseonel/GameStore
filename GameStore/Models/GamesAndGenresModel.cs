using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.Models
{
    public class GamesAndGenresModel
    {
        [Key]
        public Guid GamesAndGenresId { get; set; }

        [ForeignKey("GameModel")]
        public Guid GameId { get; set; }

        public GameModel Game { get; set; }

        [ForeignKey("GenreModel")]
        public Guid GenreId { get; set; }

        public GenreModel Genre { get; set; }
    }
}
