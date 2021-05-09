using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class User
    {
        [Column("UserID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int  UserId { get; set; }

        [Column("UserName")]

        [Required(ErrorMessage = "User name is a required field.")]

        [MinLength(6, ErrorMessage = "Minimum length for the Name is 6 characters. ")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]

        public string UserName { get; set; }

        [Column("Email")]

        [MinLength(6, ErrorMessage = "Minimum length for the Email is 6 characters. ")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Email is 30 characters.")]

        [Required(ErrorMessage = "Email is a required field.")]
       
        [EmailAddress]

        public string Email { get; set; }

        [Column("FirstName")]

        [MinLength(6, ErrorMessage = "Minimum length for FirstName is 6 characters. ")]
        [MaxLength(30, ErrorMessage = "Maximum length for FirstName is 30 characters.")]
        [Required(ErrorMessage = "First name is a required field.")]

        public string FirstName { get; set; }

        [Column("LastName")]

        [MinLength(6, ErrorMessage = "Minimum length for LastName is 6 characters. ")]
        [MaxLength(30, ErrorMessage = "Maximum length for LastName is 30 characters.")]

        [Required(ErrorMessage = "Last name is a required field.")]

        public string LastName { get; set; }

        [Column("PhoneNumber")]

        [Required(ErrorMessage = "Phone Number is a required field.")]

        [Phone]
        public string PhoneNumber { get; set; }

        [ForeignKey(nameof(Organization))]
        public int OrganizationId { get; set; }

        [Column("DateCreated")]

        public DateTime DateCreated { get; set; }

        [Column("DateUpdated")]
        public DateTime DateUpdated { get; set; }


        public Organization Organization { get; set; }
    }
}



      