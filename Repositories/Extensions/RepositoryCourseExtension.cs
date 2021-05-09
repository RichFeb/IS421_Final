using Entities.Models;
using Repository.Extensions.Utility;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace Repository.Extensions
{
    public static class RepositoryCourseExtension
    {
        public static IQueryable<Course> Sort(this IQueryable<Course> courses, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return courses.OrderBy(e => e.CourseName);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<Course>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return courses.OrderBy(e => e.CourseName);

            return courses.OrderBy(orderQuery);
        }


        public static IQueryable<Course> Search(this IQueryable<Course> courses, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return courses;
            var lowerCaseTerm = searchTerm.Trim().ToLower();
            return courses.Where(e => e.CourseName.ToLower().Contains(lowerCaseTerm));
        }

    }
}