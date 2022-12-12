using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.Models
{
    public class UserModel : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string Country { get; set; }

        public string ZipCode { get; set; }

        public DateTime RegistrationDate { get; set; }

        public string AvatarUrl { get; set; }

        [ForeignKey("GenderModel")]
        public Guid GenderId { get; set; }
    }
}