using Contracts;
using Entities;
using Entities.Models;
using System.Collections.Generic;
using System.Linq;

namespace Repositories
{
    public class AssignmentRepository : RepositoryBase<Assignment>, IAssignmentRepository
    {
        public AssignmentRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<Assignment> GetAllAssignments(bool trackChanges) =>
           FindAll(trackChanges)
           .OrderBy(c => c.AssignmentName)
           .ToList();

        public Assignment GetAssignment(int Id, bool trackChanges) => FindByCondition(c => c.AssignmentId.Equals(Id), trackChanges)
            .SingleOrDefault();

        public IEnumerable<Assignment> GetByIds(IEnumerable<int> ids, bool trackChanges) =>
          FindByCondition(x => ids.Contains(x.AssignmentId), trackChanges)
          .ToList();

        public void CreateAssignment(Assignment assignment) => Create(assignment);

        public void DeleteAssignment(Assignment assignment)
        {
            Delete(assignment);
        }

    }
}