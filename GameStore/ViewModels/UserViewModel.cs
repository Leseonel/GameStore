using System.ComponentModel.DataAnnotations;
using System;

namespace GameStore.ViewModels
{
    public class UserViewModel
    {
        public Guid UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string AvatarUrl { get; set; }
        public Guid RoleId { get; set; }
        public Guid GenderId { get; set; }


    }
}
