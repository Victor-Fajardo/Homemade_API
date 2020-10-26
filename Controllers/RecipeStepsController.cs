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
    public class RecipeStepsController : ControllerBase
    {
        private readonly IRecipeStepsService _recipeStepsService;
        private readonly IMapper _mapper;

        public RecipeStepsController(IRecipeStepsService recipeStepsService, IMapper mapper)
        {
            _recipeStepsService = recipeStepsService;
            _mapper = mapper;
        }
        [SwaggerOperation(
            Summary = "Create a RecipeStep",
            Description = "Create a RecipeStep",
            OperationId = "CreateRecipeStep",
            Tags = new[] { "RecipeSteps" }
        )]
        [SwaggerResponse(200, "RecipeStep was created", typeof(RecipeStepsResource))]
        [HttpPost("recipeId")]
        public async Task<IActionResult> PostAsync([FromBody] SaveRecipeStepsResource resource, int recipeId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var recipeStep = _mapper.Map<SaveRecipeStepsResource, RecipeStep>(resource);

            var result = await _recipeStepsService.SaveAsync(recipeStep, recipeId);

            if (!result.Succes)
                return BadRequest(result.Message);
            var recipeStepResource = _mapper.Map<RecipeStep, RecipeStepsResource>(result.Resource);
            return Ok(recipeStepResource);

        }

        [SwaggerOperation(
            Summary = "Update a RecipeStep",
            Description = "Update a RecipeStep",
            OperationId = "UpdateRecipeStep",
            Tags = new[] { "RecipeSteps" }
        )]
        [SwaggerResponse(200, "RecipeStep was updated", typeof(RecipeStepsResource))]
        [HttpPut("id")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveRecipeStepsResource resource)
        {
            var recipeStep = _mapper.Map<SaveRecipeStepsResource, RecipeStep>(resource);
            var result = await _recipeStepsService.UpdateAsync(id, recipeStep);

            if (!result.Succes)
                return BadRequest(result.Message);
            var recipeStepResource = _mapper.Map<RecipeStep, RecipeStepsResource>(result.Resource);
            return Ok(recipeStepResource);
        }

        [SwaggerOperation(
            Summary = "Delete a RecipeStep",
            Description = "Delete a RecipeStep",
            OperationId = "DeleteRecipeStep",
            Tags = new[] { "RecipeSteps" }
        )]
        [SwaggerResponse(200, "RecipeStep was delete", typeof(RecipeStepsResource))]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _recipeStepsService.Delete(id);
            if (!result.Succes)
                return BadRequest(result.Message);
            var recipeStepResource = _mapper.Map<RecipeStep, RecipeStepsResource>(result.Resource);
            return Ok(recipeStepResource);
        }

        [SwaggerOperation(
            Summary = "List all Comment by Publication Id",
            Description = "List of Comment for a Publication",
            OperationId = "ListAllCommentsByPublication",
            Tags = new[] { "RecipeSteps" }
        )]
        [SwaggerResponse(200, "List of RecipeSteps for a Recipe", typeof(IEnumerable<RecipeStepsResource>))]
        [HttpGet("recipeId")]
        public async Task<IEnumerable<RecipeStepsResource>> GetAllByPublicationIdAsync(int recipeId)
        {
            var recipeSteps = await _recipeStepsService.ListByRecipeIdAsync(recipeId);
            var resources = _mapper
                .Map<IEnumerable<RecipeStep>, IEnumerable<RecipeStepsResource>>(recipeSteps);
            return resources;
        }

    }
}
