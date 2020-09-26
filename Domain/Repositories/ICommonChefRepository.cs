using Homemade.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homemade.Domain.Repositories
{
    public interface ICommonChefRepository
    {
        Task<IEnumerable<CommonChef>> ListAsync();
        Task<IEnumerable<CommonChef>> ListByCommonIdAsync(int commonnId);
        Task<IEnumerable<CommonChef>> ListByChefId(int commonId);

        Task<CommonChef> FindByCommonIdAndChefId(int commonId, int ChefId);

        Task<CommonChef> AddAsync(CommonChef commonChef);
        void Remove(CommonChef commonChef);

        Task AssignCommonChef(int commonId, int ChefId);
        void UnassingCommonChef(int commonId, int ChefId);

    }
}
