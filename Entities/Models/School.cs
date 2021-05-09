using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class School
    {
        [Key]
        [Column("SchoolID")]

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SchoolId { get; set; }

        [Column("Name")]
        [Required(ErrorMessage = "Department name is a required field.")]
        [MinLength(15, ErrorMessage = "Minimum length for the Organization Name is 60 characters.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the School Name is 60 characters.")]
        public string SchoolName { get; set; }

        public ICollection<Course> Courses { get; set; }

        [Column("DateCreated")]
        
        public DateTime DateCreated { get; set; }

        [Column("DateUpdated")]
        
        public DateTime DateUpdated { get; set; }
    }
}