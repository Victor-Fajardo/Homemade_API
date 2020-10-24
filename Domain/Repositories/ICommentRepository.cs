using Homemade.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homemade.Domain.Repositories
{
    public interface ICommentRepository
    {
        Task<IEnumerable<Comment>> ListByUserIdAsync(int userId);
        Task<IEnumerable<Comment>> ListByPublicationIdAsync(int publicationId);
        Task<Comment> FindById(int id);
        Task AddAsync(Comment comment);
        void Update(Comment comment);
        void Remove(Comment comment);

    }
}
