using Homemade.Domain.Models;
using Homemade.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homemade.Domain.Services
{
    public interface IUserCommonService
    {
        Task<IEnumerable<UserCommon>> ListAsync();

        Task<UserCommonResponse> GetByIdAsync(int id);
        Task<UserCommonResponse> GetByEmailAsync(string email);
        Task<IEnumerable<UserCommon>> GetByNameAsync(string name);

        Task<IEnumerable<UserCommon>> GetByLastnameAsync(string lastname);
        Task<UserCommonResponse> SaveAsync(UserCommon userCommon);
        Task<UserCommonResponse> UpdateAsync(int id, UserCommon userCommon);
        Task<UserCommonResponse> DeleteAsync(int id);

        Task<IEnumerable<UserCommon>> ListByUserChefId(int userChefId);


    }
}
