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
    public class ChatRepository : BaseRepository, IChatRepository
    {
        public ChatRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Chat chat)
        {
            await _context.Chats.AddAsync(chat);
        }

        public async Task<Chat> FindById(int id)
        {
            return await _context.Chats.FindAsync(id);
        }

        public async Task<IEnumerable<Chat>> FindByUser1andUser2(int user1Id, int user2Id)
        {
            return await _context.Chats
                .Where(b => b.User1Id == user1Id && b.User2Id == user2Id).ToListAsync();
        }

        public Task<IEnumerable<Chat>> ListAsync()
        {
            throw new NotImplementedException();
        }

        public void Remove(Chat chat)
        {
            _context.Chats.Remove(chat);
        }
    }
}

