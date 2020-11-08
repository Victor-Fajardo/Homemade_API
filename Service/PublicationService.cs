using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Homemade.Domain.Models;
using Homemade.Domain.Repositories;
using Homemade.Domain.Services;
using Homemade.Domain.Services.Communications;

namespace Homemade.Service
{
    public class PublicationService : IPublicationService
    {
        private readonly IPublicationRepository _publicationRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserChefRepository _userChefRepository;
        private readonly IUserCommonRepository _userCommonRepository;

        public PublicationService(IPublicationRepository publicationRepository, IUserChefRepository userChefRepository, IUserCommonRepository userCommonRepository, IUnitOfWork unitOfWork)
        {
            _publicationRepository = publicationRepository;
            _unitOfWork = unitOfWork;
            _userChefRepository = userChefRepository;
            _userCommonRepository = userCommonRepository;
        }

        public async Task<PublicationResponse> Delete(int id)
        {
            var existingPublication = await _publicationRepository.FindById(id);
            if (existingPublication == null)
                return new PublicationResponse("Publication not found");

            try
            {
                _publicationRepository.Remove(existingPublication);
                await _unitOfWork.CompleteAsync();
                return new PublicationResponse(existingPublication);
            }
            catch(Exception ex)
            {
                return new PublicationResponse($"An error ocurred while deleting publication: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Publication>> ListByUserIdAsync(int userId)
        {
            return await _publicationRepository.ListByUserIdAsync(userId);
        }

        public async Task<PublicationResponse> SaveAsync(Publication publication, int userId)
        {
            var existingUser = await _userCommonRepository.FindById(userId);
            if (existingUser == null)
            {
                return new PublicationResponse("User not found");
            }

            publication.User = existingUser;

            try
            {
                await _publicationRepository.AddAsync(publication);
                await _unitOfWork.CompleteAsync();
                return new PublicationResponse(publication);
            }
            catch (Exception ex)
            {
                return new PublicationResponse(
                    $"An error ocurred while saving the publication: {ex.Message}");
            }
        }

        public async Task<PublicationResponse> UpdateAsync(int id, Publication publication)
        {
            var existingPublication = await _publicationRepository.FindById(id);
            if (existingPublication == null)
                return new PublicationResponse("Publication not found");

            existingPublication.Text = publication.Text;
            try
            {
                _publicationRepository.Update(existingPublication);
                await _unitOfWork.CompleteAsync();
                return new PublicationResponse(existingPublication);
            }
            catch (Exception ex)
            {
                return new PublicationResponse($"An error ocurred while updating publication: {ex.Message}");
            }
        }
    }
}
