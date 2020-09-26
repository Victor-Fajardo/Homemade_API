using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homemade.Domain.Models
{
    public class UserCommon
    {
        public List<UserChef> UserChefs;

        public bool Membership;

        public List<Menu> Menus;

        public List<Payment> Payments;

    }
}
