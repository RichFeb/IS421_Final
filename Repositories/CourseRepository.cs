using Contracts;
using Entities;
using Entities.Models;
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

        public IEnumerable<Course> GetAllCourses(bool trackChanges) =>
           FindAll(trackChanges)
           .OrderBy(c => c.CourseName)
           .ToList();

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