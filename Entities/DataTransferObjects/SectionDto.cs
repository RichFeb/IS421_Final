using System;

namespace Entities.DataTransferObjects
{
    public class SectionDto
    {
      
        public int SectionId { get; set; }
        public int Capacity { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
