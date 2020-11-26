using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Homemade.Domain.Models;

namespace Homemade.Domain.Services.Communications
{
    public class AuthenticationResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Picture { get; set;}
        public string Token { get; set; }
        public DateTime Date { get; set; }
        public bool Gender { get; set; }

        public AuthenticationResponse(User user, string token)
        {
            Id = user.Id;
            Name = user.Name;
            Lastname = user.Lastname;
            Email = user.Email;
            Picture = user.Picture;
            Token = token;
            Date = user.Date;
            Gender = user.Gender;
        }
    }
}
