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
        public IActionResult GetSections([FromQuery] SectionParameters sectionParameters)
        {
            var sectionsFromDb = _repository.Section.GetAllSections(sectionParameters, trackChanges: false);
            Response.Headers.Add("X-Pagination",
                JsonConvert.SerializeObject(sectionsFromDb.MetaData));

            var sectionDto = _mapper.Map<IEnumerable<SectionDto>>(sectionsFromDb);

            return Ok(sectionDto);

        }
        [HttpGet("{id}", Name = "getSectionById")]
        [ServiceFilter(typeof(ValidateSectionExistsAttribute))]
        public IActionResult GetSection(int id)
        {

            var section = HttpContext.Items["section"] as Section;

            var sectionDto = _mapper.Map<SectionDto>(section);
            return Ok(sectionDto);


        }

        [HttpPost(Name = "createSchool")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public IActionResult CreateSection([FromBody] SectionForCreationDto section)
        {

            var sectionEntity = _mapper.Map<Section>(section);

            _repository.Section.CreateSection(sectionEntity);
            _repository.Save();

            var sectionToReturn = _mapper.Map<SectionDto>(sectionEntity);

            return CreatedAtRoute("getSectionById", new { id = sectionToReturn.SectionId }, sectionToReturn);
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ServiceFilter(typeof(ValidateSectionExistsAttribute))]
        public IActionResult UpdateSection(int id, [FromBody] SectionForUpdateDto section)
        {

            var sectionEntity = HttpContext.Items["sections"] as Section;

            _mapper.Map(section, sectionEntity);
            _repository.Save();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(ValidateSectionExistsAttribute))]
        public IActionResult DeleteSection(int id)
        {
            var section = HttpContext.Items["school"] as Section;

            _repository.Section.DeleteSection(section);
            _repository.Save();

            return NoContent();
        }
    }
}
