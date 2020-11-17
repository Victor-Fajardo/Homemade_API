using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Homemade.Domain.Models;
using Homemade.Domain.Services;
using Homemade.Extensions;
using Homemade.Resource;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Homemade.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class UserCommonController : ControllerBase
    {
        private readonly IUserCommonService _userCommonService;
        private readonly IMapper _mapper;

        public UserCommonController(IUserCommonService userCommonService, IMapper mapper)
        {
            _userCommonService = userCommonService;
            _mapper = mapper;
        }

        [SwaggerOperation(
             Summary = "List all users common",
             Description = "List of users common",
             OperationId = "ListAllUsersCommon",
             Tags = new[] { "Users Common" }
             )]
        [SwaggerResponse(200, "List of Users Common", typeof(IEnumerable<UserCommonResource>))]
        [ProducesResponseType(typeof(IEnumerable<UserCommonResource>), 200)]
        [HttpGet]
        public async Task<IEnumerable<UserCommonResource>> GetAllAsync()
        {
            var userCommons = await _userCommonService.ListAsync();
            var resource = _mapper
                .Map<IEnumerable<UserCommon>, IEnumerable<UserCommonResource>>(userCommons);
            return resource;
        }

        [SwaggerOperation(
            Summary = "List all by Users Common Name",
            Description = "List by Users Common Name",
            OperationId = "ListAllByUsersCommonName",
            Tags = new[] { "Users Common" }
        )]
        [SwaggerResponse(200, "List of users common by name", typeof(UserCommonResource))]
        [ProducesResponseType(typeof(IEnumerable<UserCommonResource>), 200)]
        [HttpGet("name/{name}")]
        public async Task<IEnumerable<UserCommonResource>> GetAllByName(string name)
        {
            var userCommons = await _userCommonService.GetByNameAsync(name);
            var resource = _mapper
                .Map<IEnumerable<UserCommon>, IEnumerable<UserCommonResource>>(userCommons);
            return resource;
        }

        [SwaggerOperation(
            Summary = "List all by Commons Email",
            Description = "List by Commons Email",
            OperationId = "ListAllByCommonsEmail",
            Tags = new[] { "Users Common" }
        )]
        [SwaggerResponse(200, "List of chefs users by email", typeof(UserChefResource))]
        [HttpGet("email")]
        public async Task<IActionResult> GetUserCommonByEmail(string email)
        {
            var result = await _userCommonService.GetByEmailAsync(email);

            if (!result.Succes)
                return BadRequest(result.Message);
            var resource = _mapper.Map<UserCommon, UserCommonResource>(result.Resource);
            return Ok(resource);
        }

        [SwaggerOperation(
            Summary = "List all by Users Common Lastname",
            Description = "List by Users Common Lastname",
            OperationId = "ListAllByUsersCommonLastname",
            Tags = new[] { "Users Common" }
        )]
        [SwaggerResponse(200, "List of users common by lastname", typeof(UserCommonResource))]
        [ProducesResponseType(typeof(IEnumerable<UserCommonResource>), 200)]
        [HttpGet("lastname/{lastname}")]
        public async Task<IEnumerable<UserCommonResource>> GetAllByLastname(string lastname)
        {
            var userCommons = await _userCommonService.GetByLastnameAsync(lastname);
            var resource = _mapper
                .Map<IEnumerable<UserCommon>, IEnumerable<UserCommonResource>>(userCommons);
            return resource;
        }


        [SwaggerOperation(
            Summary = "Create a User Common",
            Description = "Create a User Common",
            OperationId = "CreateUserCommon",
            Tags = new[] { "Users Common" }
        )]
        [SwaggerResponse(200, "User common was created", typeof(UserCommonResource))]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveUserCommonResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var userCommon = _mapper.Map<SaveUserCommonResource, UserCommon>(resource);

            var result = await _userCommonService.SaveAsync(userCommon);

            if (!result.Succes)
                return BadRequest(result.Message);
            var userCommonResource = _mapper.Map<UserCommon, UserCommonResource>(result.Resource);
            return Ok(userCommonResource);
        }
        [SwaggerOperation(
           Summary = "Update a User Common",
           Description = "Update a User Common",
           OperationId = "UpdateUserCommon",
           Tags = new[] { "Users Common" }
       )]
        [SwaggerResponse(200, "User common was updated", typeof(UserCommonResource))]
        [HttpPut("id")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveUserCommonResource resource)
        {
            var userCommon = _mapper.Map<SaveUserCommonResource, UserCommon>(resource);
            var result = await _userCommonService.UpdateAsync(id, userCommon);
            if (!result.Succes)
                return BadRequest(result.Message);
            var userCommonResource = _mapper.Map<UserCommon, UserCommonResource>(result.Resource);
            return Ok(userCommonResource);
        }

        [SwaggerOperation(
            Summary = "Delete a User Common",
            Description = "Delete a User Common",
            OperationId = "DeleteUserCommon",
            Tags = new[] { "Users Common" }
        )]
        [SwaggerResponse(200, "User Common was delete", typeof(UserCommonResource))]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _userCommonService.DeleteAsync(id);
            if (!result.Succes)
                return BadRequest(result.Message);
            var userCommonResource = _mapper.Map<UserCommon, UserCommonResource>(result.Resource);
            return Ok(userCommonResource);
        }


    }
}