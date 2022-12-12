using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.Models
{
    public class GamesAndGenresModel
    {
        [Key]
        public int GamesAndGenresId { get; set; }

        [ForeignKey("GameModel")]
        public int GameId { get; set; }

        public GameModel Game { get; set; }

        [ForeignKey("GameModel")]
        public int GenreId { get; set; }

        public GenreModel Genre { get; set; }
    }
}
