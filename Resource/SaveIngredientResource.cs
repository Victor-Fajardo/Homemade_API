using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Homemade.Resource
{
    public class SaveIngredientResource
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required]
        public string Quantity { get; set; }
    }
}
