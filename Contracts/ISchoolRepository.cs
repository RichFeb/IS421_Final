using Entities.Models;
using System;
using System.Collections.Generic;



namespace Contracts
{
    public interface ISchoolRepository
    {
        IEnumerable<School> GetAllSchools(bool trackChanges);
        School GetSchools(int Id, bool trackChanges);
        IEnumerable<School> GetByIds(IEnumerable<int> ids, bool trackChanges);
        void DeleteSchool(School school);
    }
}
