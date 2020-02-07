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
    public class CorporationRepository : Repository<Corporation>, ICorporationRepository
    {
        public CorporationRepository(CreditContext context) : base(context) { }

        public async Task<IEnumerable<Corporation>> GetAllCorporationsAsync()
        {
            return await CreditContext.Corporation.ToListAsync();
        }

        public async Task<Corporation> GetCorporationByIdAsync(int corpNo)
        {
            return await CreditContext.Corporation.SingleOrDefaultAsync(m => m.CorpNo == corpNo);
        }

        public async Task<IEnumerable<Corporation>> GetCorporationsByRegionIdAsync(int regionNo)
        {
            return await CreditContext.Corporation.Where(m => m.RegionNo == regionNo).ToListAsync();
        }

        public async Task<IEnumerable<Corporation>> FindCorporationsContainMembersAsync()
        {
            return await CreditContext.Corporation
                .Include(m=>m.Member)
                .Where(x=>x.Member.Count > 1).ToListAsync();
        }

        public async Task<int> UpdateCorporationAsync(Corporation corp, int corpNo)
        {
            var updateCorp = await (from a in CreditContext.Corporation
                                      where a.CorpNo == corpNo
                                    select a).SingleOrDefaultAsync();
            if (updateCorp != null)
            {
                updateCorp.CorpNo = corp.CorpNo;
                updateCorp.CorpName = corp.CorpName;
                updateCorp.RegionNo = corp.RegionNo;
                updateCorp.Street = corp.Street;
                updateCorp.City = corp.City;
                updateCorp.StateProv = corp.StateProv;
                updateCorp.PhoneNo = corp.PhoneNo;
                updateCorp.MailCode = "33333";
                updateCorp.Country = corp.Country;
                updateCorp.ExprDt = DateTime.Now.AddYears(5);

                CreditContext.Update(updateCorp);
                return 1;
            }
            else
            {
                return -1;
            }
        }

        private CreditContext CreditContext
        {
            get { return Context as CreditContext; }
        }
    }
}
