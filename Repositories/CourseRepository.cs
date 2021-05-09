using Contracts;
using Entities;
using Entities.Models;
using Entities.RequestFeatures;
using Repository.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace Repositories
{
    public class CourseRepository : RepositoryBase<Course>, ICourseRepository
    {
        public CourseRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public PagedList<Course> GetAllCourses(CourseParameters courseParameters, bool trackChanges)
        {
            var courses = FindAll(trackChanges)
                .Search(courseParameters.SearchTerm)
                .Sort(courseParameters.OrderBy)
                .ToList();

            return PagedList<Course>
           .ToPagedList(courses, courseParameters.PageNumber, courseParameters.PageSize);

        }

        public Course GetCourse(int Id, bool trackChanges) => FindByCondition(c => c.CourseId.Equals(Id), trackChanges)
            .SingleOrDefault();

        public IEnumerable<Course> GetByIds(IEnumerable<int> ids, bool trackChanges) =>
          FindByCondition(x => ids.Contains(x.CourseId), trackChanges)
          .ToList();

        public void CreateCourse(Course course) => Create(course);

        public void DeleteCourse(Course course)
        {
            Delete(course);
        }

        
    }
}