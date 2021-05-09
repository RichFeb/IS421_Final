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
    [Route("api/assignments")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    public class AssignmentController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public AssignmentController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet(Name = "getAllAssignments")]
        public IActionResult GetAssignments([FromQuery] AssignmentParameters assignmentParameters)
        {
            var assignmentsFromDb = _repository.Assignment.GetAllAssignments(assignmentParameters, trackChanges: false);
            Response.Headers.Add("X-Pagination",
                JsonConvert.SerializeObject(assignmentsFromDb.MetaData));

            var assignmentDto = _mapper.Map<IEnumerable<AssignmentDto>>(assignmentsFromDb);

            return Ok(assignmentDto);
        }

        [HttpGet("{id}", Name = "getAssignmentById")]
        [ServiceFilter(typeof(ValidateAssignmentExistsAttribute))]
        public IActionResult GetAssignment(int id)
        {
            var assignment = HttpContext.Items["assignments"] as Assignment;

            var assignmentDto = _mapper.Map<AssignmentDto>(assignment);
            return Ok(assignmentDto);
        }

        [HttpPost(Name = "createAssignment")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public IActionResult CreateAssignment([FromBody] AssignmentForCreationDto assignment)
        {
            var assignmentEntity = _mapper.Map<Assignment>(assignment);

            _repository.Assignment.CreateAssignment(assignmentEntity);
            _repository.Save();

            var assignmentToReturn = _mapper.Map<AssignmentDto>(assignmentEntity);

            return CreatedAtRoute("getAssignmentById", new { id = assignmentToReturn.AssignmentId }, assignmentToReturn);
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ServiceFilter(typeof(ValidateUserExistsAttribute))]
        public IActionResult UpdateAssignment(int id, [FromBody] AssignmentForUpdateDto assignment)
        {
            var assignmentEntity = HttpContext.Items["assignment"] as Assignment;

            _mapper.Map(assignment, assignmentEntity);
            _repository.Save();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(ValidateAssignmentExistsAttribute))]
        public IActionResult DeleteAssignment(int id)
        {
            var assignment = HttpContext.Items["assignment"] as Assignment;

            _repository.Assignment.DeleteAssignment(assignment);
            _repository.Save();

            return NoContent();
        }
    } 
}
