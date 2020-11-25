using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Homemade.Domain.Models;
using Homemade.Domain.Services;
using Homemade.Domain.Services.Communications;
using Homemade.Resource;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Homemade.Controllers
{
    [Authorize]
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [SwaggerOperation(
            Summary = "List all by Users Email",
            Description = "List by Users Email",
            OperationId = "ListAllByUsersEmail",
            Tags = new[] { "Users" }
        )]
        [SwaggerResponse(200, "List of users by email", typeof(UserResource))]
        [HttpGet("email")]
        public async Task<IActionResult> GetUserChefByEmail(string email)
        {
            var result = await _userService.GetByEmailAsync(email);

            if (!result.Succes)
                return BadRequest(result.Message);
            var resource = _mapper.Map<User, UserResource>(result.Resource);
            return Ok(resource);
        }

        [AllowAnonymous]
        [SwaggerOperation(
            Summary = "Autheticate",
            Description = "Authenticate",
            OperationId = "Autheticate",
            Tags = new[] { "Users" }
        )]
        [SwaggerResponse(200, "Authenticate", typeof(UserResource))]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticationRequest request)
        {
            var response = _userService.Authenticate(request);

            if (response == null)
                return BadRequest(new { message = "Invalid Username or Password" });

            return Ok(response);
        }
    }
}
