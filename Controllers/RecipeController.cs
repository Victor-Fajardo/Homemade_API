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
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeService _recipeService;
        private readonly IMapper _mapper;

        public RecipeController(IRecipeService recipeService, IMapper mapper)
        {
            _recipeService = recipeService;
            _mapper = mapper;
        }

        // GET: api/<RecipeController>
        [HttpGet]
        public async Task<IEnumerable<RecipeResource>> GetAllAsync()
        {
            var recipes = await _recipeService.ListAsync();
            var resource = _mapper.Map<IEnumerable<Recipe>,
                IEnumerable<RecipeResource>>(recipes);
            return resource;
        }

        // GET api/<RecipeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RecipeController>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveRecipeResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var recipe = _mapper.Map<SaveRecipeResource, Recipe>(resource);

            var result = await _recipeService.SaveAsync(recipe);

            if (!result.Succes)
                return BadRequest(result.Message);
            var recipeResource = _mapper.Map<Recipe, RecipeResource>(result.Resource);
            return Ok(recipeResource);
        }

        // PUT api/<RecipeController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveRecipeResource resource)
        {
            var recipe = _mapper.Map<SaveRecipeResource, Recipe>(resource);
            var result = await _recipeService.UpdateAsync(id, recipe);
            if (!result.Succes)
                return BadRequest(result.Message);
            var recipeResource = _mapper.Map<Recipe, RecipeResource>(result.Resource);
            return Ok(recipeResource);
        }

        // DELETE api/<RecipeController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _recipeService.DeleteAsync(id);
            if (!result.Succes)
                return BadRequest(result.Message);
            var recipeResource = _mapper.Map<Recipe, RecipeResource>(result.Resource);
            return Ok(recipeResource);
        }
    }
}
