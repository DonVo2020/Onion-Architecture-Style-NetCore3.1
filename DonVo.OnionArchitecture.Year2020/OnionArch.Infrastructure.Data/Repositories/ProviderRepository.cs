using Microsoft.EntityFrameworkCore;
using OnionArch.Domain.Entities;
using OnionArch.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace OnionArch.Infrastructure.Data.Repositories
{
    public class ProviderRepository : Repository<Provider>, IProviderRepository
    {
        public ProviderRepository(CreditContext context) : base(context) { }

        public async Task<IEnumerable<Provider>> GetAllProvidersAsync()
        {
            return await CreditContext.Provider.ToListAsync();
        }

        public async Task<Provider> GetProviderByIdAsync(int providerNo)
        {
            return await CreditContext.Provider.SingleOrDefaultAsync(m => m.ProviderNo == providerNo);
        }

        public async Task<IEnumerable<Provider>> GetProvidersByRegionAsync(int regionNo)
        {
            return await CreditContext.Provider.Where(m => m.RegionNo == regionNo).ToListAsync();
        }

        public async Task<int> UpdateProviderAsync(Provider provider, int providerNo)
        {
            var updateProvider = await (from a in CreditContext.Provider
                                      where a.ProviderNo == providerNo
                                      select a).SingleOrDefaultAsync();
            if (updateProvider != null)
            {
                updateProvider.RegionNo = provider.RegionNo;
                updateProvider.ProviderNo = provider.ProviderNo;
                updateProvider.ProviderName = provider.ProviderName;
                updateProvider.Street = provider.Street;
                updateProvider.City = provider.City;
                updateProvider.StateProv = provider.StateProv;
                updateProvider.PhoneNo = provider.PhoneNo;
                updateProvider.MailCode = "33333";
                updateProvider.IssueDt = DateTime.Now;
                updateProvider.Country = provider.Country;
                updateProvider.ProviderCode = provider.ProviderCode;

                CreditContext.Update(updateProvider);
                return 1;
            }
            else
            {
                return -1;
            }
        }

        public async Task<int> AddProviderAsync(Provider provider)
        {
            provider.ProviderNo = 0;
            provider.MailCode = "33333";
            provider.IssueDt = DateTime.Now;
            provider.ExprDt = DateTime.Now.AddYears(10);

            var result = await (from a in CreditContext.Provider
                                      where a.ProviderName == provider.ProviderName
                                            && a.RegionNo == provider.RegionNo
                                            && a.Street == provider.Street
                                select a).SingleOrDefaultAsync();
            if (result == null)
            {
                var add = CreditContext.Provider.Add(provider);
                if (add != null)
                {
                    return 1;
                }
            }

            return -1;
        }

        public async Task<int> DeleteProviderByIdAsync(int providerNo)
        {
            var providerCategory = await (from a in CreditContext.Provider
                                        where a.ProviderNo == providerNo
                                        select a).SingleOrDefaultAsync();

            if (providerCategory != null)
            {
                var deleted = CreditContext.Remove(providerCategory);
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
