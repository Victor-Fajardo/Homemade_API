using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homemade.Domain.Models
{
    public class Comment
    {
        public int PublicationId { get; set; }
        public Publication Publication { get; set; }
    }
}
