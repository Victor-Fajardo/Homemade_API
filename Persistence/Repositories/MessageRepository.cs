using Homemade.Domain.Models;
using Homemade.Domain.Persistence.Contexts;
using Homemade.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homemade.Persistence.Repositories
{
    public class MessageRepository : BaseRepository, IMessageRepository
    {
        public MessageRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Message message)
        {
            await _context.Messages.AddAsync(message);
        }

        public async Task<Message> FindById(int id)
        {
            return await _context.Messages.FindAsync(id);
        }

        public Task<IEnumerable<Message>> ListAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Message>> ListBychatIdAsync(int chatId)
        {
            return await _context.Messages
                .Where(b => b.ChatId == chatId).ToListAsync();
        }

        public void Remove(Message message)
        {
            _context.Messages.Remove(message);
        }
    }
}
