using System;
using ProiectaDAW_Library.Models.Base;

namespace ProiectaDAW_Library.Models
{
    public class MemberCard: BaseEntity
    {
        public string Code { get; set; }
        public DateTime IssuedAt { get; set; }
        public DateTime ExpiringOn { get; set; }
        public virtual User User { get; set; }
        public Guid UserId { get; set; }
    }
}
