using Contracts;
using Entities;
using Entities.Models;

namespace Repositories
{
    public class SubmissionRepository : RepositoryBase<Submission>, ISubmissionRepository
    {
        public SubmissionRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}