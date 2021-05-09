using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Course
    {
        [Key]
        [Column("CourseID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseId { get; set;  }

        [Column("Type")]
        [MaxLength(30, ErrorMessage = "Max length for Type is 60 characters.")]
        [Required(ErrorMessage ="Course type is a required field.")]
        public string Type { get; set; }

        [Column("Description")]
        [MaxLength(150, ErrorMessage = "Max length for Description is 150 characters.")]
        [Required(ErrorMessage ="Course description is a required field")]
        public string Description { get; set; }

        public ICollection<Section> Sections { get; set; }

        [Column("DateCreated")]
        [Timestamp]
        public DateTime DateCreated { get; set; }
        [Column("DateUpdated")]
        [Timestamp]
        public DateTime DateUpdated { get; set; }
    }
}
