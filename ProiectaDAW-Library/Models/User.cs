using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using ProiectaDAW_Library.Models.Base;
using ProiectaDAW_Library.Models.DTOs;

namespace ProiectaDAW_Library.Models
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public virtual MemberCard MemberCard { get; set; }
        public virtual List<Activity> Activities { get; set; } = new List<Activity>();

        public bool isAdmin {get; set;}

        [JsonIgnore]
        public string Password { get; set; }

        public User(UserRegisterRequestDTO v)
        {
            FirstName = v.FirstName;
            LastName = v.LastName;
            Username = v.Username;
            Password = v.Password;
        }

        public User() { 
            isAdmin = false;
        }
    }
}
