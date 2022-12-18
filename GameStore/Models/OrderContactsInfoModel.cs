using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.Models
{
    public class OrderContactsInfoModel
    {
        [Key]
        public Guid OrderContactsId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        [ForeignKey("PaymentTypeModel")]
        public Guid PaymentTypeId { get; set; }

        [ForeignKey("CartModel")]
        public Guid CartId { get; set; }

        [ForeignKey("UserModel")]
        public Guid UserId { get; set; }

        [MaxLength(600)]
        public string Comment { get; set; }
    }
}
