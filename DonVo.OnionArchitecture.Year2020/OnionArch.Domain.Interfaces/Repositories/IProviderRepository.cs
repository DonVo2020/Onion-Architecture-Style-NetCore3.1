using OnionArch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnionArch.Domain.Interfaces.Repositories
{
    public interface IProviderRepository : IRepository<Provider>
    {
        Task<IEnumerable<Provider>> GetAllProvidersAsync();
        Task<Provider> GetProviderByIdAsync(int providerNo);
        Task<IEnumerable<Provider>> GetProvidersByRegionAsync(int regionNo);
        Task<int> UpdateProviderAsync(Provider provider, int providerNo);
        Task<int> AddProviderAsync(Provider provider);
        Task<int> DeleteProviderByIdAsync(int providerNo);
    }
}
