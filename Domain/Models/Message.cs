using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homemade.Domain.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public Byte[] File { get; set; }
        public DateTime Date { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public Chat Chat { get; set; }
        public int ChatId { get; set; }

    }
}
