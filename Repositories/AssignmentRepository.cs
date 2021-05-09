using Contracts;
using Entities;
using Entities.Models;
using Entities.RequestFeatures;
using Repository.Extensions;
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

        public PagedList<Assignment> GetAllAssignments(AssignmentParameters assignmentParameters, bool trackChanges)
        {
            var assignments = FindAll(trackChanges)
                .Search(assignmentParameters.SearchTerm)
                .Sort(assignmentParameters.OrderBy)
                .ToList();

            return PagedList<Assignment>
            .ToPagedList(assignments, assignmentParameters.PageNumber, assignmentParameters.PageSize);


        }

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