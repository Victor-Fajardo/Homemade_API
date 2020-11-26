using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homemade.Domain.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public  string NameRecipe { get; set; }
        public string Instructions { get; set; }
        public int Qualification { get; set; }
        public string Img { get; set; } 
        public DateTime Date { get; set; }
        public int AuthorId { get; set; }
        public UserChef Author { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<RecipeStep> RecipeSteps { get; set; }
        //public List<Comment> Comments { get; set; }
        public List<MenuRecipe> MenuRecipes { get; set; }
    }
}
