using Homemade.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homemade.Domain.Repositories
{
    public interface IRecipeRepository
    {
        Task<IEnumerable<Recipe>> ListAsync();
        Task<IEnumerable<Recipe>> ListById(int id);
        Task<IEnumerable<Recipe>> ListByName(string name);
        Task<IEnumerable<Recipe>> ListByIdUser(int id);
        Task AddAsync(Recipe recipe);
        Task<Recipe> FindById(int id);
        void Update(Recipe recipe);
        void Remove(Recipe recipe);
    }
}
