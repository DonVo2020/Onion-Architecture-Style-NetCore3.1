using OnionArch.Domain.Entities;
using OnionArch.Domain.Interfaces;
using OnionArch.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnionArch.Services
{
    public class RegionService : IRegionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RegionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Region>> GetAllRegions()
        {
            return await _unitOfWork.Regions.GetAllRegionsAsync();
        }

        public async Task<Region> GetRegionById(int regionNo)
        {
            return await _unitOfWork.Regions.GetRegionByIdAsync(regionNo);
        }

        public async Task<int> UpdateRegion(Region region, int regionNo)
        {
            await _unitOfWork.Regions.UpdateRegionAsync(region, regionNo);
            return await _unitOfWork.CommitAsync();
        }
    }
}
