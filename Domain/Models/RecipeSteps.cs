using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homemade.Domain.Models
{
    public class RecipeStep
    {
        public int Id { get; set; }
        public string Instructions { get; set; }
        public Byte[] Picture { get; set; }
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
    }
}
