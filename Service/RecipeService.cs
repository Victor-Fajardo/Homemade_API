using Homemade.Domain.Models;
using Homemade.Domain.Repositories;
using Homemade.Domain.Services;
using Homemade.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homemade.Service
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserChefRepository _userChefRepository;
        private readonly IMenuRecipeRepository _menuRecipeRepository;

        public RecipeService(IRecipeRepository recipeRepository, IUnitOfWork unitOfWork, IMenuRecipeRepository menuRecipeRepository, IUserChefRepository userChefRepository)
        {
            _recipeRepository = recipeRepository;
            _unitOfWork = unitOfWork;
            _userChefRepository = userChefRepository;
            _menuRecipeRepository = menuRecipeRepository;
        }

        public async Task<RecipeResponse> DeleteAsync(int id)
        {
            var existingRecipe = await _recipeRepository.FindById(id);
            if (existingRecipe == null)
                return new RecipeResponse("Recipe not found");
            try
            {
                _recipeRepository.Remove(existingRecipe);
                await _unitOfWork.CompleteAsync();
                return new RecipeResponse(existingRecipe);
            }
            catch (Exception ex)
            {
                return new RecipeResponse($"An error ocurred while deleting Recipe: {ex.Message}");
            }
        }

        public async Task<RecipeResponse> GetByIdAsync(int id)
        {
            var existingRecipe = await _recipeRepository.FindById(id);
            if (existingRecipe == null)
                return new RecipeResponse("Recipe not found");
            return new RecipeResponse(existingRecipe);
        }

        public async Task<IEnumerable<Recipe>> ListAsync()
        {
            return await _recipeRepository.ListAsync();
        }

        public async Task<IEnumerable<Recipe>> ListById(int id)
        {
            return await _recipeRepository.ListById(id);
        }

        public async Task<IEnumerable<Recipe>> ListByName(string name)
        {
            return await _recipeRepository.ListByName(name);
        }

        public async Task<IEnumerable<Recipe>> ListByIdUser(int id)
        {
            return await _recipeRepository.ListByIdUser(id);
        }

        public async Task<IEnumerable<Recipe>> ListByMenuId(int menuId)
        {
            var menuRecipes = await _menuRecipeRepository.ListByMenuIdAsync(menuId);
            var recipes = menuRecipes.Select(p => p.Recipe).ToList();
            return recipes;
        }

        public async Task<RecipeResponse> SaveAsync(Recipe recipe, int userChefId)
        {
            var existingUserChef = await _userChefRepository.FindById(userChefId);
            if (existingUserChef == null)
            {
                return new RecipeResponse("User not found");
            }
            recipe.Author = existingUserChef;
            try
            {
                await _recipeRepository.AddAsync(recipe);
                await _unitOfWork.CompleteAsync();
                return new RecipeResponse(recipe);
            }
            catch (Exception ex)
            {
                return new RecipeResponse($"An error ocurred while saving the Recipe: {ex.Message}");
            }
        }

        public async Task<RecipeResponse> UpdateAsync(int id, Recipe recipe)
        {
            var existingRecipe = await _recipeRepository.FindById(id);
            if (existingRecipe == null)
                return new RecipeResponse("Recipe not found");
            existingRecipe.NameRecipe = recipe.NameRecipe;
            existingRecipe.Instructions = recipe.Instructions;
            existingRecipe.Qualification = recipe.Qualification;
            existingRecipe.Date = recipe.Date;
            try
            {
                _recipeRepository.Update(existingRecipe);
                await _unitOfWork.CompleteAsync();
                return new RecipeResponse(existingRecipe);
            }
            catch (Exception ex)
            {
                return new RecipeResponse($"An error ocurred while updating the Recipe: {ex.Message}");
            }
        }
    }
}
