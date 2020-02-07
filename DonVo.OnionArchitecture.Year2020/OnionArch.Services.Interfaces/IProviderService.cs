using OnionArch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnionArch.Services.Interfaces
{
    public interface IProviderService
    {
        Task<IEnumerable<Provider>> GetAllProviders();
        Task<Provider> GetProviderById(int providerNo);
        Task<IEnumerable<Provider>> GetProvidersByRegion(int regionNo);
        Task<int> UpdateProvider(Provider provider, int providerNo);
        Task<int> AddProvider(Provider provider);
        Task<int> DeleteProviderById(int providerNo);
    }
}
