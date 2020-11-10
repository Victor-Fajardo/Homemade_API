using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Homemade.Domain.Models;

namespace Homemade.Domain.Services.Communications
{
    public class MenuRecipeResponse : BaseResponse<MenuRecipe>
    {
        public MenuRecipeResponse(MenuRecipe resource) : base(resource)
        {
        }

        public MenuRecipeResponse(string message) : base(message)
        {
        }
    }
}
