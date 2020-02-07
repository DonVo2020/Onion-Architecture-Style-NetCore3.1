using OnionArch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnionArch.Domain.Interfaces.Repositories
{
    public interface IRegionRepository : IRepository<Region>
    {
        Task<IEnumerable<Region>> GetAllRegionsAsync();
        Task<Region> GetRegionByIdAsync(int regionNo);
        Task<int> UpdateRegionAsync(Region region, int regionNo);
    }
}
