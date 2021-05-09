using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{

    public class Assignment
    {
        [Key]
        [Column("AssignmentID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AssignmentId { get; set; }

        [Column("Name")]
        [MaxLength(60, ErrorMessage = "Max length for Name is 60 characters.")]
        [Required(ErrorMessage = "Name is a required field.")]

        public string Name { get; set; }

        [Column("Description")]
        [MaxLength(150, ErrorMessage = "Max length for Description is 150 characters.")]
        [Required(ErrorMessage = "Description is a required field.")]
        public string Description { get; set; }

        [Column("DateCreated")]
        public DateTime DateCreated { get; set; }

        [Column("DateUpdated")]
        public DateTime DateUpdated { get; set; }

        public ICollection<Submission> Submissions { get; set; }

    }
}
