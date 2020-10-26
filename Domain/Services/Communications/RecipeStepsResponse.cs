using Homemade.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homemade.Domain.Services.Communications
{
    public class RecipeStepsResponse : BaseResponse<RecipeStep>
    {
        public RecipeStepsResponse(RecipeStep resource) : base(resource)
        {
        }

        public RecipeStepsResponse(string message) : base(message)
        {
        }
    }
}
