using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects
{
    public class SubmissionForCreationDto
    {
        [Required(ErrorMessage = "Submission name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
        [MinLength(5, ErrorMessage = "Minimum length for the Name is 5 characters.")]
        public string SubmissionName { get; set; }

        [Required(ErrorMessage = "Submission comments is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Comments is 60 characters.")]
        [MinLength(5, ErrorMessage = "Minimum length for the Comments is 5 characters.")]
        public string Comments { get; set; }

        public int Grade { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

    }
}
