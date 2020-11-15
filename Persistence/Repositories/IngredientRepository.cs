using Homemade.Domain.Models;
using Homemade.Domain.Persistence.Contexts;
using Homemade.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homemade.Persistence.Repositories
{
    public class IngredientRepository : BaseRepository, IIngredientRepository
    {
        public IngredientRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Ingredient ingredient)
        {
            await _context.Ingredients.AddAsync(ingredient);
        }

        public async Task<Ingredient> FindById(int id)
        {
            return await _context.Ingredients.FindAsync(id);
        }

        public async Task<IEnumerable<Ingredient>> ListAsync()
        {
            return await _context.Ingredients.ToListAsync();
        }

        public async Task<IEnumerable<Ingredient>> ListByRecipeIdAsync(int recipeId)
        {
            return await _context.Ingredients.Where(b => b.RecipeId == recipeId).ToListAsync();
        }

        public void Remove(Ingredient ingredient)
        {
            _context.Ingredients.Remove(ingredient);
        }

        public void Update(Ingredient ingredient)
        {
            _context.Ingredients.Update(ingredient);
        }
    }
}
