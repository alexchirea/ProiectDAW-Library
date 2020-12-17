using System;
using System.Linq;
using ProiectaDAW_Library.Data;
using ProiectaDAW_Library.Models;
using ProiectaDAW_Library.Repositories.GenericRepositories;

namespace ProiectaDAW_Library.Repositories
{
    public class MemberCardRepository : GenericRepository<MemberCard>, IMemberCardRepository
    {
        public MemberCardRepository(ProiectDawData context) : base(context) { }

        public MemberCard GetByCode(string code)
        {
            return _table.FirstOrDefault(x => x.Code.Equals(code));
        }

        public MemberCard GetByUserId(string userId)
        {
            return _table.FirstOrDefault(x => x.UserId.Equals(userId));
        }
    }
}
