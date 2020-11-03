using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Homemade.Resource
{
    public class SaveChatResource
    {
        [Required]
        public DateTime Date { get; set; }
    }
}
