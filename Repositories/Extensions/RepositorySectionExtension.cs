using System.Linq.Dynamic.Core;
using System.Linq;
using Entities.Models;
using System;
using System.Reflection;
using System.Text;
using Repository.Extensions.Utility;

namespace Repository.Extensions
{
    public static class RepositorySectionExtension
    {
        public static IQueryable<Section> Sort(this IQueryable<Section> sections, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return sections.OrderBy(e => e.SectionName);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<Section>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return sections.OrderBy(e => e.SectionName);

            return sections.OrderBy(orderQuery);
        }


        public static IQueryable<Section> Search(this IQueryable<Section> sections, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return sections;
            var lowerCaseTerm = searchTerm.Trim().ToLower();
            return sections.Where(e => e.SectionName.ToLower().Contains(lowerCaseTerm));
        }

    }
}