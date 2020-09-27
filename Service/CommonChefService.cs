using Homemade.Domain.Models;
using Homemade.Domain.Services;
using Homemade.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homemade.Service
{
    public class CommonChefService : ICommonChefService
    {
        public Task<CommonChefResponse> AssingCommonChefAsync(int userChefId, int userCommonId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CommonChef>> ListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CommonChef>> ListByUserChefIdAsync(int userChefId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CommonChef>> ListByUserCommonIdAsync(int userCommon)
        {
            throw new NotImplementedException();
        }

        public Task<CommonChefResponse> UnassingCommonChefAsync(int userChefId, int userCommonId)
        {
            throw new NotImplementedException();
        }
    }
}
