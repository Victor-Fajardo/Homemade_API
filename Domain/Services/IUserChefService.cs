using Homemade.Domain.Models;
using Homemade.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homemade.Domain.Services
{
    public interface IUserChefService
    {
        Task<IEnumerable<UserChef>> ListAsync();

        Task<IEnumerable<UserChef>> ListByUserCommonIdAsync(int userCommonId);

        Task<UserChefResponse> GetByIdAsync(int id);

        Task<UserChefResponse> GetByNameAsync(string name);

        Task<UserChefResponse> GetByLastnameAsync(string lastname);
        Task<UserChefResponse> SaveAsync(UserChef userChef);
        Task<UserChefResponse> UpdateAsync(int id, UserChef userChef);
        Task<UserChefResponse> DeleteAsync(int id);
    }
}
