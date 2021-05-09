using Contracts;
using Entities;
using Entities.Models;
using System.Collections.Generic;
using System.Linq;

namespace Repositories
{
    public class OrganizationRepository : RepositoryBase<Organization>, IOrganizationRepository
    {
        public OrganizationRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<Organization> GetAllOrganizations(bool trackChanges) =>
            FindAll(trackChanges)
            .OrderBy(c => c.OrgName)
            .ToList();

        public Organization GetOrganization(int Id, bool trackChanges) => FindByCondition(c => c.OrgId.Equals(Id), trackChanges)
            .SingleOrDefault();

        public IEnumerable<Organization> GetByIds(IEnumerable<int> ids, bool trackChanges) =>
          FindByCondition(x => ids.Contains(x.OrgId), trackChanges)
          .ToList();

        public void CreateOrganization(Organization organization) => Create(organization);

        public void DeleteOrganization(Organization organization)
        {
            Delete(organization);
        }

    }
}

