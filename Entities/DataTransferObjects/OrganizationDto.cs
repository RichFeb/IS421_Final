using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class OrganizationDto
    {
        public int OrgId { get; set; }
        public string OrgName { get; set; }

        public string OrgType { get; set; }

        public string FullAddress { get; set; }
        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }
    }
}
