using Homemade.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homemade.Domain.Repositories
{
    public interface IUserCommonRepository
    {
        Task<IEnumerable<UserChef>> ListAsync();
        Task AddAsync(UserChef userChef);
        Task<UserChef> FindById(int id);

        Task<UserChef> FindByName(string name);

        void Update(UserChef userChef);

        void Remove(UserChef userChef);


    }
}
