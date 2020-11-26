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
    public class RecipeRepository : BaseRepository, IRecipeRepository
    {
        public RecipeRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Recipe recipe)
        {
            await _context.Recipes.AddAsync(recipe);
        }

        public async Task<Recipe> FindById(int id)
        {
            return await _context.Recipes.FindAsync(id);
        }

        public async Task<IEnumerable<Recipe>> ListAsync()
        {
            return await _context.Recipes.ToListAsync();
        }

        public async Task<IEnumerable<Recipe>> ListByIdUser(int id)
        {
            return await _context.Recipes.Where(p => p.AuthorId == id).ToListAsync();
        }

        public async Task<IEnumerable<Recipe>> ListById(int id)
        {
            return await _context.Recipes.Where(p => p.Id == id).ToListAsync();
        }
        public async  Task<IEnumerable<Recipe>> ListByName(string name)
        {
            return await _context.Recipes.Where(p => p.NameRecipe == name).ToListAsync();
        }

        public void Remove(Recipe recipe)
        {
            _context.Recipes.Remove(recipe);
        }

        public void Update(Recipe recipe)
        {
            _context.Recipes.Update(recipe);
        }
    }
}
