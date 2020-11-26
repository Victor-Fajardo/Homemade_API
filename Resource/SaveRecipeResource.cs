using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Homemade.Resource
{
    public class SaveRecipeResource
    {
        [Required]
        [MaxLength(50)]
        public string NameRecipe { get; set; }
        [Required]
        public string Instructions { get; set; }

        public string Img { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}
