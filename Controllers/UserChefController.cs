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

        [HttpPost]
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


        // GET: api/<UserChefController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserChefController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserChefController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserChefController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserChefController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
