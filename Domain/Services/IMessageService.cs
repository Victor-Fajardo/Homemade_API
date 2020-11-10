using Homemade.Domain.Models;
using Homemade.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homemade.Domain.Services
{
    public interface IMessageService
    {
        Task<IEnumerable<Message>> ListByChatIdAsync(int chatId);
        Task<MessageResponse> SaveAsync(Message message, int ChatId, int userId);
        Task<MessageResponse> Delete(int id);
    }
}
