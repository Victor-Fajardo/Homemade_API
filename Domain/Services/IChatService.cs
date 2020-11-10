using Homemade.Domain.Models;
using Homemade.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homemade.Domain.Services
{
    public interface IChatService
    {
        Task<ChatResponse> SaveAsync(Chat chat, int user1Id, int user2Id);
        Task<ChatResponse> Delete(int id);
    }
}
