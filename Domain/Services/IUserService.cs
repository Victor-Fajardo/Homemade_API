using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Homemade.Domain.Services.Communications;

namespace Homemade.Domain.Services
{
    public interface IUserService
    {
        Task<UserResponse> GetByEmailAsync(string email);
    }
}
