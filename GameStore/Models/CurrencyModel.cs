using System;
using System.ComponentModel.DataAnnotations;

namespace GameStore.Models
{
    public class CurrencyModel
    {
        [Key]
        public Guid CurrencyId { get; set; }

        public string CurrencyName { get; set; }
    }
}