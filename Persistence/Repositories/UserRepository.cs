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
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<User> FindById(int id)
        {
            return await _context.Users.FindAsync(id);
        }
        public async Task<User> FindByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(a => a.Email == email);
        }

        public User FindByEmailandPassword(string email, string password)
        {
            return _context.Users.SingleOrDefault(a => a.Email == email && a.Password == password);
        }
    }
}
