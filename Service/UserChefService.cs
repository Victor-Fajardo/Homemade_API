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

        public UserChefService(IUserChefRepository userChefRepository)
        {
            _userChefRepository = userChefRepository;
        }

        public async Task<UserChefResponse> DeleteAsync(int id)
        {
            var existingUserChef = await _userChefRepository.FindById(id);
            if (existingUserChef == null)
                return new UserChefResponse("UserChef not found");
            try 
            {
                _userChefRepository.Remove(existingUserChef);
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

        public async Task<UserChefResponse> SaveAsync(UserChef userChef)
        {
            try
            {
                await _userChefRepository.AddAsync(userChef);
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
                return new UserChefResponse(existingUserChef);
            }
            catch(Exception ex)
            {
                return new UserChefResponse($"An error ocurred while updating the UserChef: {ex.Message}");

            }


        }
    }
}
