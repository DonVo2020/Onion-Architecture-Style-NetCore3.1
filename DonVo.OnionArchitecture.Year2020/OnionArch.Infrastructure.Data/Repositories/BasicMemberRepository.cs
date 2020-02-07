using Microsoft.EntityFrameworkCore;
using OnionArch.Domain.Entities;
using OnionArch.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace OnionArch.Infrastructure.Data.Repositories
{
    public class BasicMemberRepository : Repository<Member>, IBasicMemberRepository
    {
        public BasicMemberRepository(CreditContext context) : base(context) { }

        public async Task<IEnumerable<Member>> GetAllBasicMembersAsync()
        {
            return await CreditContext.Member.ToListAsync();
        }

        public async Task<Member> GetBasicMemberByIdAsync(int memberNo)
        {
            return await CreditContext.Member.SingleOrDefaultAsync(m => m.MemberNo == memberNo);
        }

        public async Task<int> UpdateBasicMemberAsync(Member member, int memberNo)
        {
            var updateMember = await (from a in CreditContext.Member
                        where a.MemberNo == memberNo
                        select a).SingleOrDefaultAsync();
            if (updateMember != null)
            {
                updateMember.MemberNo = member.MemberNo;
                updateMember.RegionNo = member.RegionNo;
                updateMember.LastName = member.LastName;
                updateMember.Middleinitial = member.Middleinitial;
                updateMember.FirstName = member.FirstName;
                updateMember.Street = member.Street;
                updateMember.City = member.City;
                updateMember.StateProv = member.StateProv;
                updateMember.PhoneNo = member.PhoneNo;
                updateMember.IssueDt = DateTime.Now;
                member.MailCode = "33333";
                member.Country = "US";
                updateMember.ExprDt = DateTime.Now.AddYears(3);

                CreditContext.Update(updateMember);
                return 1;
            }
            else
            {
                return -1;
            }
        }

        public async Task<int> AddBasicMemberAsync(Member member)
        {
            member.MemberNo = 0;
            member.MailCode = "33333";
            member.Country = "US";
            var result = await (from c in CreditContext.BasicMember
                                where c.LastName == member.LastName
                                          && c.FirstName == member.FirstName
                                          && c.PhoneNo == c.PhoneNo
                                select c).SingleOrDefaultAsync();
            if (result == null)
            {
                var add = CreditContext.Member.Add(member);
                if (add != null)
                {
                    return 1;
                }
            }

            return -1;
        }

        public async Task<int> DeleteBasicMemberByIdAsync(int memberNo)
        {
            var deleteMember = await (from a in CreditContext.Member
                                      where a.MemberNo == memberNo
                                      select a).SingleOrDefaultAsync();

            if (deleteMember != null)
            {
                var deleted = CreditContext.Remove(deleteMember);
                if (deleted != null)
                {
                    return 1;
                }
            }

            return -1;
        }

        private CreditContext CreditContext
        {
            get { return Context as CreditContext; }
        }
    }
}
