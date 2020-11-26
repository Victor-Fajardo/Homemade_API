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

namespace Homemade.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class MenuRecipeController:ControllerBase
    {
        private readonly IMenuService _menuService;
        private readonly IRecipeService _recipeService;
        private readonly IMenuRecipeService _menuRecipeService;
        private readonly IMapper _mapper;

        public MenuRecipeController(IMenuService menuService, IRecipeService recipeService, IMenuRecipeService menuRecipeService, IMapper mapper)
        {
            _menuService = menuService;
            _recipeService = recipeService;
            _menuRecipeService = menuRecipeService;
            _mapper = mapper;
        }

        [SwaggerOperation(
            Summary = "List all Recipes by Menu Id",
            Description = "List of Recipes for a Menu Id",
            OperationId = "ListAllRecipeByMenuId",
            Tags = new[] { "Menus" }
        )]
        [SwaggerResponse(200, "List of Recipes for a Menu Id", typeof(IEnumerable<MenuResource>))]
        [HttpGet("{menuId}")]
        public async Task<IEnumerable<RecipeResource>> GetAllByMenuIdAsync(int menuId)
        {
            var recipes = await _recipeService.ListByMenuId(menuId);
            var resource = _mapper
                .Map<IEnumerable<Recipe>, IEnumerable<RecipeResource>>(recipes);
            return resource;
        }

        [SwaggerOperation(
            Summary = "Assign Recipe",
            Description = "Assign Recipe",
            OperationId = "AssignRecipe",
            Tags = new[] { "Menus" }
        )]
        [SwaggerResponse(200, "Menu was created", typeof(MenuRecipeResource))]
        [HttpPost("{menuId}/{recipeId}")]
        public async Task<IActionResult> AssignRecipe(SaveMenuRecipeResource resource, int menuId, int recipeId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var menuRecipes = _mapper.Map<SaveMenuRecipeResource, MenuRecipe>(resource);

            var result = await _menuRecipeService.SaveAsync(menuRecipes, menuId, recipeId);

            if (!result.Succes)
                return BadRequest(result.Message);
            var menuRecipesResource = _mapper.Map<MenuRecipe, MenuRecipeResource>(result.Resource);
            return Ok(menuRecipesResource);
        }

        [SwaggerOperation(
           Summary = "Update Recipes on a Menu",
           Description = "Update Recipes on a Menu",
           OperationId = "UpdateRecipesonMenu",
           Tags = new[] { "Menus" }
       )]
        [SwaggerResponse(200, "Recipes on a Menu updated", typeof(MenuRecipeResource))]
        [HttpPut("{menuId}/{recipeId}")]
        public async Task<IActionResult> PutAsync(int menuId, int recipeId, SaveMenuRecipeResource resource)
        {
            var menuRecipes = _mapper.Map<SaveMenuRecipeResource, MenuRecipe>(resource);
            var result = await _menuRecipeService.UpdateAsync(menuId, recipeId, menuRecipes);
            if (!result.Succes)
                return BadRequest(result.Message);
            var menuRecipesResource = _mapper.Map<MenuRecipe, MenuRecipeResource>(result.Resource);
            return Ok(menuRecipesResource);
        }

        [SwaggerOperation(
            Summary = "Delete a Recipe on a Menu",
            Description = "Delete a Recipe on a Menu",
            OperationId = "DeleteRecipeMenu",
            Tags = new[] { "Menus" }
        )]
        [SwaggerResponse(200, "Recipe on a Menu deleted", typeof(MenuRecipeResource))]
        [HttpDelete("{menuId}/{recipeId}")]
        public async Task<IActionResult> DeleteAsync(int menuId, int recipeId)
        {
            var result = await _menuRecipeService.DeleteAsync(menuId, recipeId);
            if (!result.Succes)
                return BadRequest(result.Message);
            var menuRecipesResource = _mapper.Map<MenuRecipe, MenuRecipeResource>(result.Resource);
            return Ok(menuRecipesResource);
        }
    }
}
