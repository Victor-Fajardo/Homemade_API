using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Homemade.Domain.Models;
using Homemade.Domain.Repositories;
using Homemade.Domain.Services;
using Homemade.Domain.Services.Communications;

namespace Homemade.Service
{
    public class MenuRecipeService : IMenuRecipeService
    {
        private readonly IMenuRecipeRepository _menuRecipeRepository;
        private readonly IMenuRepository _menuRepository;
        private readonly IRecipeRepository _recipeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public MenuRecipeService(IMenuRecipeRepository menuRecipeRepository, IMenuRepository menuRepository, IRecipeRepository recipeRepository, IUnitOfWork unitOfWork)
        {
            _menuRecipeRepository = menuRecipeRepository;
            _menuRepository = menuRepository;
            _recipeRepository = recipeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<MenuRecipeResponse> DeleteAsync(int menuId, int recipeId)
        {
            var existingMenuRecipe = await _menuRecipeRepository.FindByMenuIdAndRecipeId(menuId, recipeId);
            if (existingMenuRecipe == null)
                return new MenuRecipeResponse("Menu Recipe not found");
            try
            {
                _menuRecipeRepository.Remove(existingMenuRecipe);
                await _unitOfWork.CompleteAsync();
                return new MenuRecipeResponse(existingMenuRecipe);
            }
            catch (Exception ex)
            {
                return new MenuRecipeResponse($"An error ocurred while deleting Menu Recipe: {ex.Message}");
            }
        }
        public async Task<MenuRecipeResponse> AssingMenuRecipeAsync(int menuId, int recipeId)
        {
            try
            {
                await _menuRecipeRepository.AssignMenuRecipe(menuId, recipeId);
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception ex)
            {
                return new MenuRecipeResponse($"An error ocurred while assigning Menu and Recipe: {ex.Message}");
            }
            return new MenuRecipeResponse(await _menuRecipeRepository.FindByMenuIdAndRecipeId(menuId, recipeId));
        }

        public async Task<IEnumerable<MenuRecipe>> ListAsync()
        {
            return await _menuRecipeRepository.ListAsync();
        }

        public async Task<IEnumerable<MenuRecipe>> ListByMenuIdAsync(int menuId)
        {
            return await _menuRecipeRepository.ListByMenuIdAsync(menuId);
        }

        public async Task<IEnumerable<MenuRecipe>> ListByRecipeIdAsync(int recipeId)
        {
            return await _menuRecipeRepository.ListByRecipeIdAsync(recipeId);
        }

        public async Task<MenuRecipeResponse> UnassingMenuRecipeAsync(int menuId, int recipeId)
        {
            try
            {
                MenuRecipe menuRecipe = await _menuRecipeRepository.FindByMenuIdAndRecipeId(menuId, recipeId);
                _menuRecipeRepository.Remove(menuRecipe);
                await _unitOfWork.CompleteAsync();
                return new MenuRecipeResponse(menuRecipe);
            }
            catch (Exception ex)
            {
                return new MenuRecipeResponse($"An error ocurred while assigning Recipe to Menu: {ex.Message}");
            }
        }

        public async Task<MenuRecipeResponse> SaveAsync(MenuRecipe menuRecipe, int menuId, int recipeId)
        {
            var existingMenu = await _menuRepository.FindById(menuId);
            if (existingMenu == null)
                return new MenuRecipeResponse("Menu not found");
            menuRecipe.Menu = existingMenu;

            var existingRecipe = await _recipeRepository.FindById(recipeId);
            if (existingRecipe == null)
                return new MenuRecipeResponse("Recipe not found");
            menuRecipe.Recipe = existingRecipe;

            try
            {
                await _menuRecipeRepository.AddAsync(menuRecipe);
                await _unitOfWork.CompleteAsync();
                return new MenuRecipeResponse(menuRecipe);
            }
            catch (Exception ex)
            {
                return new MenuRecipeResponse($"An error ocurred while saving the Menu Recipe: {ex.Message}");
            }
        }

        public async Task<MenuRecipeResponse> UpdateAsync(int menuId, int recipeId, MenuRecipe menuRecipe)
        {
            var existingMenuRecipe = await _menuRecipeRepository.FindByMenuIdAndRecipeId(menuId, recipeId);
            if (existingMenuRecipe == null)
                return new MenuRecipeResponse("Menu Recipe not found");
            existingMenuRecipe.MenuId = menuRecipe.MenuId;
            existingMenuRecipe.RecipeId = menuRecipe.RecipeId;
            try
            {
                _menuRecipeRepository.Update(existingMenuRecipe);
                await _unitOfWork.CompleteAsync();
                return new MenuRecipeResponse(existingMenuRecipe);
            }
            catch (Exception ex)
            {
                return new MenuRecipeResponse($"An error ocurred while updating the Menu Recipe: {ex.Message}");
            }
        }
    }
}
