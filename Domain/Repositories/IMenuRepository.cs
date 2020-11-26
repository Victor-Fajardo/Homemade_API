using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Homemade.Domain.Models;

namespace Homemade.Domain.Repositories
{
    public interface IMenuRepository
    {
        Task<IEnumerable<Menu>> ListAsync();
        Task<IEnumerable<Menu>> ListByUserId(int userId);
        Task<Menu> FindByUserId(int userId);
        Task<Menu> FindById(int id);
        Task AddAsync(Menu menu);
        void Update(Menu menu);
        void Remove(Menu menu);

    }
}
