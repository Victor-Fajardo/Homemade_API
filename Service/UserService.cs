using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Homemade.Domain.Services;
using Homemade.Domain.Repositories;
using Homemade.Domain.Services.Communications;

namespace Homemade.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<UserResponse> GetByEmailAsync(string email)
        {
            var existingUser = await _userRepository.FindByEmail(email);
            if (existingUser == null)
                return new UserResponse("User not found");
            return new UserResponse(existingUser);
        }
    }
}
