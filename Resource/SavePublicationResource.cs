using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Homemade.Resource
{
    public class SavePublicationResource
    {
        [Required]
        [MaxLength(200)]
        public string Text { get; set; }

        [Required]
        public DateTime Publicationdate { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int Likes { get; set; }

        public Byte[] File { get; set; }
    }
}
