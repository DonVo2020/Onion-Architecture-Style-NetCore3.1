using OnionArch.Domain.Entities;
using OnionArch.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace OnionArch.Infrastructure.Data.Repositories
{
    public class ChargeWideRepository : Repository<ChargeWide>, IChargeWideRepository
    {
        public ChargeWideRepository(CreditContext context) : base(context) { }

        public async Task<IEnumerable<ChargeWide>> GetAllChargeWidesAsync()
        {
            return await CreditContext.ChargeWide.ToListAsync();
        }

        public async Task<IEnumerable<ChargeWide>> GetChargeWidesByMemberNoAsync(int memberNo)
        {
            return await CreditContext.ChargeWide.Where(m => m.MemberNo == memberNo).ToListAsync();
        }

        public async Task<IEnumerable<ChargeWide>> GetChargeWidesByCategoryAndRegionAsync(int categoryNo, int regionNo)
        {
            return await CreditContext.ChargeWide
                .Where(m => m.CategoryNo == categoryNo && m.RegionNo == regionNo).ToListAsync();
        }


        private CreditContext CreditContext
        {
            get { return Context as CreditContext; }
        }
    }
}
