using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;


namespace SchoolAPI.Controllers
{
    [Route("api/sections")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]

    public class SectionController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public SectionController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;

        }
        [HttpGet(Name = "getAllSections")]

        public IActionResult GetSections()
        {
            var sections = _repository.Section.GetAllSections(trackChanges: false);

            var sectionDto = _mapper.Map<IEnumerable<SubmissionDto>>(sections);

            return Ok(sectionDto);

        }
        [HttpGet("{id}", Name = "getSectionById")]
        public IActionResult GetSection(int id)
        {
            try

            {
                var section = _repository.Section.GetSection(id, trackChanges: false);
                if (section == null)
                {
                    _logger.LogError($"Section with ID: {id} doesn't exist in the database");
                    return NotFound();
                }
                else
                {
                    var sectionDto = _mapper.Map<SectionDto>(section);
                    return Ok(sectionDto);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetSection)} action {ex}");
                return StatusCode(500, "Internal server error");
            }

        }

        [HttpPost(Name = "createSection")]
        public IActionResult CreateSection([FromBody] SectionForCreationDto section)
        {
            if (section == null)
            {
                _logger.LogError("SectionForCreationDto object sent from client is null.");
                return BadRequest("SectionForCreationDto object is null");
            }
            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the SectionForCreationDto object");
                return UnprocessableEntity(ModelState);
            }

            var sectionEntity = _mapper.Map<Section>(section);

            _repository.Section.CreateSection(sectionEntity);
            _repository.Save();

            var sectionToReturn = _mapper.Map<SectionDto>(sectionEntity);

            return CreatedAtRoute("getSectionById", new { id = sectionToReturn.SectionId }, sectionToReturn);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSection(int id, [FromBody] SectionForUpdateDto section)
        {
            if (section == null)
            {
                _logger.LogError("SectionForUpdateDto object sent from client is null.");
                return BadRequest("SectionForUpdateDto object is null");
            }
            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the SectionForUpdateDto object");
                return UnprocessableEntity(ModelState);
            }
            var sectionEntity = _repository.Section.GetSection(id, trackChanges: true);
            if (sectionEntity == null)
            {
                _logger.LogInfo($"Section with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _mapper.Map(section, sectionEntity);
            _repository.Save();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSection(int id)
        {
            var section = _repository.Section.GetSection(id, trackChanges: false);
            if (section == null)
            {
                _logger.LogInfo($"Section with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _repository.Section.DeleteSection(section);
            _repository.Save();

            return NoContent();
        }
    }
}