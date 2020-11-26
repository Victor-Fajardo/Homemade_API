using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homemade.Resource
{
    public class RecipeResource
    {
        public int Id { get; set; }
        public string NameRecipe { get; set; }
        public string Instructions { get; set; }
        public int Qualification { get; set; }
        public string Img { get; set; }
        public DateTime Date { get; set; }
        public UserChefResource Author { get; set; }
    }
}
