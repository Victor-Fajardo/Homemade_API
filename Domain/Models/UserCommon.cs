using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homemade.Domain.Models
{
    public class UserCommon : User
    {

        public bool Membership { get; set; }

        //public List<Menu> Menus;

        public List<Payment> Payments;

        public List<CommonChef> CommonChefs;

    }
}
