using Homemade.Domain.Models;
using Homemade.Domain.Repositories;
using Homemade.Domain.Services;
using Homemade.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Homemade.Service
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPublicationRepository _publicationRepository;
        private readonly IUserChefRepository _userChefRepository;
        private readonly IUserCommonRepository _userCommonRepository;

        public CommentService(ICommentRepository commentRepository, IPublicationRepository publicationRepository, IUserChefRepository userChefRepository, IUserCommonRepository userCommonRepository, IUnitOfWork unitOfWork)
        {
            _commentRepository = commentRepository;
            _unitOfWork = unitOfWork;
            _publicationRepository = publicationRepository;
            _userChefRepository = userChefRepository;
            _userCommonRepository = userCommonRepository;
        }

        public async Task<CommentResponse> Delete(int id)
        {
            var existingComment = await _commentRepository.FindById(id);
            if (existingComment == null)
                return new CommentResponse("Coment not found");

            try
            {
                _commentRepository.Remove(existingComment);
                await _unitOfWork.CompleteAsync();
                return new CommentResponse(existingComment);
            }
            catch (Exception ex)
            {
                return new CommentResponse($"An error ocurred while deleting comment: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Comment>> ListByPublicationIdAsync(int PublicationId)
        {
            return await _commentRepository.ListByPublicationIdAsync(PublicationId);
        }

        public async Task<IEnumerable<Comment>> ListByUserIdAsync(int userId)
        {
            return await _commentRepository.ListByUserIdAsync(userId);
        }

        public async Task<CommentResponse> SaveAsync(Comment comment, int publicationId, int userId )
        {
            var existingPublication = await _publicationRepository.FindById(publicationId);
            if (existingPublication == null)
                return new CommentResponse("Publication not found");
            var existingUser = await _userCommonRepository.FindById(userId);
            if(existingUser == null) {
                return new CommentResponse("User not found");
            }

            comment.Publication = existingPublication;
            comment.User = existingUser;
            try
            {
                await _commentRepository.AddAsync(comment);
                await _unitOfWork.CompleteAsync();
                return new CommentResponse(comment);
            }
            catch (Exception ex)
            {
                return new CommentResponse(
                    $"An error ocurred while saving the comment: {ex.Message}");
            }
        }

        public async Task<CommentResponse> UpdateAsync(int id, Comment comment)
        {
            var existingComment = await _commentRepository.FindById(id);
            if (existingComment == null)
                return new CommentResponse("Coment not found");
            
            existingComment.Text = comment.Text;
            try 
            {
                _commentRepository.Update(existingComment);
                await _unitOfWork.CompleteAsync();
                return new CommentResponse(existingComment);
            }
            catch (Exception ex)
            {
                return new CommentResponse($"An error ocurred while updating comment: {ex.Message}");
            }
        }
    }
}
