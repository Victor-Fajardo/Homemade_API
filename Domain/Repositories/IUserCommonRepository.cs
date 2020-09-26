using Homemade.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homemade.Domain.Repositories
{
    public interface IUserCommonRepository
    {
        Task<IEnumerable<UserCommon>> ListAsync();
        Task AddAsync(UserCommon userCommon);
        Task<UserCommon> FindById(int id);

        Task<UserCommon> FindByName(string name);

        void Update(UserCommon userCommon);

        void Remove(UserCommon userCommon);


    }
}
