using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homemade.Domain.Models
{
    public class IngredientTag
    {
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }

        public int TagId { get; set; }
        public TagMode Tag { get; set; }
        
    }
}
