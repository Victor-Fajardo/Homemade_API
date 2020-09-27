using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homemade.Domain.Models
{
    public class Publication
    {
        public int Id { get; set;}
        public User author {get; set;}
        public DateTime publicationdate {get; set;}
        public string text{get; set;}
        public List<Comment> comments;
        public int likes {get; set;}
        public Byte[] file{get; set;}
    }
}
