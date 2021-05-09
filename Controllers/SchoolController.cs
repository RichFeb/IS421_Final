using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Contracts;
using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using ActionFilters;
using Entities.RequestFeatures;
using Newtonsoft.Json;

namespace SchoolAPI.Controllers
{
    [Route("api/submissions")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]

    public class SchoolController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public SchoolController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;

        }
        [HttpGet(Name = "getAllSchools")]
        public IActionResult GetSschools([FromQuery] SchoolParameters schoolParameters)
        {
            var schoolsFromDb = _repository.School.GetAllSchools(schoolParameters, trackChanges: false);
            Response.Headers.Add("X-Pagination",
                JsonConvert.SerializeObject(schoolsFromDb.MetaData));

            var schoolDto = _mapper.Map<IEnumerable<SchoolDto>>(schoolsFromDb);

            return Ok(schoolDto);

        }
        [HttpGet("{id}", Name = "getSchoolById")]
        [ServiceFilter(typeof(ValidateSchoolExistsAttribute))]
        public IActionResult GetSchool(int id)
        {

            var school = HttpContext.Items["schools"] as School;

            var schoolDto = _mapper.Map<SchoolDto>(school);
            return Ok(schoolDto);


        }

        [HttpPost(Name = "createSchool")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public IActionResult CreateSchool([FromBody] SchoolForCreationDto school)
        {

            var schoolEntity = _mapper.Map<School>(school);

            _repository.School.CreateSchool(schoolEntity);
            _repository.Save();

            var schoolToReturn = _mapper.Map<SchoolDto>(schoolEntity);

            return CreatedAtRoute("getSchoolById", new { id = schoolToReturn.SchoolId }, schoolToReturn);
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ServiceFilter(typeof(ValidateSchoolExistsAttribute))]
        public IActionResult UpdateSchool(int id, [FromBody] SchoolForUpdateDto school)
        {

            var schoolEntity = HttpContext.Items["school"] as School;

            _mapper.Map(school, schoolEntity);
            _repository.Save();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(ValidateSchoolExistsAttribute))]
        public IActionResult DeleteSchool(int id)
        {
            var school = HttpContext.Items["school"] as School;

            _repository.School.DeleteSchool(school) ;
            _repository.Save();

            return NoContent();
        }
    }
}
