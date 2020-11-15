using Homemade.Domain.Models;
using Homemade.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homemade.Domain.Services
{
    public interface IIngredientService
    {
        Task<IEnumerable<Ingredient>> ListAsync();
        Task<IEnumerable<Ingredient>> ListByRecipeIdAsync(int recipeId);
        Task<IngredientResponse> GetByIdAsync(int id);
        Task<IngredientResponse> SaveAsync(Ingredient ingredient, int recipeId);
        Task<IngredientResponse> UpdateAsync(int id, Ingredient ingredient);
        Task<IngredientResponse> DeleteAsync(int id);
    }
}
