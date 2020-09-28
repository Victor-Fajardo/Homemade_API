using Homemade.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homemade.Domain.Repositories
{
    public interface IIngredientRepository
    {
        Task<IEnumerable<Ingredient>> ListAsync();
        Task AddAsync(Ingredient ingredient);
        Task<Ingredient> FindById(int id);
        void Update(Ingredient ingredient);

        void Remove(Ingredient ingredient);
    }
}
