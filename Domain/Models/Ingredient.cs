using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homemade.Domain.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Quantity { get; set; }
        public EUnitOfMeasurement UnitOfMeasurement { get; set; }
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
    }
}
