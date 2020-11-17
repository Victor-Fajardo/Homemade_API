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
    public class UserCommonRepository : BaseRepository, IUserCommonRepository
    {
        public UserCommonRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(UserCommon userCommon)
        {
            await _context.UserCommons.AddAsync(userCommon);
        }

        public async Task<UserCommon> FindByEmail(string email)
        {
            return await _context.UserCommons.FirstOrDefaultAsync(a => a.Email == email);
        }

        public async Task<UserCommon> FindById(int id)
        {
            return await _context.UserCommons.FindAsync(id);
        }

        public async Task<IEnumerable<UserCommon>> ListAsync()
        {
            return await _context.UserCommons.ToListAsync();
        }

        public async Task<IEnumerable<UserCommon>> ListByLastnameAsync(string lastname)
        {
            return await _context.UserCommons
                .Where(p => p.Lastname == lastname)
                .Include(p=>p.Name)
                .Include(p => p.Lastname)
                .ToListAsync();
        }

        public async Task<IEnumerable<UserCommon>> ListByNameAsync(string name)
        {
            return await _context.UserCommons
                .Where(p=>p.Name == name)
                .Include(p => p.Name)
                .Include(p => p.Lastname)
                .ToListAsync();
        }

        public void Remove(UserCommon userCommon)
        {
            _context.UserCommons.Remove(userCommon);
        }

        public void Update(UserCommon userCommon)
        {
            _context.UserCommons.Update(userCommon);
        }
    }
}
