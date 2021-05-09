using Entities.Models;
using Repository.Extensions.Utility;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace Repository.Extensions
{
    public static class RepositorySchoolExtension
    {
        public static IQueryable<School> Sort(this IQueryable<School> schools, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return schools.OrderBy(e => e.SchoolName);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<User>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return schools.OrderBy(e => e.SchoolName);

            return schools.OrderBy(orderQuery);
        }


        public static IQueryable<School> Search(this IQueryable<School> schools, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return schools;
            var lowerCaseTerm = searchTerm.Trim().ToLower();
            return schools.Where(e => e.SchoolName.ToLower().Contains(lowerCaseTerm));
        }

    }
}