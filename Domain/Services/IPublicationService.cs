using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Homemade.Domain.Models;
using Homemade.Domain.Services.Communications;

namespace Homemade.Domain.Services
{
    public interface IPublicationService
    {
        Task<IEnumerable<Publication>> ListByUserIdAsync(int userId);
        Task<PublicationResponse> SaveAsync(Publication publication, int userId);
        Task<PublicationResponse> UpdateAsync(int id,Publication publication);
        Task<PublicationResponse> Delete(int id);
    }
}
