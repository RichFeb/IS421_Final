using Contracts;
using Entities;
using Entities.Models;

namespace Repositories
{
    public class SectionRepository : RepositoryBase<Section>, ISectionRepository
    {
        public SectionRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}