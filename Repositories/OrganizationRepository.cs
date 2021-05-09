﻿using Contracts;
using Entities;
using Entities.Models;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using Repository.Extensions;
using Repositories;

namespace Repository
{
    public class OrganizationRepository : RepositoryBase<Organization>, IOrganizationRepository
    {
        public OrganizationRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }
        public PagedList<Organization> GetAllOrganizations(OrganizationParameters orgParameters, bool trackChanges)
        {
            var organization = FindAll(trackChanges)
                .Sort(orgParameters.OrderBy)
                .FilterCity(orgParameters.CityFilter)
                .Search(orgParameters.SearchTerm)
                .ToList();

            return PagedList<Organization>
            .ToPagedList(organization, orgParameters.PageNumber, orgParameters.PageSize);

        }


        public Organization GetOrganization(int orgId, bool trackChanges) =>
            FindByCondition(c => c.OrgId.Equals(orgId), trackChanges).SingleOrDefault();
        public void CreateOrganization(Organization organization) => Create(organization);

        public IEnumerable<Organization> GetByIds(IEnumerable<int> ids, bool trackChanges) =>
            FindByCondition(x => ids.Contains(x.OrgId), trackChanges)
            .ToList();

        public void DeleteOrganization(Organization organization)
        {
            Delete(organization);
        }


    }
}