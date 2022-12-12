using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.Models
{
    public class OrderModel
    {
        [Key]
        public int OrderId { get; set; }

        public string OrderComment { get; set; }

        [ForeignKey("OrderedGamesModel")]
        public int OrderedGamesId { get; set; }

        [ForeignKey("UserModel")]
        public string UserId { get; set; }

        [ForeignKey("GameModel")]
        public int GameId { get; set; }

        [ForeignKey("PaymentTypeModel")]
        public int PaymentTypeId { get; set; }

        [ForeignKey("CurrencyModel")]
        public int CurrencyId { get; set; }
    }
}