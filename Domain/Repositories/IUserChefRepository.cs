using Homemade.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homemade.Domain.Repositories
{
    public interface IUserChefRepository
    {
        Task<IEnumerable<UserChef>> ListAsync();
        Task AddAsync(UserChef userChef);
        Task<UserChef> FindById(int id);
        Task<UserChef> FindByEmail(string email);
        //Task<UserChef> FindByName(string name);
        //Task<UserChef> FindByLastName(string lastname);
        Task<IEnumerable<UserChef>> ListByName(string name);

        Task<IEnumerable<UserChef>> ListByLastname(string lastname);

        void Update(UserChef userChef);

        void Remove(UserChef userChef);
    }
}
