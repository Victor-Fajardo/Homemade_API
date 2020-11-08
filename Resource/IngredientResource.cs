using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homemade.Resource
{
    public class IngredientResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Quantity { get; set; }
        public RecipeResource Recipe { get; set; }
    }
}
