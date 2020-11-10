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
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;
        private readonly IMapper _mapper;

        public MenuController(IMenuService menuService, IMapper mapper)
        {
            _menuService = menuService;
            _mapper = mapper;
        }

        // GET: api/<MenuController>
        [SwaggerOperation(
             Summary = "List all menus",
             Description = "List of menus",
             OperationId = "ListAllMenus",
             Tags = new[] { "Menus" }
             )]
        [SwaggerResponse(200, "List of Menus", typeof(IEnumerable<MenuResource>))]
        [ProducesResponseType(typeof(IEnumerable<MenuResource>), 200)]
        [HttpGet]
        public async Task<IEnumerable<MenuResource>> GetAllAsync()
        {
            var menus = await _menuService.ListAsync();
            var resource = _mapper
                .Map<IEnumerable<Menu>, IEnumerable<MenuResource>>(menus);
            return resource;
        }

        // GET api/<MenuController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MenuController>
        [SwaggerOperation(
            Summary = "Create a Menu",
            Description = "Create a Menu",
            OperationId = "CreateMenu",
            Tags = new[] { "Menus" }
        )]
        [SwaggerResponse(200, "Menu was created", typeof(MenuResource))]
        [HttpPost("userId")]
        public async Task<IActionResult> PostAsync([FromBody] SaveMenuResource resource, int userId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var menu = _mapper.Map<SaveMenuResource, Menu>(resource);

            var result = await _menuService.SaveAsync(menu, userId);

            if (!result.Succes)
                return BadRequest(result.Message);

            var menuResource = _mapper.Map<Menu, MenuResource>(result.Resource);

            return Ok(menuResource);
        }

        // PUT api/<MenuController>/5
        [SwaggerOperation(
            Summary = "Update a Menu",
            Description = "Update a Menu",
            OperationId = "UpdateMenu",
            Tags = new[] { "Menus" }
        )]
        [SwaggerResponse(200, "Menu was updated", typeof(MenuResource))]
        [HttpPut("id")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveMenuResource resource)
        {
            var menu = _mapper.Map<SaveMenuResource, Menu>(resource);
            var result = await _menuService.UpdateAsync(id, menu);

            if (!result.Succes)
                return BadRequest(result.Message);
            var menuResource = _mapper.Map<Menu, MenuResource>(result.Resource);
            return Ok(menuResource);
        }

        // DELETE api/<MenuController>/5
        [SwaggerOperation(
            Summary = "Delete a Menu",
            Description = "Delete a Menu",
            OperationId = "DeleteMenu",
            Tags = new[] { "Menus" }
        )]
        [SwaggerResponse(200, "Menu was delete", typeof(MenuResource))]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _menuService.DeleteAsync(id);
            if (!result.Succes)
                return BadRequest(result.Message);
            var menuResource = _mapper.Map<Menu, MenuResource>(result.Resource);
            return Ok(menuResource);
        }
    }
}
