using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Section
    {
        [Key]
        [Column("SectionID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SectionId { get; set; }

        public string SectionName { get; set; }

        [Column("Capacity")]
        public int Capacity { get; set; }

        public ICollection<User> RegisteredUsers { get; set; }

        public ICollection<Assignment> Assignments { get; set; }

        [Column("DateCreated")]
        
        public DateTime DateCreated { get; set; }

        [Column("DateUpdated")]
        public DateTime DateUpdated { get; set; }

        


       
        
    }
}