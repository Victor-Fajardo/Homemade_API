using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Homemade.Resource
{
    public class SaveRecipeStepsResource
    {
        [Required]
        [MaxLength(200)]
        public string Instructions { get; set; }
    }
}
