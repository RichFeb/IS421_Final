using Contracts;
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
    public class SchoolRepository : RepositoryBase<School>, ISchoolRepository
    {
        public SchoolRepository(RepositoryContext repositoryContext)
             : base(repositoryContext)
        {

        }
        public PagedList<School> GetAllSchools(SchoolParameters schoolParameters, bool trackChanges)
        {
            var school = FindAll(trackChanges)
                .Search(schoolParameters.SearchTerm)
                .Sort(schoolParameters.OrderBy)
                .ToList();

            return PagedList<School>
            .ToPagedList(school, schoolParameters.PageNumber, schoolParameters.PageSize);

        }



        public School GetSchool(int schoolId, bool trackChanges) =>
            FindByCondition(c => c.SchoolId.Equals(schoolId), trackChanges).SingleOrDefault();
        public void CreateSchool(School school) => Create(school);

        public IEnumerable<School> GetByIds(IEnumerable<int> ids, bool trackChanges) =>
            FindByCondition(x => ids.Contains(x.SchoolId), trackChanges)
            .ToList();

        public void DeleteSchool(School school)
        {
            Delete(school);
        }

       
    }
}