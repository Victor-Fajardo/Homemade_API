using Homemade.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homemade.Domain.Services.Communications
{
    public class IngredientResponse : BaseResponse<Ingredient>
    {
        public IngredientResponse(string message) : base(message)
        {

        }
        public IngredientResponse(Ingredient resource) : base(resource)
        {

        }
    }
}
