using System;
namespace ProiectaDAW_Library.Models
{
    public class MemberCard
    {
        public string Code { get; set; }
        public DateTime IssuedAt { get; set; }
        public DateTime ExpiringOn { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
    }
}
