using Homemade.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homemade.Domain.Services.Communications
{
    public class UserChefResponse : BaseResponse<UserChef>
    {
        public UserChefResponse(string message) : base(message)
        {

        }
        public UserChefResponse(UserChef resource): base(resource)
        {

        }

    }
}
