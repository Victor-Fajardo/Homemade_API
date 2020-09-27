using Homemade.Domain.Models;
using Homemade.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homemade.Domain.Services
{
    public interface ICommonChefService
    {
        Task<IEnumerable<CommonChef>> ListAsync();

        Task<IEnumerable<CommonChef>> ListByUserChefIdAsync(int userChefId);
        Task<IEnumerable<CommonChef>> ListByUserCommonIdAsync(int userCommonId);
        Task<CommonChefResponse> AssingCommonChefAsync(int userChefId, int userCommonId);
        Task<CommonChefResponse> UnassingCommonChefAsync(int userChefId, int userCommonId);

    }
}
