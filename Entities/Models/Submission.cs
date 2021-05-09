using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Submission
    {
        [Key]
        [Column("SubmissionID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubmissionId { get; set; }

        [Column("Name")]

        [MinLength(6, ErrorMessage = "Minimum length for Submission Name is 6 characters. ")]
        [MaxLength(30, ErrorMessage = "Maximum length for Submission Name is 30 characters.")]

        [Required(ErrorMessage = "Submission Name is a required field.")]
        public string Name { get; set; }

        [Column("Comments")]
        public string Comments { get; set; }

        [Column("Grade")]
        [Required(ErrorMessage = "Grade is a required field.")]
        public int Grade { get; set; }

        [Column("DateCreated")]
        public DateTime DateCreated { get; set; }

        [Column("DateUpdated")]
        public DateTime DateUpdated { get; set; }
    }
}
