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
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository _menuRepository;
        private readonly IUserCommonRepository _userCommonRepository;
        private readonly IMenuRecipeRepository _menuRecipeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public MenuService(IMenuRepository menuRepository, IUserCommonRepository userCommonRepository, IMenuRecipeRepository menuRecipeRepository, IUnitOfWork unitOfWork)
        {
            _menuRepository = menuRepository;
            _userCommonRepository = userCommonRepository;
            _menuRecipeRepository = menuRecipeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<MenuResponse> DeleteAsync(int id)
        {
            var existingMenu = await _menuRepository.FindById(id);
            if (existingMenu == null)
                return new MenuResponse("Menu not found");

            try
            {
                _menuRepository.Remove(existingMenu);
                await _unitOfWork.CompleteAsync();
                return new MenuResponse(existingMenu);
            }
            catch (Exception ex)
            {
                return new MenuResponse($"An error ocurred while deleting menu: {ex.Message}");
            }
        }

        public async Task<MenuResponse> GetByIdAsync(int id)
        {
            var existingMenu = await _menuRepository.FindById(id);
            if (existingMenu == null)
                return new MenuResponse("Menu not found");
            return new MenuResponse(existingMenu);
        }

        public async Task<IEnumerable<Menu>> ListAsync()
        {
            return await _menuRepository.ListAsync();
        }

        public async Task<IEnumerable<Menu>> ListByRecipeId(int recipeId)
        {
            var menuRecipes = await _menuRecipeRepository.ListByRecipeIdAsync(recipeId);
            var menus = menuRecipes.Select(p => p.Menu).ToList();
            return menus;
        }

        public async Task<IEnumerable<Menu>> ListByUserId(int userId)
        {
            return await _menuRepository.ListByUserId(userId);
        }

        public async Task<MenuResponse> SaveAsync(Menu menu, int userId)
        {
            var existingUser = await _userCommonRepository.FindById(userId);
            if (existingUser == null)
            {
                return new MenuResponse("User not found");
            }

            menu.UserCommon = existingUser;

            try
            {
                await _menuRepository.AddAsync(menu);
                await _unitOfWork.CompleteAsync();
                return new MenuResponse(menu);
            }
            catch (Exception ex)
            {
                return new MenuResponse(
                    $"An error ocurred while saving the menu: {ex.Message}");
            }
        }

        public async Task<MenuResponse> UpdateAsync(int id, Menu menu)
        {
            var existingMenu = await _menuRepository.FindById(id);
            if (existingMenu == null)
                return new MenuResponse("Menu not found");

            existingMenu.DateOfRecipe = menu.DateOfRecipe;
            try
            {
                _menuRepository.Update(existingMenu);
                await _unitOfWork.CompleteAsync();
                return new MenuResponse(existingMenu);
            }
            catch (Exception ex)
            {
                return new MenuResponse($"An error ocurred while updating menu: {ex.Message}");
            }
        }
    }
}
