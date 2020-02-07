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
    public class RegionRepository : Repository<Region>, IRegionRepository
    {
        public RegionRepository(CreditContext context) : base(context) { }

        public async Task<IEnumerable<Region>> GetAllRegionsAsync()
        {
            return await CreditContext.Region.OrderBy(x=>x.RegionName).ToListAsync();
        }

        public async Task<Region> GetRegionByIdAsync(int regionNo)
        {
            return await CreditContext.Region.SingleOrDefaultAsync(m => m.RegionNo == regionNo);
        }

        public async Task<int> UpdateRegionAsync(Region region, int regionNo)
        {
            var updateRegion = await (from a in CreditContext.Region
                                      where a.RegionNo == regionNo
                                      select a).SingleOrDefaultAsync();
            if (updateRegion != null)
            {
                updateRegion.RegionNo = region.RegionNo;
                updateRegion.RegionName = region.RegionName;
                updateRegion.Street = region.Street;
                updateRegion.City = region.City;
                updateRegion.StateProv = region.StateProv;
                updateRegion.PhoneNo = region.PhoneNo;
                updateRegion.MailCode = "33333";
                updateRegion.Country = region.Country;

                CreditContext.Update(updateRegion);
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
