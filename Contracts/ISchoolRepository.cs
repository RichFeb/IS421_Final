using Entities.Models;
using Entities.RequestFeatures;
using System.Collections.Generic;



namespace Contracts
{
    public interface ISchoolRepository
    {
        PagedList<School> GetAllSchools(SchoolParameters schoolParaneters, bool trackChanges);
        School GetSchool(int SchoolId, bool trackChanges);
        IEnumerable<School> GetByIds(IEnumerable<int> ids, bool trackChanges);
        void CreateSchool(School school);

        void DeleteSchool(School school);
    }
}