using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Homemade.Domain.Models;
using Homemade.Domain.Persistence.Contexts;
using Homemade.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Homemade.Persistence.Repositories
{
    public class MenuRecipeRepository : BaseRepository, IMenuRecipeRepository
    {
        public MenuRecipeRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(MenuRecipe menuRecipe)
        {
            await _context.MenuRecipes.AddAsync(menuRecipe);
        }

        public async Task<MenuRecipe> FindById(int id)
        {
            return await _context.MenuRecipes.FindAsync(id);
        }

        public async Task AssignMenuRecipe(int menuId, int recipeId)
        {
            MenuRecipe menuRecipe = await _context.MenuRecipes.FindAsync(menuId, recipeId);
            if (menuRecipe != null)
                await AddAsync(menuRecipe);
        }

        public async Task<MenuRecipe> FindByMenuIdAndRecipeId(int menuId, int recipeId)
        {
            return await _context.MenuRecipes
                .Where(p => p.MenuId == menuId)
                .Where(p => p.RecipeId == recipeId)
                .Include(p => p.Recipe)
                .Include(p => p.Menu)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<MenuRecipe>> ListAsync()
        {
            return await _context.MenuRecipes
                .Include(p => p.Menu)
                .Include(P => P.Recipe)
                .ToListAsync();
        }

        public async Task<IEnumerable<MenuRecipe>> ListByMenuIdAsync(int menuId)
        {
            return await _context.MenuRecipes
                .Where(p => p.MenuId == menuId)
                .Include(p => p.Recipe)
                .Include(p => p.Menu)
                .ToListAsync();
        }

        public async Task<IEnumerable<MenuRecipe>> ListByRecipeIdAsync(int recipeId)
        {
            return await _context.MenuRecipes
                .Where(p => p.RecipeId == recipeId)
                .Include(p => p.Recipe)
                .Include(p => p.Menu)
                .ToListAsync();
        }

        public void Remove(MenuRecipe menuRecipe)
        {
            _context.MenuRecipes.Remove(menuRecipe);
        }

        public void Update(MenuRecipe menuRecipe)
        {
            _context.MenuRecipes.Update(menuRecipe);
        }

        public async void UnassignMenuRecipe(int menuId, int recipeId)
        {
            MenuRecipe menuRecipe = await _context.MenuRecipes.FindAsync(menuId, recipeId);
            if (menuRecipe != null)
                Remove(menuRecipe);
        }
    }
}
