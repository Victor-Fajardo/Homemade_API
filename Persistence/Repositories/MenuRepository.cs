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
    public class MenuRepository : BaseRepository, IMenuRepository
    {
        public MenuRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Menu menu)
        {
            await _context.Menus.AddAsync(menu);
        }

        public async Task<Menu> FindById(int id)
        {
            return await _context.Menus.FindAsync(id);
        }

        public Task<Menu> FindByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Menu>> ListAsync()
        {
            return await _context.Menus.ToListAsync();
        }

        public async Task<IEnumerable<Menu>> ListByUserId(int userId)
        {
            return await _context.Menus.Where(p => p.UserCommonId == userId).ToListAsync();
        }

        public void Remove(Menu menu)
        {
            _context.Menus.Remove(menu);
        }

        public void Update(Menu menu)
        {
            _context.Menus.Update(menu);
        }
    }
}
