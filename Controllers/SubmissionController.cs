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

    public class SubmissionController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public SubmissionController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;

        }
        [HttpGet(Name = "getAllSubmissions")]
        public IActionResult GetSubmissions([FromQuery] SubmissionParameters submissionParameters)
        {
            var usersFromDb = _repository.Submission.GetAllSubmissions(submissionParameters, trackChanges: false);
            Response.Headers.Add("X-Pagination",
                JsonConvert.SerializeObject(usersFromDb.MetaData));

            var userDto = _mapper.Map<IEnumerable<UserDto>>(usersFromDb);

            return Ok(userDto);

        }
        [HttpGet("{id}", Name = "getSubmissionById")]
        [ServiceFilter(typeof(ValidateSubmissionExistsAttribute))]
        public IActionResult GetSubmission(int id)
        {

            var submission = HttpContext.Items["submission"] as Submission;

            var submissionDto = _mapper.Map<SubmissionDto>(submission);
            return Ok(submissionDto);


        }

        [HttpPost(Name = "createSubmission")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public IActionResult CreateSubmission([FromBody] SubmissionForCreationDto submission)
        {

            var submissionEntity = _mapper.Map<Submission>(submission);

            _repository.Submission.CreateSubmission(submissionEntity);
            _repository.Save();

            var submissionToReturn = _mapper.Map<SubmissionDto>(submissionEntity);

            return CreatedAtRoute("getSubmissionById", new { id = submissionToReturn.SubmissionId }, submissionToReturn);
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ServiceFilter(typeof(ValidateSubmissionExistsAttribute))]
        public IActionResult UpdateSubmission(int id, [FromBody] SubmissionForUpdateDto submission)
        {

            var submissionEntity = HttpContext.Items["submission"] as Submission;

            _mapper.Map(submission, submissionEntity);
            _repository.Save();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(ValidateSubmissionExistsAttribute))]
        public IActionResult DeleteSubmission(int id)
        {
            var user = HttpContext.Items["user"] as User;

            _repository.User.DeleteUser(user);
            _repository.Save();

            return NoContent();
        }
    }
}
