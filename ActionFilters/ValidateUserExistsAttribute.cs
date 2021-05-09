using Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Threading.Tasks;

namespace ActionFilters
{
    public class ValidateUserExistsAttribute
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public ValidateUserExistsAttribute(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var trackChanges = context.HttpContext.Request.Method.Equals("PUT");
            //for when implementing patch requests
            //(method.Equals("PUT") || method.Equals("PATCH")) ? true : false

            var id = (int)context.ActionArguments["id"];
            var user = _repository.User.GetUser(id, trackChanges);
            if (user == null)
            {
                _logger.LogInfo($"User with id: {id} doesn't exist in the database.");
                context.Result = new NotFoundResult();
            }
            else
            {
                context.HttpContext.Items.Add("user", user);
                await next();
            }
        }
    }
}