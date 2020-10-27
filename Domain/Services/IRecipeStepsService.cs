using Homemade.Domain.Models;
using Homemade.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homemade.Domain.Services
{
    public interface IRecipeStepsService
    {
        Task<IEnumerable<RecipeStep>> ListByRecipeIdAsync(int recipeId);
        Task<RecipeStepsResponse> SaveAsync(RecipeStep recipeStep, int recipeId);
        Task<RecipeStepsResponse> UpdateAsync(int id, RecipeStep recipeStep);
        Task<RecipeStepsResponse> Delete(int id);
    }
}
