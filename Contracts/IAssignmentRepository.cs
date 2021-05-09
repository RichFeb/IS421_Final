using Entities.Models;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IAssignmentRepository
    {

        PagedList<Assignment> GetAllAssignments(AssignmentParameters assignmentParameters, bool trackChanges);
        Assignment GetAssignment(int Id, bool trackChanges);
        IEnumerable<Assignment> GetByIds(IEnumerable<int> ids, bool trackChanges);
        void CreateAssignment(Assignment assignment);

        void DeleteAssignment(Assignment assignment);

    }
}
