using Homemade.Domain.Models;
using Homemade.Domain.Repositories;
using Homemade.Domain.Services;
using Homemade.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace Homemade.Service
{
    public class UserChefService : IUserChefService
    {

        private readonly IUserChefRepository _userChefRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICommonChefRepository _commonChefRepository;

        public UserChefService(IUserChefRepository userChefRepository, IUnitOfWork unitOfWork, ICommonChefRepository commonChefRepository)
        {
            _userChefRepository = userChefRepository;
            _unitOfWork = unitOfWork;
            _commonChefRepository = commonChefRepository;
        }

        public async Task<UserChefResponse> DeleteAsync(int id)
        {
            var existingUserChef = await _userChefRepository.FindById(id);
            if (existingUserChef == null)
                return new UserChefResponse("UserChef not found");
            try 
            {
                _userChefRepository.Remove(existingUserChef);
                await _unitOfWork.CompleteAsync();
                return new UserChefResponse(existingUserChef);
            }
            catch(Exception ex)
            {
                return new UserChefResponse($"An error ocurred while deleting UserChef: {ex.Message}");
            }
        }

        public async Task<UserChefResponse> GetByIdAsync(int id)
        {
            var existingUserChef = await _userChefRepository.FindById(id);
            if (existingUserChef == null)
                return new UserChefResponse("UserChef not found");
            return new UserChefResponse(existingUserChef);
        }

        public async Task<UserChefResponse> GetByEmailAsync(string email)
        {
            var existingUserChef = await _userChefRepository.FindByEmail(email);
            if (existingUserChef == null)
                return new UserChefResponse("UserChef not found");
            return new UserChefResponse(existingUserChef);
        }

        public async Task<IEnumerable<UserChef>> GetByLastnameAsync(string lastname)
        {
            return await _userChefRepository.ListByLastname(lastname); 
        }

        public async Task<IEnumerable<UserChef>> GetByNameAsync(string name)
        {
            return await _userChefRepository.ListByName(name);
        }

        public async Task<IEnumerable<UserChef>> ListAsync()
        {
            return await _userChefRepository.ListAsync();
        }

        public async Task<IEnumerable<UserChef>> ListByUserCommonId(int userCommonId)
        {
            var commonChefs = await _commonChefRepository.ListByCommonIdAsync(userCommonId);
            var userChefs = commonChefs.Select(p => p.UserChef).ToList();
            return userChefs;
        }

        public async Task<UserChefResponse> SaveAsync(UserChef userChef)
        {
            try
            {
                await _userChefRepository.AddAsync(userChef);
                await _unitOfWork.CompleteAsync();
                return new UserChefResponse(userChef);
            }
            catch(Exception ex)
            {
                return new UserChefResponse($"An error ocurred while saving the UserChef: {ex.Message}");
            }
        }

        public async Task<UserChefResponse> UpdateAsync(int id, UserChef userChef)
        {
            var existingUserChef = await _userChefRepository.FindById(id);
            if (existingUserChef == null)
                return new UserChefResponse("UserChef not found");
            existingUserChef.Name = userChef.Name;
            existingUserChef.Lastname = userChef.Lastname;
            existingUserChef.Certificate = userChef.Certificate;
            existingUserChef.Email = userChef.Email;
            existingUserChef.Password = userChef.Password;
            existingUserChef.Picture = userChef.Picture;
            existingUserChef.Date = userChef.Date;
            try 
            {
                _userChefRepository.Update(existingUserChef);
                await _unitOfWork.CompleteAsync();
                return new UserChefResponse(existingUserChef);
            }
            catch(Exception ex)
            {
                return new UserChefResponse($"An error ocurred while updating the UserChef: {ex.Message}");
            }


        }
    }
}
