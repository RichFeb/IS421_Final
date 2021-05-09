using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.RequestFeatures
{

    public class AssignmentParameters : RequestParameters
    {
        public AssignmentParameters()
        {
            OrderBy = "Name";
        }

        public string SearchTerm { get; set; }

    }
}
