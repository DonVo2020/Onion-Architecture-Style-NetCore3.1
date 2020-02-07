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
    public class StatementWideRepository : Repository<StatementWide>, IStatementWideRepository
    {
        public StatementWideRepository(CreditContext context) : base(context) { }

        public async Task<IEnumerable<StatementWide>> GetAllStatementWidesAsync()
        {
            return await CreditContext.StatementWide.ToListAsync();
        }

        public async Task<StatementWide> GetStatementWideByIdAsync(int statementNo)
        {
            return await CreditContext.StatementWide.SingleOrDefaultAsync(m => m.StatementNo == statementNo);
        }

        public async Task<IEnumerable<StatementWide>> GetStatementWidesByMemberAsync(int memberNo)
        {
            return await CreditContext.StatementWide.Where(m => m.MemberNo == memberNo).ToListAsync();
        }

        public async Task<IEnumerable<StatementWide>> GetStatementWidesByRegionAsync(int regionNo)
        {
            return await CreditContext.StatementWide
                .Where(m => m.RegionNo == regionNo).ToListAsync();
        }

        private CreditContext CreditContext
        {
            get { return Context as CreditContext; }
        }
    }
}
