using OnionArch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnionArch.Domain.Interfaces.Repositories
{
    public interface IBasicMemberRepository : IRepository<Member>
    {
        Task<IEnumerable<Member>> GetAllBasicMembersAsync();
        Task<Member> GetBasicMemberByIdAsync(int memberNo);
        Task<int> UpdateBasicMemberAsync(Member member, int memberNo);
        Task<int> AddBasicMemberAsync(Member member);
        Task<int> DeleteBasicMemberByIdAsync(int memberNo);
    }
}
