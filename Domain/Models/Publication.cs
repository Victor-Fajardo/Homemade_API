using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homemade.Domain.Models
{
    public class Publication
    {
        public int Id { get; set;}
        public User User {get; set;}
        public DateTime Publicationdate {get; set;}
        public string Text{get; set;}
        public int UserId { get; set; }
        public List<Comment> Comments { get; set; }
        public int Likes {get; set;}
        public Byte[] File{get; set;}

    }
}
