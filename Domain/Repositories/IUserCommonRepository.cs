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

        Task<IEnumerable<UserCommon>> ListByNameAsync(string name);

        Task<IEnumerable<UserCommon>> ListByLastnameAsync(string lastname);

        void Update(UserCommon userCommon);

        void Remove(UserCommon userCommon);


    }
}
