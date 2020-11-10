using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Homemade.Resource
{
    public class SaveMessageResource
    {
        [Required]
        public string Text { get; set; }

        public Byte[] File { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}
