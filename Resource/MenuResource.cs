using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Homemade.Domain.Models;

namespace Homemade.Resource
{
    public class MenuResource
    {
        public int Id { get; set; }
        public DateTime DateOfRecipe { get; set; }
        public UserCommonResource UserCommon { get; set; }
    }
}
