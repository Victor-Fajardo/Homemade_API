using Homemade.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homemade.Domain.Services.Communications
{
    public class RecipeResponse : BaseResponse<Recipe>
    {
        public RecipeResponse(Recipe resource) : base(resource)
        {
        }
        public RecipeResponse(string message) : base(message)
        {
        }
    }
}
