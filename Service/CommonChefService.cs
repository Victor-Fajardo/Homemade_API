using Homemade.Domain.Models;
using Homemade.Domain.Repositories;
using Homemade.Domain.Services;
using Homemade.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homemade.Service
{
    public class CommonChefService : ICommonChefService
    {
        private readonly ICommonChefRepository _commonChefRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CommonChefService(ICommonChefRepository commonChefRepository, IUnitOfWork unitOfWork)
        {
            _commonChefRepository = commonChefRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CommonChefResponse> AssingCommonChefAsync(int userChefId, int userCommonId)
        {
            try
            {
                await _commonChefRepository.AssignCommonChef(userChefId, userCommonId);
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception ex)
            {
                return new CommonChefResponse($"An error ocurred while assigning Product and Tag: {ex.Message}");
            }
            return new CommonChefResponse(await _commonChefRepository.FindByCommonIdAndChefId(userChefId, userCommonId));
        }

        public async Task<IEnumerable<CommonChef>> ListAsync()
        {
            return await _commonChefRepository.ListAsync();
        }

        public async Task<IEnumerable<CommonChef>> ListByUserChefIdAsync(int userChefId)
        {
            return await _commonChefRepository.ListByCommonIdAsync(userChefId);
        }

        public async Task<IEnumerable<CommonChef>> ListByUserCommonIdAsync(int userCommonId)
        {
            return await _commonChefRepository.ListByChefIdAsync(userCommonId);
        }

        public async Task<CommonChefResponse> UnassingCommonChefAsync(int userChefId, int userCommonId)
        {
            try
            {
                CommonChef commonChef = await _commonChefRepository.FindByCommonIdAndChefId(userChefId, userCommonId);
                _commonChefRepository.Remove(commonChef);
                await _unitOfWork.CompleteAsync();
                return new CommonChefResponse(commonChef);
            }
            catch(Exception ex) 
            {
                return new CommonChefResponse($"An error ocurred while assigning Tag to CommonChef: {ex.Message}");
            }
        }
    }
}
