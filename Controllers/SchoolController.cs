using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;


namespace SchoolAPI.Controllers
{
    [Route("api/schools")]
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

        public IActionResult GetSchools()
        {
            var schools = _repository.School.GetAllSchools(trackChanges: false);

            var schoolDto = _mapper.Map<IEnumerable<SchoolDto>>(schools);

            return Ok(schoolDto);

        }
        [HttpGet("{id}", Name = "getSchoolBy")]
        public IActionResult GetSchool(int id)
        {
            try

            {
                var school = _repository.School.GetSchool(id, trackChanges: false);
                if (school == null)
                {
                    _logger.LogError($"School with ID: {id} doesn't exist in the database");
                    return NotFound();
                }
                else
                {
                    var schoolDto = _mapper.Map<SchoolDto>(school);
                    return Ok(schoolDto);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetSchool)} action {ex}");
                return StatusCode(500, "Internal server error");
            }

        }

        [HttpPost(Name = "createSchool")]
        public IActionResult CreateSchool([FromBody] SchoolForCreationDto school)
        {
            if (school == null)
            {
                _logger.LogError("SchoolForCreationDto object sent from client is null.");
                return BadRequest("SchoolForCreationDto object is null");
            }
            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the SchoolForCreationDto object");
                return UnprocessableEntity(ModelState);
            }

            var schoolEntity = _mapper.Map<User>(school);

            _repository.User.CreateUser(schoolEntity);
            _repository.Save();

            var schoolToReturn = _mapper.Map<SchoolDto>(schoolEntity);

            return CreatedAtRoute("getSchoolById", new { id = schoolToReturn.SchoolId }, schoolToReturn);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSchool(int id, [FromBody] SchoolForUpdateDto school)
        {
            if (school == null)
            {
                _logger.LogError("SchoolForUpdateDto object sent from client is null.");
                return BadRequest("SchoolForUpdateDto object is null");
            }
            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the SchoolForUpdateDto object");
                return UnprocessableEntity(ModelState);
            }
            var schoolEntity = _repository.School.GetSchool(id, trackChanges: true);
            if (schoolEntity == null)
            {
                _logger.LogInfo($"School with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _mapper.Map(school, schoolEntity);
            _repository.Save();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSchool(int id)
        {
            var school = _repository.School.GetSchool(id, trackChanges: false);
            if (school == null)
            {
                _logger.LogInfo($"School with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _repository.School.DeleteSchool(school);
            _repository.Save();

            return NoContent();
        }
    }
}