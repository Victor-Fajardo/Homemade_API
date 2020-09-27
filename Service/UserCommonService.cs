using Homemade.Domain.Models;
using Homemade.Domain.Services;
using Homemade.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homemade.Service
{
    public class UserCommonService : IUserCommonService
    {
        public Task<UserCommonResponse> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UserCommonResponse> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UserCommonResponse> GetByLastnameAsync(string lastname)
        {
            throw new NotImplementedException();
        }

        public Task<UserCommonResponse> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserCommon>> ListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserCommon>> ListByUserChefIdAsync(int userChefId)
        {
            throw new NotImplementedException();
        }

        public Task<UserCommonResponse> SaveAsync(UserCommon userCommon)
        {
            throw new NotImplementedException();
        }

        public Task<UserCommonResponse> UpdateAsync(int id, UserCommon userCommon)
        {
            throw new NotImplementedException();
        }
    }
}
