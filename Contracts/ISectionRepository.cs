using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface ISectionRepository
    {
        IEnumerable<Section> GetAllSections(bool trackChanges);
        Section GetSection(int Id, bool trackChanges);
        IEnumerable<Section> GetByIds(IEnumerable<int> ids, bool trackChanges);
        void CreateSection(Section section);

        void DeleteSection(Section section);
    }
}
