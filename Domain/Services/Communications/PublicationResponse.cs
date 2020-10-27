using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Homemade.Domain.Models;

namespace Homemade.Domain.Services.Communications
{
    public class PublicationResponse : BaseResponse<Publication>
    {
        public PublicationResponse(Publication resource) : base(resource)
        {
        }

        public PublicationResponse(string message) : base(message)
        {
        }
    }
}
