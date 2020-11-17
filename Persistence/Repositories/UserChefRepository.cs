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
    public class UserChefRepository : BaseRepository, IUserChefRepository
    {
        public UserChefRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(UserChef userChef)
        {
            await _context.UserChefs.AddAsync(userChef);
        }

        public async Task<UserChef> FindById(int id)
        {
            return await _context.UserChefs.FindAsync(id);
        }

        public async Task<UserChef> FindByEmail(string email)
        {
            return await _context.UserChefs.FirstOrDefaultAsync(a=>a.Email==email);
        }
        public async Task<IEnumerable<UserChef>> ListByName(string name)
        {

            return await _context.UserChefs.Where(b => b.Name == name)
                .Include(p => p.Name)
                .Include(p => p.Lastname)
                .ToListAsync(); 
        }

        public async Task<IEnumerable<UserChef>> ListByLastname(string lastname) 
        {
            return await _context.UserChefs
                .Where(b => b.Lastname == lastname )
                .Include(p=>p.Name)
                .Include(p => p.Lastname)
                .ToListAsync();
        }

        public async Task<IEnumerable<UserChef>> ListAsync()
        {

            return await _context.UserChefs.ToListAsync();
        }

        public void Remove(UserChef userChef)
        {
            _context.UserChefs.Remove(userChef);
        }

        public void Update(UserChef userChef)
        {
            _context.UserChefs.Update(userChef);
        }
    }
}
