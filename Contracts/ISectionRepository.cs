using Entities.Models;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface ISectionRepository
    {
        PagedList<Section> GetAllSections(SectionParameters sectionParameters, bool trackChanges);
        Section GetSection(int Id, bool trackChanges);
        IEnumerable<Section> GetByIds(IEnumerable<int> ids, bool trackChanges);
        void CreateSection(Section section);

        void DeleteSection(Section section);
    }
}
