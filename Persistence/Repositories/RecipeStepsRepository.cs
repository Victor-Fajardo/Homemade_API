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
    public class RecipeStepsRepository : BaseRepository, IRecipeStepsRepository
    {
        public RecipeStepsRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(RecipeStep recipeStep)
        {
            await _context.RecipeSteps.AddAsync(recipeStep);
        }

        public async Task<RecipeStep> FindById(int id)
        {
            return await _context.RecipeSteps.FindAsync(id);
        }

        public async Task<IEnumerable<RecipeStep>> ListByRecipeIdAsync(int recipeId)
        {
            return await _context.RecipeSteps
                .Where(b => b.RecipeId == recipeId).ToListAsync();
        }

        public void Remove(RecipeStep recipeStep)
        {
            _context.RecipeSteps.Remove(recipeStep);
        }

        public void Update(RecipeStep recipeStep)
        {
            _context.RecipeSteps.Update(recipeStep);
        }
    }
}
