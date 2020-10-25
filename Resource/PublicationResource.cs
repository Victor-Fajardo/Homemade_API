using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Homemade.Domain.Models;

namespace Homemade.Resource
{
    public class PublicationResource
    {
        public int Id { get; set; }
        public DateTime Publicationdate { get; set; }
        public string Text { get; set; }
        public int UserId { get; set; }
        public int Likes { get; set; }
        public Byte[] File { get; set; }
    }
}
