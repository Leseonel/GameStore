using System;
using System.ComponentModel.DataAnnotations;

namespace GameStore.Models
{
    public class GenderModel
    {
        [Key]
        public Guid GenderId { get; set; }

        public string GenderName { get; set; }
    }
}
