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


        [HttpGet]
        public async Task<IEnumerable<UserCommonResource>> GetAllAsync() 
        {
            var userCommons = await _userCommonService.ListAsync();
            var resource = _mapper
                .Map<IEnumerable<UserCommon>, IEnumerable<UserCommonResource>>(userCommons);
            return resource;
        }


        [HttpGet("{name}")]
        public async Task<IEnumerable<UserCommonResource>> GetAllByName(string name)
        {
            var userCommons = await _userCommonService.GetByNameAsync(name);
            var resource = _mapper
                .Map<IEnumerable<UserCommon>, IEnumerable<UserCommonResource>>(userCommons);
            return resource;
        }

        [HttpGet("{lastname}")]
        public async Task<IEnumerable<UserCommonResource>> GetAllByLastname(string lastname)
        {
            var userCommons = await _userCommonService.GetByLastnameAsync(lastname);
            var resource = _mapper
                .Map<IEnumerable<UserCommon>, IEnumerable<UserCommonResource>>(userCommons);
            return resource;
        }



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

        [HttpGet("{id}")]
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
