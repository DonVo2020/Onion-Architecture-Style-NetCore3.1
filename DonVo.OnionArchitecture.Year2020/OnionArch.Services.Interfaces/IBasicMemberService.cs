using OnionArch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnionArch.Services.Interfaces
{
    public interface IBasicMemberService
    {
        Task<IEnumerable<Member>> GetAllBasicMembers();
        Task<Member> GetBasicMemberById(int memberNo);
        Task<int> UpdateBasicMember(Member member, int memberNo);
        Task<int> AddBasicMember(Member member);
        Task<int> DeleteBasicMemberById(int memberNo);
    }
}
