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
            var userCommon = await _userCommonService.ListAsync();
            var resource = _mapper
                .Map<IEnumerable<UserCommon>, IEnumerable<UserCommonResource>>(userCommon);
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

        [HttpPost]
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








        // GET: api/<UserCommonController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserCommonController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserCommonController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserCommonController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserCommonController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
