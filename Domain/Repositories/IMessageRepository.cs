using Homemade.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homemade.Domain.Repositories
{
    public interface IMessageRepository
    {
        Task<IEnumerable<Message>> ListAsync();
        Task<Message> FindById(int id);
        Task<IEnumerable<Message>> ListBychatIdAsync(int chatId);
        Task AddAsync(Message message);
        void Remove(Message message);
    }
}
