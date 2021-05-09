using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects
{
    public class CourseForUpdateDto
    {
        [Required(ErrorMessage = "Course name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
        [MinLength(5, ErrorMessage = "Minimum length for the Name is 5 characters.")]

        public int CourseName { get; set; }

        [Required(ErrorMessage = "Course description is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the description is 60 characters.")]
        [MinLength(5, ErrorMessage = "Minimum length for the description is 5 characters.")]

        public string Description { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }
    }
}

