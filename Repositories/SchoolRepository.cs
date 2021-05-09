using Contracts;
using Entities;
using Entities.Models;
using System.Collections.Generic;
using System.Linq;

namespace Repositories
{
    public class SchoolRepository : RepositoryBase<School>, ISchoolRepository
    {
        public SchoolRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<School> GetAllSchools(bool trackChanges) =>
            FindAll(trackChanges)
            .OrderBy(c => c.SchoolName)
            .ToList();

        public School GetSchool(int Id, bool trackChanges) => FindByCondition(c => c.SchoolId.Equals(Id), trackChanges)
            .SingleOrDefault();

        public IEnumerable<School> GetByIds(IEnumerable<int> ids, bool trackChanges) =>
          FindByCondition(x => ids.Contains(x.SchoolId), trackChanges)
          .ToList();

        public void CreateSchool(School school) => Create(school);


        public void DeleteSchool(School school)
        {
            Delete(school);
        }

    }
}

