using Entities.Models;
using Repository.Extensions.Utility;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace Repository.Extensions
{
    public static class RepositorySubmissionExtension
    {
        public static IQueryable<Submission> Sort(this IQueryable<Submission> submissions, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return submissions.OrderBy(e => e.SubmissionName);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<User>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return submissions.OrderBy(e => e.SubmissionName);

            return submissions.OrderBy(orderQuery);
        }


        public static IQueryable<Submission> Search(this IQueryable<Submission> submissions, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return submissions;
            var lowerCaseTerm = searchTerm.Trim().ToLower();
            return submissions.Where(e => e.SubmissionName.ToLower().Contains(lowerCaseTerm));
        }

    }
}