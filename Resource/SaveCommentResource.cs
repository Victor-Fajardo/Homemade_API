using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Homemade.Resource
{
    public class SaveCommentResource
    {
        [Required]
        [MaxLength(200)]
        public string Text { get; set; }
        
        [Required]
        public DateTime Date { get; set; }

    }
}
