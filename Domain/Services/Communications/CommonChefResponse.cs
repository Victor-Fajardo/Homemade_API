using Homemade.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homemade.Domain.Services.Communications
{
    public class CommonChefResponse : BaseResponse<CommonChef>
    {
        public CommonChefResponse(string message) : base(message)
        {
        }

        public CommonChefResponse(CommonChef resource) : base(resource)
        {
        }
    }
}
