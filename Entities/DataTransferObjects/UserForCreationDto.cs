using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects
{
    public class UserForCreationDto
    {

        [Required(ErrorMessage = "User name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the User name is 60 characters.")]
        [MinLength(5, ErrorMessage = "Minimum length for the User name is 5 characters.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is a required field.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "First name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the First name is 60 characters.")]
        [MinLength(5, ErrorMessage = "Minimum length for the First name is 5 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Last name is 60 characters.")]
        [MinLength(5, ErrorMessage = "Minimum length for the Last name is 5 characters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Phone number is a required field.")]
        [Phone]
        public string PhoneNumer { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }
    }
}
