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
        [ForeignKey("GenresModel")]
        public int GenreId { get; set; }
    }
}
