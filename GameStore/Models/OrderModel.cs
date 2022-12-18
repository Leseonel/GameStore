using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.Models
{
    public class OrderModel
    {
        [Key]
        public Guid OrderId { get; set; }

        [ForeignKey("UserModel")]
        public Guid UserId { get; set; }

        [ForeignKey("GameModel")]
        public Guid GameId { get; set; }

        [Range(0, int.MaxValue)]
        public int AmountOfGames { get; set; }

        public double Price { get; set; }

        public double TotalPrice { get; set; }

        [ForeignKey("CurrencyModel")]
        public Guid CurrencyId { get; set; }

        [ForeignKey("CartModel")]
        public Guid? CartId { get; set; }
    }
}