using System;
using System.ComponentModel.DataAnnotations;

namespace GameStore.Models
{
    public class PaymentTypeModel
    {
        [Key]
        public Guid PaymentTypeId { get; set; }

        public string PaymentTypeName { get; set; }
    }
}