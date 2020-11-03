using Homemade.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homemade.Domain.Repositories
{
    public interface IChatRepository
    {
        Task<IEnumerable<Chat>> ListAsync();
        Task<IEnumerable<Chat>> FindByUser1andUser2(int user1Id, int user2Id);
        Task<Chat> FindById(int id);
        Task AddAsync(Chat chat);
        void Remove(Chat chat);
    }
}
