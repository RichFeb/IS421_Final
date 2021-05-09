using ActionFilters;
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace SchoolAPI.Controllers
{
    [Route("api/courses")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    public class CourseController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public CourseController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetAllCourses")]
        public IActionResult GetCourses([FromQuery] CourseParameters courseParameters)
        {
            var coursesFromDb = _repository.Course.GetAllCourses(courseParameters, trackChanges: false);
            Response.Headers.Add("X-Pagination",
                JsonConvert.SerializeObject(coursesFromDb.MetaData));

            var courseDto = _mapper.Map<IEnumerable<CourseDto>>(coursesFromDb);
            
            return Ok(courseDto);
        }

        [HttpGet("{id}", Name = "GetCourseById")]
        [ServiceFilter(typeof(ValidateCourseExistsAttribute))]
        public IActionResult GetCourse(int id)
        {
            var course = HttpContext.Items["course"] as Course;

            var courseDto = _mapper.Map<CourseDto>(course);
            return Ok(courseDto);
        }

        [HttpPost(Name = "createCourse")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public IActionResult CreateCourse([FromBody] CourseForCreationDto course)
        {
            var courseEntity = _mapper.Map<Course>(course);

            _repository.Course.CreateCourse(courseEntity);
            _repository.Save();

            var courseToReturn = _mapper.Map<CourseDto>(courseEntity);

            return CreatedAtRoute("getCourseById", new { id = courseToReturn.CourseId }, courseToReturn);
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ServiceFilter(typeof(ValidateCourseExistsAttribute))]
        public IActionResult UpdateCourse(int id, [FromBody] CourseForUpdateDto course)
        {
            var courseEntity = HttpContext.Items["course"] as Course;

            _mapper.Map(course, courseEntity);
            _repository.Save();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCourse(int id)
        {
            var course = HttpContext.Items["course"] as Course;

            _repository.Course.DeleteCourse(course);
            _repository.Save();

            return NoContent();
        }
    }
}