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

        Task<IEnumerable<UserCommon>> ListByUserChefIdAsync(int userChefId);

        Task<UserCommonResponse> GetByIdAsync(int id);

        Task<UserCommonResponse> GetByNameAsync(string name);

        Task<UserCommonResponse> GetByLastnameAsync(string lastname);
        Task<UserCommonResponse> SaveAsync(UserCommon userCommon);
        Task<UserCommonResponse> UpdateAsync(int id, UserCommon userCommon);
        Task<UserCommonResponse> DeleteAsync(int id);
    }
}
