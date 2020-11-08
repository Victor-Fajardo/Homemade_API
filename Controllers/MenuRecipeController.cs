using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Homemade.Domain.Models;
using Homemade.Domain.Services;
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
            Summary = "List all Menu by Recipe Id",
            Description = "List of Menu for a Recipe Id",
            OperationId = "ListAllMenuByRecipeId",
            Tags = new[] { "Menus" }
        )]
        [SwaggerResponse(200, "List of Menu for a Recipe Id", typeof(IEnumerable<MenuResource>))]
        [HttpGet]
        public async Task<IEnumerable<RecipeResource>> GetAllByRecipeIdAsync(int recipeId)
        {
            var menus = await _menuService.ListByRecipeId(recipeId);
            var resource = _mapper
                .Map<IEnumerable<Menu>, IEnumerable<RecipeResource>>(menus);
            return resource;
        }

        [SwaggerOperation(
            Summary = "Assign Recipe",
            Description = "Assign Recipe",
            OperationId = "AssignRecipe",
            Tags = new[] { "Menus" }
        )]
        [SwaggerResponse(200, "Menu was created", typeof(MenuResource))]
        [HttpPost("{menuId}/{recipeId}")]
        public async Task<IActionResult> AssignRecipe(int menuId, int recipeId)
        {
            var result = await _menuRecipeService.AssingMenuRecipeAsync(menuId, recipeId);
            if (!result.Succes)
                return BadRequest(result.Message);
            Recipe recipe = _recipeService.GetByIdAsync(recipeId).Result.Resource;
            var resource = _mapper.Map<Recipe, RecipeResource>(recipe);
            return Ok(resource);
        }
    }
}
