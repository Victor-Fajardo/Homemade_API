using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homemade.Resource
{
    public class UserResource
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Lastname { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public Byte[] Picture { get; set; }

        public DateTime Date { get; set; }

        public bool Gender { get; set; }
    }
}
