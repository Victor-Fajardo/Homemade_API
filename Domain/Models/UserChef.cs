using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homemade.Domain.Models
{
    public class UserChef : User
    {
        public Byte[] Certificate { get; set; }
        public List<Recipe> Recipes { get; set; }

        public List<CommonChef> CommonChefs{ get; set; }
    }
}
