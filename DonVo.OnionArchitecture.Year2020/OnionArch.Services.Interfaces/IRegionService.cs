using OnionArch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnionArch.Services.Interfaces
{
    public interface IRegionService
    {
        Task<IEnumerable<Region>> GetAllRegions();
        Task<Region> GetRegionById(int regionNo);
        Task<int> UpdateRegion(Region region, int regionNo);
    }
}
