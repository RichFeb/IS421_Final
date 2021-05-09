using Entities.Models;
using Entities.RequestFeatures;
using System.Collections.Generic;

namespace Contracts
{
    public interface ICourseRepository
    {
        PagedList<Course> GetAllCourses(CourseParameters courseParameters, bool trackChanges);
        Course GetCourse(int Id, bool trackChanges);
        IEnumerable<Course> GetByIds(IEnumerable<int> ids, bool trackChanges);
        void CreateCourse(Course course);

        void DeleteCourse(Course course);
    }
}
