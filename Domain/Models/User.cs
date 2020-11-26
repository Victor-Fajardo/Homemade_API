using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Homemade.Domain.Models
{
    public abstract class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Lastname {get; set;}

        [JsonIgnore]
        public string Password { get; set; }

        [JsonIgnore]
        public string Token { get; set; }

        public string Email { get; set; }

        public string Picture { get; set; }

        public DateTime Date { get; set; }

        public bool Gender { get; set; }

        public bool Connected { get; set; }

        public List<Message> Messages { get; set; }

        public List<Chat> ChatsCreados { get; set; }

        public List<Chat> ChatsUnidos { get; set; }

        public List<Comment> Comments { get; set; }

        public List<Publication> Publications { get; set; }

        //public List<ChatUser> ChatUsers { get; set; }

    }
}
