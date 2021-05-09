using Entities.Models;
using Repository.Extensions.Utility;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace Repository.Extensions
{
    public static class RepositoryAssignmentExtension
    {
        public static IQueryable<Assignment> Sort(this IQueryable<Assignment> assignments, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return assignments.OrderBy(e => e.AssignmentName);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<Assignment>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return assignments.OrderBy(e => e.AssignmentName);

            return assignments.OrderBy(orderQuery);
        }


        public static IQueryable<Assignment> Search(this IQueryable<Assignment> assignments, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return assignments;
            var lowerCaseTerm = searchTerm.Trim().ToLower();
            return assignments.Where(e => e.AssignmentName.ToLower().Contains(lowerCaseTerm));
        }

    }
}