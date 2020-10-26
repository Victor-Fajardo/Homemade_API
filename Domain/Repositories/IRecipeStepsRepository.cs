using Homemade.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homemade.Domain.Repositories
{
    public interface IRecipeStepsRepository
    {
        Task<IEnumerable<Comment>> ListByRecipeIdAsync(int recipeId);
        Task AddAsync(Recipe recipe);
        Task<Recipe> FindById(int id);
        void Update(Recipe recipe);
        void Remove(Recipe recipe);
    }
}
