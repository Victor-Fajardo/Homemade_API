using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Homemade.Domain.Models;
using Homemade.Domain.Services.Communications;

namespace Homemade.Domain.Services
{
    public interface IMenuService
    {
        Task<IEnumerable<Menu>> ListAsync();
        Task<MenuResponse> GetByIdAsync(int id);
        Task<MenuResponse> SaveAsync(Menu menu, int userId);
        Task<MenuResponse> UpdateAsync(int id, Menu menu);
        Task<MenuResponse> DeleteAsync(int id);
        Task<IEnumerable<Menu>> ListByRecipeId(int recipeId);
        Task<IEnumerable<Menu>> ListByUserId(int userId);
    }
}
