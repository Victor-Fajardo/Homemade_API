using Homemade.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homemade.Domain.Repositories
{
    public interface IRecipeStepsRepository
    {
        Task<IEnumerable<RecipeStep>> ListByRecipeIdAsync(int recipeId);
        Task AddAsync(RecipeStep recipeStep);
        Task<RecipeStep> FindById(int id);
        void Update(RecipeStep recipeStep);
        void Remove(RecipeStep recipeStep);
    }
}
