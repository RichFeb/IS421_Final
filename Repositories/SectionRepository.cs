using Contracts;
using Entities;
using Entities.Models;
using Entities.RequestFeatures;
using Repository.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace Repositories
{
    public class SectionRepository : RepositoryBase<Section>, ISectionRepository
    {
        public SectionRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public PagedList<Section> GetAllSections(SectionParameters sectionParameters, bool trackChanges)
        {
            var user = FindAll(trackChanges)
                .Search(sectionParameters.SearchTerm)
                .Sort(sectionParameters.OrderBy)
                .ToList();

            return PagedList<Section>
            .ToPagedList(user, sectionParameters.PageNumber, sectionParameters.PageSize);

        }


        public Section GetSection(int Id, bool trackChanges) => FindByCondition(c => c.SectionId.Equals(Id), trackChanges)
            .SingleOrDefault();

        public IEnumerable<Section> GetByIds(IEnumerable<int> ids, bool trackChanges) =>
          FindByCondition(x => ids.Contains(x.SectionId), trackChanges)
          .ToList();

        public void CreateSection(Section section) => Create(section);


        public void DeleteSection(Section section)
        {
            Delete(section);
        }

    }
}