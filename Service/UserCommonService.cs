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
    public class UserCommonService : IUserCommonService
    {
        private readonly IUserCommonRepository _userCommonRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICommonChefRepository _commonChefRepository;
        private readonly IUserRepository _userRepository;

        public UserCommonService(IUserCommonRepository userCommonRepository, ICommonChefRepository commonChefRepository, IUnitOfWork unitOfWork)
        {
            _userCommonRepository = userCommonRepository;
            _unitOfWork = unitOfWork;
            _commonChefRepository = commonChefRepository;
        }

        public async Task<UserCommonResponse> DeleteAsync(int id)
        {
            var existingUserCommon = await _userCommonRepository.FindById(id);
            if (existingUserCommon == null)
                return new UserCommonResponse("UserCommon not found");
            try
            {
                _userCommonRepository.Remove(existingUserCommon);
                await _unitOfWork.CompleteAsync();
                return new UserCommonResponse(existingUserCommon);
            }
            catch (Exception ex)
            {
                return new UserCommonResponse($"An error ocurred while deleting UserCommon: {ex.Message}");
            }
        }

        public async Task<UserCommonResponse> GetByEmailAsync(string email)
        {
            var existingUserCommon = await _userCommonRepository.FindByEmail(email);
            if (existingUserCommon == null)
                return new UserCommonResponse("UserCommon not found");
            return new UserCommonResponse(existingUserCommon);
        }

        public async Task<UserCommonResponse> GetByIdAsync(int id)
        {
            var existingUserCommon = await _userCommonRepository.FindById(id);
            if (existingUserCommon == null)
                return new UserCommonResponse("UserCommon not found");
            return new UserCommonResponse(existingUserCommon);
        }

        public async Task<IEnumerable<UserCommon>> GetByLastnameAsync(string lastname)
        {
            return await _userCommonRepository.ListByLastnameAsync(lastname);
        }

        public async Task<IEnumerable<UserCommon>> GetByNameAsync(string name)
        {
            return await _userCommonRepository.ListByNameAsync(name);
        }

        public async Task<IEnumerable<UserCommon>> ListAsync()
        {
            return await _userCommonRepository.ListAsync();
        }

        public async Task<IEnumerable<UserCommon>> ListByUserChefId(int userChefId)
        {
            var commonChefs = await _commonChefRepository.ListByChefIdAsync(userChefId);
            var userCommons = commonChefs.Select(p => p.UserCommon).ToList();
            return userCommons;
        }

        public async Task<UserCommonResponse> SaveAsync(UserCommon userCommon)
        {
            try
            {
                await _userCommonRepository.AddAsync(userCommon);
                await _unitOfWork.CompleteAsync();
                return new UserCommonResponse(userCommon);
            }
            catch (Exception ex)
            {
                return new UserCommonResponse($"An error ocurred while saving the UserCommon: {ex.Message}");
            }
        }

        public async Task<UserCommonResponse> UpdateAsync(int id, UserCommon userCommon)
        {
            var existingUserCommon = await _userCommonRepository.FindById(id);
            if (existingUserCommon == null)
                return new UserCommonResponse("UserChef not found");
            existingUserCommon.Name = userCommon.Name;
            existingUserCommon.Lastname = userCommon.Lastname;
            existingUserCommon.Membership = userCommon.Membership;
            existingUserCommon.Email = userCommon.Email;
            existingUserCommon.Password = userCommon.Password;
            existingUserCommon.Picture = userCommon.Picture;
            existingUserCommon.Date = userCommon.Date;
            try
            {
                _userCommonRepository.Update(existingUserCommon);
                await _unitOfWork.CompleteAsync();
                return new UserCommonResponse(existingUserCommon);
            }
            catch (Exception ex)
            {
                return new UserCommonResponse($"An error ocurred while updating the UserCommon: {ex.Message}");
            }
        }
    }
}
