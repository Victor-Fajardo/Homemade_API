using Homemade.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homemade.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User> FindById(int id);
        Task<User> FindByEmail(string email);
        User FindByEmailandPassword(string email, string password);
    }
}
