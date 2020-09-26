using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Homemade.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserChefController : ControllerBase
    {
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
