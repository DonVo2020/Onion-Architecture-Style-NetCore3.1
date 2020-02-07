using OnionArch.Domain.Entities;
using OnionArch.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnionArch.Infrastructure.Data.Repositories
{
    public class CorpMemberRepository : Repository<CorpMember>, ICorpMemberRepository
    {
        public CorpMemberRepository(CreditContext context) : base(context) { }
    }
}
