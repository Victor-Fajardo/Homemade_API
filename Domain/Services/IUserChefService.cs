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

        Task<UserChefResponse> GetByIdAsync(int id);
        Task<UserChefResponse> GetByEmailAsync(string email);

        Task<IEnumerable<UserChef>> GetByNameAsync(string name);

        Task<IEnumerable<UserChef>> GetByLastnameAsync(string lastname);
        Task<UserChefResponse> SaveAsync(UserChef userChef);
        Task<UserChefResponse> UpdateAsync(int id, UserChef userChef);
        Task<UserChefResponse> DeleteAsync(int id);
        Task<IEnumerable<UserChef>> ListByUserCommonId(int userCommonId);

    }
}
