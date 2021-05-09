using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;


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

        public IActionResult GetSubmissions()
        {
            var submissions = _repository.Submission.GetAllSubmissions(trackChanges: false);

            var submissionDto = _mapper.Map<IEnumerable<SubmissionDto>>(submissions);

            return Ok(submissionDto);

        }
        [HttpGet("{id}", Name = "getSubmissionById")]
        public IActionResult GetSubmission(int id)
        {
            try

            {
                var submission = _repository.Submission.GetSubmission(id, trackChanges: false);
                if (submission == null)
                {
                    _logger.LogError($"Submission with ID: {id} doesn't exist in the database");
                    return NotFound();
                }
                else
                {
                    var submissionDto = _mapper.Map<SubmissionDto>(submission);
                    return Ok(submissionDto);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetSubmission)} action {ex}");
                return StatusCode(500, "Internal server error");
            }

        }

        [HttpPost(Name = "createSubmission")]
        public IActionResult CreateSubmission([FromBody] SubmissionForCreationDto submission)
        {
            if (submission == null)
            {
                _logger.LogError("SubmissionForCreationDto object sent from client is null.");
                return BadRequest("SubmissionForCreationDto object is null");
            }
            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the UserForCreationDto object");
                return UnprocessableEntity(ModelState);
            }

            var submissionEntity = _mapper.Map<Submission>(submission);

            _repository.Submission.CreateSubmission(submissionEntity);
            _repository.Save();

            var submissionToReturn = _mapper.Map<SubmissionDto>(submissionEntity);

            return CreatedAtRoute("getSubmissionById", new { id = submissionToReturn.SubmissionId }, submissionToReturn);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSubmission(int id, [FromBody] SubmissionForUpdateDto submission)
        {
            if (submission == null)
            {
                _logger.LogError("SubmissionForUpdateDto object sent from client is null.");
                return BadRequest("SubmissionForUpdateDto object is null");
            }
            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the SubmissionForUpdateDto object");
                return UnprocessableEntity(ModelState);
            }
            var submissionEntity = _repository.Submission.GetSubmission(id, trackChanges: true);
            if (submissionEntity == null)
            {
                _logger.LogInfo($"Submission with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _mapper.Map(submission, submissionEntity);
            _repository.Save();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSubmission(int id)
        {
            var submission = _repository.Submission.GetSubmission(id, trackChanges: false);
            if (submission == null)
            {
                _logger.LogInfo($"Submission with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _repository.Submission.DeleteSubmission(submission);
            _repository.Save();

            return NoContent();
        }
    }
}