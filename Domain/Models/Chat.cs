﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homemade.Domain.Models
{
    public class Chat
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public User User1 { get; set; }
        public int User1Id { get; set; }
        public User User2 { get; set; }
        public int User2Id { get; set; }
        public List<Message> Messages { get; set; }
    }
}
