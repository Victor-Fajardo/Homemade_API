using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homemade.Domain.Models
{
    public class Menu
    {
        public int Id { get; set; }
        public DateTime DateOfRecipe { get; set; }
        public UserCommon UserCommon { get; set; }
        public int UserCommonId { get; set; }
        public List<MenuRecipe> MenuRecipes { get; set; }
    }
}
