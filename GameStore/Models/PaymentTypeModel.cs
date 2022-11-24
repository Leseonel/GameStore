using System.ComponentModel.DataAnnotations;

namespace GameStore.Models
{
    public class PaymentTypeModel
    {
        [Key]
        public int PaymentTypeId { get; set; }
        public string PaymentTypeName { get; set; }
    }
}