using OnionArch.Domain.Entities;
using OnionArch.Domain.Interfaces;
using OnionArch.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnionArch.Services
{
    public class BasicMemberService : IBasicMemberService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BasicMemberService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Member>> GetAllBasicMembers()
        {
            return await _unitOfWork.BasicMembers.GetAllBasicMembersAsync();
        }

        public async Task<Member> GetBasicMemberById(int memberNo)
        {
            return await _unitOfWork.BasicMembers.GetBasicMemberByIdAsync(memberNo);
        }

        public async Task<int> UpdateBasicMember(Member member, int memberNo)
        {
            await _unitOfWork.BasicMembers.UpdateBasicMemberAsync(member, memberNo);
            return await _unitOfWork.CommitAsync();
        }

        public async Task<int> AddBasicMember(Member member)
        {
            await _unitOfWork.BasicMembers.AddBasicMemberAsync(member);
            return await _unitOfWork.CommitAsync();
        }

        public async Task<int> DeleteBasicMemberById(int memberNo)
        {
            await _unitOfWork.BasicMembers.DeleteBasicMemberByIdAsync(memberNo);
            return await _unitOfWork.CommitAsync();
        }

    }
}
