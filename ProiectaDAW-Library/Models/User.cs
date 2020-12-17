using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using ProiectaDAW_Library.Models.Base;

namespace ProiectaDAW_Library.Models
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public MemberCard MemberCard { get; set; }
        public ICollection<Activity> Activities { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
    }
}
