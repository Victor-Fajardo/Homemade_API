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
    public class CommentRepository : BaseRepository, ICommentRepository
    {
        public CommentRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Comment comment)
        {
            await _context.Comments.AddAsync(comment);
        }

        public async Task<Comment> FindById(int id)
        {
            return await _context.Comments.FindAsync(id);
        }

        public async Task<IEnumerable<Comment>> ListByPublicationIdAsync(int publicationId)
        {
            return await _context.Comments
                .Where(b => b.PublicationId == publicationId).ToListAsync();
        }

        public async Task<IEnumerable<Comment>> ListByUserIdAsync(int userId)
        {
            return await _context.Comments
                .Where(b => b.UserId == userId).ToListAsync();
        }

        public void Remove(Comment comment)
        {
            _context.Comments.Remove(comment);
        }


        public void Update(Comment comment)
        {
            _context.Comments.Update(comment);
        }
    }
}
