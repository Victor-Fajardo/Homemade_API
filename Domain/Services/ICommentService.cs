using Homemade.Domain.Models;
using Homemade.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homemade.Domain.Services
{
    public interface ICommentService
    {
        Task<IEnumerable<Comment>> ListByUserIdAsync(int userId);
        Task<IEnumerable<Comment>> ListByPublicationIdAsync(int PublicationId);
        Task<CommentResponse> SaveAsync(Comment comment, int publicationId, int userId);
        Task<CommentResponse> UpdateAsync(int id ,Comment comment);
        Task<CommentResponse> Delete(int id);

    }
}
