using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Homemade.Domain.Models;
using Homemade.Domain.Services.Communications;

namespace Homemade.Domain.Services
{
    public interface IMenuRecipeService
    {
        Task<IEnumerable<MenuRecipe>> ListAsync();
        Task<IEnumerable<MenuRecipe>> ListByMenuIdAsync(int menuId);
        Task<IEnumerable<MenuRecipe>> ListByRecipeIdAsync(int recipeId);
        Task<MenuRecipeResponse> SaveAsync(MenuRecipe menuRecipe, int menuId, int recipeId);
        Task<MenuRecipeResponse> UpdateAsync(int menuId, int recipeId, MenuRecipe menuRecipe);
        Task<MenuRecipeResponse> DeleteAsync(int menuId, int recipeId);
        Task<MenuRecipeResponse> AssingMenuRecipeAsync(int menuId, int recipeId);
        Task<MenuRecipeResponse> UnassingMenuRecipeAsync(int menuId, int recipeId);
    }
}
