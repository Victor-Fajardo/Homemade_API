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

        [HttpGet]
        public async Task<IEnumerable<UserChefResource>> GetAllAsync() 
        {
            var userChefs = await _userChefService.ListAsync();
            var resource = _mapper
                .Map<IEnumerable<UserChef>, IEnumerable < UserChefResource >> (userChefs);
            return resource;
        }


        [HttpGet("{name}")]
        public async Task<IEnumerable<UserChefResource>> GetAllByName(string name)
        {
            var userChefs = await _userChefService.GetByNameAsync(name);
            var resource = _mapper
                .Map<IEnumerable<UserChef>, IEnumerable<UserChefResource>>(userChefs);
            return resource;
        }

        [HttpGet("{lastname}")]
        public async Task<IEnumerable<UserChefResource>> GetAllByLastname(string lastname)
        {
            var userChefs = await _userChefService.GetByLastnameAsync(lastname);
            var resource = _mapper
                .Map<IEnumerable<UserChef>, IEnumerable<UserChefResource>>(userChefs);
            return resource;
        }


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
            return Ok(userChefResource );
        }

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

        [HttpGet("{id}")]
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
