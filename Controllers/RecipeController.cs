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
    [Route("/api/[controller]")]
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
        [SwaggerOperation(
             Summary = "List all recipes by name",
             Description = "List of recipes by name",
             OperationId = "ListAllRecipesbyname",
             Tags = new[] { "Recipes" }
             )]
        [SwaggerResponse(200, "List of Recipes by name", typeof(IEnumerable<RecipeResource>))]
        [ProducesResponseType(typeof(IEnumerable<RecipeResource>), 200)]
        [HttpGet("name")]
        public async Task<IEnumerable<RecipeResource>> GetAllByNameAsync(string name)
        {
            var recipes = await _recipeService.ListByName(name);
            var resource = _mapper.Map<IEnumerable<Recipe>,
                IEnumerable<RecipeResource>>(recipes);
            return resource;
        }

        // GET: api/<RecipeController>
        [SwaggerOperation(
             Summary = "List all recipes by id user",
             Description = "List of recipes by id user",
             OperationId = "ListAllRecipesByIdUser",
             Tags = new[] { "Recipes" }
             )]
        [SwaggerResponse(200, "List of Recipes by Id user", typeof(IEnumerable<RecipeResource>))]
        [ProducesResponseType(typeof(IEnumerable<RecipeResource>), 200)]
        [HttpGet("id")]
        public async Task<IEnumerable<RecipeResource>> GetAllByIdUserAsync(int id)
        {
            var recipes = await _recipeService.ListByIdUser(id);
            var resource = _mapper.Map<IEnumerable<Recipe>,
                IEnumerable<RecipeResource>>(recipes);
            return resource;
        }

        [SwaggerOperation(
             Summary = "List all recipes by Id",
             Description = "List of recipes by Id",
             OperationId = "ListAllRecipesbyId",
             Tags = new[] { "Recipes" }
             )]
        [SwaggerResponse(200, "List of Recipes by Id", typeof(IEnumerable<RecipeResource>))]
        [ProducesResponseType(typeof(IEnumerable<RecipeResource>), 200)]
        [HttpGet("{id}")]
        public async Task<IEnumerable<RecipeResource>> GetAllByIdAsync(int id)
        {
            var recipes = await _recipeService.ListById(id);
            var resource = _mapper.Map<IEnumerable<Recipe>,
                IEnumerable<RecipeResource>>(recipes);
            return resource;
        }

        // GET: api/<RecipeController>
        [SwaggerOperation(
             Summary = "List all recipes",
             Description = "List of recipes",
             OperationId = "ListAllRecipes",
             Tags = new[] { "Recipes" }
             )]
        [SwaggerResponse(200, "List of Recipes", typeof(IEnumerable<RecipeResource>))]
        [ProducesResponseType(typeof(IEnumerable<RecipeResource>), 200)]
        [HttpGet]
        public async Task<IEnumerable<RecipeResource>> GetAllAsync()
        {
            var recipes = await _recipeService.ListAsync();
            var resource = _mapper.Map<IEnumerable<Recipe>,
                IEnumerable<RecipeResource>>(recipes);
            return resource;
        }

        // POST api/<RecipeController>
        [SwaggerOperation(
            Summary = "Save a Recipe",
            Description = "Save a Recipe",
            OperationId = "SaveRecipe",
            Tags = new[] { "Recipes" }
        )]
        [SwaggerResponse(200, "Recipe was saved", typeof(RecipeResource))]
        [HttpPost("userChefId")]
        public async Task<IActionResult> PostAsync([FromBody] SaveRecipeResource resource, int userChefId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var recipe = _mapper.Map<SaveRecipeResource, Recipe>(resource);

            var result = await _recipeService.SaveAsync(recipe, userChefId);

            if (!result.Succes)
                return BadRequest(result.Message);
            var recipeResource = _mapper.Map<Recipe, RecipeResource>(result.Resource);
            return Ok(recipeResource);
        }

        // PUT api/<RecipeController>/5
        [SwaggerOperation(
            Summary = "Update a Recipe",
            Description = "Update a Recipe",
            OperationId = "UpdateRecipe",
            Tags = new[] { "Recipes" }
        )]
        [SwaggerResponse(200, "Recipe was updated", typeof(RecipeResource))]
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
        [SwaggerOperation(
            Summary = "Delete a Recipe",
            Description = "Delete a Recipe",
            OperationId = "DeleteRecipe",
            Tags = new[] { "Recipes" }
        )]
        [SwaggerResponse(200, "Recipe was delete", typeof(RecipeResource))]
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
