using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Homemade.Resource
{
    public class SaveUserResource
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        public string Lastname { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        public Byte[] Picture { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public bool Gender { get; set; }
    }
}
