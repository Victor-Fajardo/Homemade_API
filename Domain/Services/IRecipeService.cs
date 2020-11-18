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
        Task<IEnumerable<Recipe>> ListByName(string name);
        Task<RecipeResponse> GetByIdAsync(int id);
        Task<RecipeResponse> SaveAsync(Recipe recipe, int userChefId);
        Task<RecipeResponse> UpdateAsync(int id, Recipe recipe);
        Task<RecipeResponse> DeleteAsync(int id);
    }
}
