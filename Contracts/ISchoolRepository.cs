using Entities.Models;
using System;
using System.Collections.Generic;



namespace Contracts
{
    public interface ISchoolRepository
    {
        IEnumerable<School> GetAllSchools(bool trackChanges);
        School GetSchool(int Id, bool trackChanges);
        IEnumerable<School> GetByIds(IEnumerable<int> ids, bool trackChanges);
        void CreateSchool(School school);

        void DeleteSchool(School school);
    }
}