using ActionFilters;
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace SchoolAPI.Controllers
{
    [Route("api/users")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]

    public class UserController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public UserController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;

        }
        [HttpGet(Name = "getAllUsers")]
        public IActionResult GetUsers([FromQuery] UserParameters userParameters)
        {
            var usersFromDb = _repository.User.GetAllUsers(userParameters, trackChanges: false);
            Response.Headers.Add("X-Pagination",
                JsonConvert.SerializeObject(usersFromDb.MetaData));

            var userDto = _mapper.Map<IEnumerable<UserDto>>(usersFromDb);

            return Ok(userDto);

        }
        [HttpGet("{id}", Name = "getUserById")]
        [ServiceFilter(typeof(ValidateUserExistsAttribute))]
        public IActionResult GetUser(int id)
        {

            var user = HttpContext.Items["user"] as User;

            var userDto = _mapper.Map<UserDto>(user);
            return Ok(userDto);
        }

        [HttpPost(Name = "createUser")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public IActionResult CreateUser([FromBody] UserForCreationDto user)
        {

            var userEntity = _mapper.Map<User>(user);

            _repository.User.CreateUser(userEntity);
            _repository.Save();

            var userToReturn = _mapper.Map<UserDto>(userEntity);

            return CreatedAtRoute("getUserById", new { id = userToReturn.UserId }, userToReturn);
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ServiceFilter(typeof(ValidateUserExistsAttribute))]
        public IActionResult UpdateUser(int id, [FromBody] UserForUpdateDto user)
        {

            var userEntity = HttpContext.Items["user"] as User;

            _mapper.Map(user, userEntity);
            _repository.Save();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(ValidateUserExistsAttribute))]
        public IActionResult DeleteUser(int id)
        {
            var user = HttpContext.Items["user"] as User;

            _repository.User.DeleteUser(user);
            _repository.Save();

            return NoContent();
        }
    }
}
