using Entities.Models;
using System;
using System.Collections.Generic;



namespace Contracts
{
    public interface IOrganizationRepository
    {
        IEnumerable<Organization> GetAllOrganizations(bool trackChanges);
        Organization GetOrganization(int Id, bool trackChanges);
        IEnumerable<Organization> GetByIds(IEnumerable<int> ids, bool trackChanges);
        void CreateOrganization(Organization organization);

        void DeleteOrganization(Organization organization);
    }
}
