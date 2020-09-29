using Homemade.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homemade.Domain.Services.Communications
{
    public class UserCommonResponse : BaseResponse<UserCommon>
    {
        public UserCommonResponse(string message) : base(message)
        {
        }

        public UserCommonResponse(UserCommon resource) : base(resource)
        {
        }
    }
}
