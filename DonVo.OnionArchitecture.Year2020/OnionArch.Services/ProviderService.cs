using OnionArch.Domain.Entities;
using OnionArch.Domain.Interfaces;
using OnionArch.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnionArch.Services
{
    public class ProviderService : IProviderService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProviderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Provider>> GetAllProviders()
        {
            return await _unitOfWork.Providers.GetAllProvidersAsync();
        }

        public async Task<Provider> GetProviderById(int providerNo)
        {
            return await _unitOfWork.Providers.GetProviderByIdAsync(providerNo);
        }

        public async Task<IEnumerable<Provider>> GetProvidersByRegion(int regionNo)
        {
            return await _unitOfWork.Providers.GetProvidersByRegionAsync(regionNo);
        }

        public async Task<int> UpdateProvider(Provider provider, int providerNo)
        {
            await _unitOfWork.Providers.UpdateProviderAsync(provider, providerNo);
            return await _unitOfWork.CommitAsync();
        }

        public async Task<int> AddProvider(Provider provider)
        {
            await _unitOfWork.Providers.AddProviderAsync(provider);
            return await _unitOfWork.CommitAsync();
        }

        public async Task<int> DeleteProviderById(int providerNo)
        {
            await _unitOfWork.Providers.DeleteProviderByIdAsync(providerNo);
            return await _unitOfWork.CommitAsync();
        }
    }
}
