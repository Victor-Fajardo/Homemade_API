using Homemade.Domain.Models;
using Homemade.Domain.Persistence.Contexts;
using Homemade.Domain.Repositories;
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
    }
}
