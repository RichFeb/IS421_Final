using System;

namespace Entities.DataTransferObjects
{
    public class SubmissionDto
    {
        public int SubmissionId { get; set; }
    
        public string SubmissionName { get; set; }

        public string Comments { get; set; }

        public int Grade { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

    }
}
