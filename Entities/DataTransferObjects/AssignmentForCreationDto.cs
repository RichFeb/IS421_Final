using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects
{
    public class AssignmentForCreationDto
    {
        [Required(ErrorMessage = "Assignment name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
        [MinLength(5, ErrorMessage = "Minimum length for the Name is 5 characters.")]

        public string AssignmentName { get; set; }

        [Required(ErrorMessage = "Assignment description is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Description is 60 characters.")]
        [MinLength(5, ErrorMessage = "Minimum length for the Description is 5 characters.")]

        public string Description { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }


    }
}
