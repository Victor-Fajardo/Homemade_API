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
        private readonly IUnitOfWork _unitOfWork;

        public MenuRecipeService(IMenuRecipeRepository menuRecipeRepository, IUnitOfWork unitOfWork)
        {
            _menuRecipeRepository = menuRecipeRepository;
            _unitOfWork = unitOfWork;
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
    }
}
