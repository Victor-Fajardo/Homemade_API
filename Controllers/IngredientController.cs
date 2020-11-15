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
    public class IngredientController : ControllerBase
    {
        private readonly IIngredientService _ingredientService;
        private readonly IMapper _mapper;

        public IngredientController(IIngredientService ingredientService, IMapper mapper)
        {
            _ingredientService = ingredientService;
            _mapper = mapper;
        }

        // GET: api/<IngredientController>
        [SwaggerOperation(
             Summary = "List all Ingredients",
             Description = "List of ingredients",
             OperationId = "ListAllIngredients",
             Tags = new[] { "Ingredients" }
             )]
        [SwaggerResponse(200, "List of Ingredients", typeof(IEnumerable<IngredientResource>))]
        [ProducesResponseType(typeof(IEnumerable<IngredientResource>), 200)]
        [HttpGet]
        public async Task<IEnumerable<IngredientResource>> GetAllAsync()
        {
            var ingredients = await _ingredientService.ListAsync();
            var resource = _mapper.Map<IEnumerable<Ingredient>,
                IEnumerable<IngredientResource>>(ingredients);
            return resource;
        }

        // GET api/<IngredientController>/5
        [SwaggerOperation(
            Summary = "List all Ingredient by Recipe Id",
            Description = "List of Ingredients for a Recipe",
            OperationId = "ListAllIngredientsByRecipe",
            Tags = new[] { "Ingredients" }
        )]
        [SwaggerResponse(200,"List Ingredients for a Recipe",typeof(IEnumerable<IngredientResource>))]
        [HttpGet("recipeId")]
        public async Task<IEnumerable<IngredientResource>> GetAllByRecipeIdAsync(int recipeId)
        {
            var ingredient = await _ingredientService.ListByRecipeIdAsync(recipeId);
            var resources = _mapper
                .Map<IEnumerable<Ingredient>, IEnumerable<IngredientResource>>(ingredient);
            return resources;
        }

        // POST api/<IngredientController>
        [SwaggerOperation(
            Summary = "Create a Ingredient",
            Description = "Create a Ingredient",
            OperationId = "CreateIngredient",
            Tags = new[] { "Ingredients" }
        )]
        [SwaggerResponse(200, "Ingredient was created", typeof(IngredientResource))]
        [HttpPost("{recipeId}")]
        public async Task<IActionResult> PostAsync([FromBody] SaveIngredientResource resource, int recipeId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var ingredient = _mapper.Map<SaveIngredientResource, Ingredient>(resource);

            var result = await _ingredientService.SaveAsync(ingredient, recipeId);

            if (!result.Succes)
                return BadRequest(result.Message);
            var ingredientResource = _mapper.Map<Ingredient, IngredientResource>(result.Resource);
            return Ok(ingredientResource);
        }

        // PUT api/<IngredientController>/5
        [SwaggerOperation(
           Summary = "Update a Ingredient",
           Description = "Update a Ingredient",
           OperationId = "UpdateIngredient",
           Tags = new[] { "Ingredients" }
       )]
        [SwaggerResponse(200, "Ingredient was updated", typeof(IngredientResource))]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveIngredientResource resource)
        {
            var ingredient = _mapper.Map<SaveIngredientResource, Ingredient>(resource);
            var result = await _ingredientService.UpdateAsync(id, ingredient);
            if (!result.Succes)
                return BadRequest(result.Message);
            var ingredientResource = _mapper.Map<Ingredient, IngredientResource>(result.Resource);
            return Ok(ingredientResource);
        }

        // DELETE api/<IngredientController>/5
        [SwaggerOperation(
            Summary = "Delete a Ingredient",
            Description = "Delete a Ingredient",
            OperationId = "DeleteIngredient",
            Tags = new[] { "Ingredients" }
        )]
        [SwaggerResponse(200, "Ingredient was delete", typeof(IngredientResource))]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _ingredientService.DeleteAsync(id);
            if (!result.Succes)
                return BadRequest(result.Message);
            var ingredientResource = _mapper.Map<Ingredient, IngredientResource>(result.Resource);
            return Ok(ingredientResource);
        }
    }
}
