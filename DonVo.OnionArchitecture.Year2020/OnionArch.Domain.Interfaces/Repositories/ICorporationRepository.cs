using OnionArch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnionArch.Domain.Interfaces.Repositories
{
    public interface ICorporationRepository : IRepository<Corporation>
    {
        Task<IEnumerable<Corporation>> GetAllCorporationsAsync();
        Task<Corporation> GetCorporationByIdAsync(int corpNo);
        Task<IEnumerable<Corporation>> GetCorporationsByRegionIdAsync(int regionNo);
        Task<IEnumerable<Corporation>> FindCorporationsContainMembersAsync();

        Task<int> UpdateCorporationAsync(Corporation corp, int corpNo);
    }
}
