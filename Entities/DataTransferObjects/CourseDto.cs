using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class CourseDto
    {        
        public int CourseId { get; set; }

        public int CourseName { get; set; }

        public string Description { get; set; }

        public DateTime DateCreated { get; set; }
        
        public DateTime DateUpdated { get; set; }
    }
}
