using Homemade.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homemade.Domain.Services.Communications
{
    public class ChatUserResponse : BaseResponse<Chat>
    {
        public ChatUserResponse(Chat resource) : base(resource)
        {
        }

        public ChatUserResponse(string message) : base(message)
        {
        }
    }
}
