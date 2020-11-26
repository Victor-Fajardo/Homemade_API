using Homemade.Domain.Models;
using Homemade.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homemade.Domain.Services
{
    public interface IRecipeService
    {
        Task<IEnumerable<Recipe>> ListAsync();
        Task<IEnumerable<Recipe>> ListById(int id);
        Task<IEnumerable<Recipe>> ListByName(string name);
        Task<IEnumerable<Recipe>> ListByIdUser(int id);
        Task<IEnumerable<Recipe>> ListByMenuId(int menuId);
        Task<RecipeResponse> GetByIdAsync(int id);
        Task<RecipeResponse> SaveAsync(Recipe recipe, int userChefId);
        Task<RecipeResponse> UpdateAsync(int id, Recipe recipe);
        Task<RecipeResponse> DeleteAsync(int id);
    }
}
