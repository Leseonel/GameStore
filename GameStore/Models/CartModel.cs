using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.Models
{
    public class CartModel
    {
        [Key]
        public Guid CartId { get; set; }

        [ForeignKey("UserModel")]
        public Guid UserId { get; set; }

        public double TotalPrice { get; set; }

        public bool IsFinished { get; set; }

        public ICollection<OrderModel> Orders { get; set; } = new List<OrderModel>();
    }
}
