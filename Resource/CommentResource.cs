﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homemade.Resource
{
    public class CommentResource
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Likes { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public int PublicationId { get; set; }
    }
}
