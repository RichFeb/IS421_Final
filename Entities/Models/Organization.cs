using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Organization
    {
        [Key]
        [Column("OrganizationID")]

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrgId { get; set; }

        [Column("Name")]
        [Required(ErrorMessage = "Organization name is a required field.")]
        [MinLength(10, ErrorMessage = "Minimum length for the Organization Name is 10 characters.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Organization Name is 60 characters.")]
        public string OrgName { get; set; }

        [Column("OrgType")]

        [Required(ErrorMessage = "Organization type is a required field.")]

        [MaxLength(20, ErrorMessage = "Maximum Length for the Organization Type is 60 characters.")]

        public string OrgType { get; set; }
        [Column("City")]
        public string City { get; set; }

        [Column("Country")]
        public string Country { get; set; }

        public ICollection<School> Schools { get; set; }

        [Column("DateCreated")]
        
        public DateTime DateCreated { get; set; }

        [Column("DateUpdated")] 
       
        public DateTime DateUpdated { get; set; }
    }
}