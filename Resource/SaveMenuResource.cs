using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Homemade.Resource
{
    public class SaveMenuResource
    {
        [Required]
        public DateTime DateOfRecipe { get; set; }
    }
}
