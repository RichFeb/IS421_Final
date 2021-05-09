using Entities.Models;
using Entities.RequestFeatures;
using System.Linq;


namespace Contracts
{
    public interface IOrganizationRepository
    {
        PagedList<Organization> GetAllOrganizations(OrganizationParameters organizationParameters, bool trackChanges);
        Organization GetOrganization(int OrgId, bool trackChanges);
        void CreateOrganization(Organization organization);

        void DeleteOrganization(Organization organization);
    }
}
