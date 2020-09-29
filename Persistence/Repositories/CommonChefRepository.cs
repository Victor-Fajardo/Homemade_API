using Homemade.Domain.Models;
using Homemade.Domain.Persistence.Contexts;
using Homemade.Domain.Repositories;
using Homemade.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;

namespace Homemade.Persistence
{
    public class CommonChefRepository : BaseRepository, ICommonChefRepository
    {
        public CommonChefRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(CommonChef commonChef)
        {
            await _context.CommonChefs.AddAsync(commonChef);
        }

        public async Task AssignCommonChef(int commonId, int chefId)
        {
            CommonChef commonChef = await _context.CommonChefs.FindAsync(commonId, chefId);
            if (commonChef != null)
                await AddAsync(commonChef);
        }

        public async Task<CommonChef> FindByCommonIdAndChefId(int commonId, int chefId)
        {
            return await _context.CommonChefs
                .Where(p => p.CommonId == commonId)
                .Where(p => p.ChefId == chefId)
                .Include(p => p.UserChef)
                .Include(p => p.UserCommon)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<CommonChef>> ListAsync()
        {
            return await _context.CommonChefs
                .Include(p => p.UserCommon)
                .Include(P => P.UserChef)
                .ToListAsync();
        }

        public async Task<IEnumerable<CommonChef>> ListByChefIdAsync(int chefId)
        {
            return await _context.CommonChefs
                .Where(p => p.ChefId == chefId)
                .Include(p => p.UserCommon)
                .Include(p => p.UserChef)
                .ToListAsync();
        }

        public async Task<IEnumerable<CommonChef>> ListByCommonIdAsync(int commonnId)
        {
            return await _context.CommonChefs
                .Where(p => p.CommonId == commonnId)
                .Include(p => p.UserCommon)
                .Include(p => p.UserChef)
                .ToListAsync();
        }

        public void Remove(CommonChef commonChef)
        {
            _context.CommonChefs.Remove(commonChef);
        }

        public async void UnassingCommonChef(int commonId, int chefId)
        {
            CommonChef commonChef = await _context.CommonChefs.FindAsync(commonId, chefId);
            if (commonChef != null)
                Remove(commonChef);

            
        }
    }
}
