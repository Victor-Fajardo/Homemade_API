using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Homemade.Domain.Services.Communications;

namespace Homemade.Domain.Services
{
    public interface IUserService
    {
        AuthenticationResponse Authenticate(AuthenticationRequest request);
        Task<UserResponse> GetByEmailAsync(string email);
    }
}
