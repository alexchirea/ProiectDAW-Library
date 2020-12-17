using System;
using ProiectaDAW_Library.Models;
using ProiectaDAW_Library.Repositories.GenericRepositories;

namespace ProiectaDAW_Library.Repositories
{
    public interface IMemberCardRepository: IGenericRepository<MemberCard>
    {
        MemberCard GetByCode(string code);
        MemberCard GetByUserId(string userId);
    }
}
