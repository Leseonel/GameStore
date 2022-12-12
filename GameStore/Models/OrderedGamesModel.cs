using System.ComponentModel.DataAnnotations;

namespace GameStore.Models
{
    public class OrderedGamesModel
    {
        [Key]
        public int OrderedGamesId { get; set; }

        public double TotalPrice { get; set; }
    }
}