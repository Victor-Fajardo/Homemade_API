using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homemade.Domain.Models
{
    public class CommonChef
    {
        public int CommonId { get; set; }
        public UserCommon UserCommon { get; set; }
        public int ChefId { get; set; }
        public UserChef UserChef { get; set; }
    }
}
