using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Homemade.Domain.Models;

namespace Homemade.Domain.Repositories
{
    public interface IPublicationRepository
    {
        Task<IEnumerable<Publication>> ListByUserIdAsync(int userId);
        Task<Publication> FindById(int id);
        Task AddAsync(Publication publication);
        void Update(Publication publication);
        void Remove(Publication publication);
    }
}
