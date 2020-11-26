using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homemade.Resource
{
    public class RecipeStepsResource
    {
        public int Id { get; set; }
        public string Instructions { get; set; }
        public RecipeResource Recipe { get; set; }
    }
}
