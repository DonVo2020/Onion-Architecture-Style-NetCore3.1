using OnionArch.Domain.Entities;
using OnionArch.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace OnionArch.Infrastructure.Data.Repositories
{
    public class OverdueRepository : Repository<Overdue>, IOverdueRepository
    {
        public OverdueRepository(CreditContext context) : base(context) { }

        public async Task<IEnumerable<Overdue>> GetAllOverduesAsync()
        {
            return await CreditContext.Overdue.ToListAsync();
        }

        public async Task<IEnumerable<Overdue>> GetOverduesByMemberNoAsync(int memberNo)
        {
            return await CreditContext.Overdue.Where(m => m.MemberNo == memberNo).ToListAsync();
        }


        private CreditContext CreditContext
        {
            get { return Context as CreditContext; }
        }
    }
}
