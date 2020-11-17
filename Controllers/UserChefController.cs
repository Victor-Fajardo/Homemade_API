using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UserChefController : ControllerBase
    {
        private readonly IUserChefService _userChefService;
        private readonly IMapper _mapper;

        public UserChefController(IUserChefService userChefService, IMapper mapper)
        {
            _userChefService = userChefService;
            _mapper = mapper;
        }

        [SwaggerOperation(
             Summary = "List all users chefs",
             Description = "List of users chefs",
             OperationId = "ListAllUsersChefs",
             Tags = new[] { "Users Chefs" }
             )]
        [SwaggerResponse(200, "List of Users Chefs", typeof(IEnumerable<UserChefResource>))]
        [ProducesResponseType(typeof(IEnumerable<UserChefResource>), 200)]
        [HttpGet]
        public async Task<IEnumerable<UserChefResource>> GetAllAsync()
        {
            var userChefs = await _userChefService.ListAsync();
            var resource = _mapper
                .Map<IEnumerable<UserChef>, IEnumerable<UserChefResource>>(userChefs);
            return resource;
        }

        [SwaggerOperation(
            Summary = "List all by Chefs Email",
            Description = "List by Chefs Email",
            OperationId = "ListAllByChefsEmail",
            Tags = new[] { "Users Chefs" }
        )]
        [SwaggerResponse(200, "List of chefs users by email", typeof(UserChefResource))]
        [HttpGet("email")]
        public async Task<IActionResult> GetUserChefByEmail(string email)
        {
            var result = await _userChefService.GetByEmailAsync(email);

            if (!result.Succes)
                return BadRequest(result.Message);
            var resource = _mapper.Map<UserChef, UserChefResource>(result.Resource);
            return Ok(resource);
        }

        [SwaggerOperation(
            Summary = "List all by Chefs Name",
            Description = "List by Chefs name",
            OperationId = "ListAllByChefsName",
            Tags = new[] { "Users Chefs" }
        )]
        [SwaggerResponse(200, "List of chefs users by name", typeof(UserChefResource))]
        [HttpGet("name/{name}")]
        public async Task<IEnumerable<UserChefResource>> GetAllByName(string name)
        {
            var userChefs = await _userChefService.GetByNameAsync(name);
            var resource = _mapper
                .Map<IEnumerable<UserChef>, IEnumerable<UserChefResource>>(userChefs);
            return resource;
        }

        [SwaggerOperation(
            Summary = "List all by Chefs Lastname",
            Description = "List by Chefs Lastname",
            OperationId = "ListAllByChefsLastname",
            Tags = new[] { "Users Chefs" }
        )]
        [SwaggerResponse(200, "List of chefs users by lastname", typeof(UserChefResource))]
        [HttpGet("lastname/{lastname}")]
        public async Task<IEnumerable<UserChefResource>> GetAllByLastname(string lastname)
        {
            var userChefs = await _userChefService.GetByLastnameAsync(lastname);
            var resource = _mapper
                .Map<IEnumerable<UserChef>, IEnumerable<UserChefResource>>(userChefs);
            return resource;
        }

        [SwaggerOperation(
            Summary = "Save a User Chef",
            Description = "Save a User Chef",
            OperationId = "SaveUserChef",
            Tags = new[] { "Users Chefs" }
        )]
        [SwaggerResponse(200, "User chef was saved", typeof(UserChefResource))]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveUserChefResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var UserChef = _mapper.Map<SaveUserChefResource, UserChef>(resource);

            var result = await _userChefService.SaveAsync(UserChef);

            if (!result.Succes)
                return BadRequest(result.Message);
            var userChefResource = _mapper.Map<UserChef, UserChefResource>(result.Resource);
            return Ok(userChefResource);
        }
        [SwaggerOperation(
            Summary = "Update a User Chef",
            Description = "Update a User Chef",
            OperationId = "UpdateUserChef",
            Tags = new[] { "Users Chefs" }
        )]
        [SwaggerResponse(200, "User chef was updated", typeof(UserChefResource))]
        [HttpPut("id")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveUserChefResource resource)
        {
            var userChef = _mapper.Map<SaveUserChefResource, UserChef>(resource);
            var result = await _userChefService.UpdateAsync(id, userChef);
            if (!result.Succes)
                return BadRequest(result.Message);
            var userChefResource = _mapper.Map<UserChef, UserChefResource>(result.Resource);
            return Ok(userChefResource);
        }
        [SwaggerOperation(
            Summary = "Delete a User Chef",
            Description = "Delete a User Chef",
            OperationId = "DeleteUserChef",
            Tags = new[] { "Users Chefs" }
        )]
        [SwaggerResponse(200, "User chef was delete", typeof(UserChefResource))]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _userChefService.DeleteAsync(id);
            if (!result.Succes)
                return BadRequest(result.Message);
            var userChefResource = _mapper.Map<UserChef, UserChefResource>(result.Resource);
            return Ok(userChefResource);
        }

    }
}

