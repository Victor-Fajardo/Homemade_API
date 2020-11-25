using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Homemade.Domain.Models;

namespace Homemade.Domain.Repositories
{
    public interface IMenuRecipeRepository
    {
        Task<IEnumerable<MenuRecipe>> ListAsync();
        Task<IEnumerable<MenuRecipe>> ListByMenuIdAsync(int menuId);
        Task<IEnumerable<MenuRecipe>> ListByRecipeIdAsync(int recipeId);
        Task<MenuRecipe> FindById(int id);
        Task<MenuRecipe> FindByMenuIdAndRecipeId(int menuId, int recipeId);
        Task AddAsync(MenuRecipe menuRecipe);
        void Remove(MenuRecipe menuRecipe);
        void Update(MenuRecipe menuRecipe);
        Task AssignMenuRecipe(int menuId, int recipeId);
        void UnassignMenuRecipe(int menuId, int recipeId);
        
    }
}
