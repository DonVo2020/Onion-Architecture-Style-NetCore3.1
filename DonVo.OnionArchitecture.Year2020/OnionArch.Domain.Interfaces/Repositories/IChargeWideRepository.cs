using OnionArch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnionArch.Domain.Interfaces.Repositories
{
    public interface IChargeWideRepository : IRepository<ChargeWide>
    {
        Task<IEnumerable<ChargeWide>> GetAllChargeWidesAsync();
        Task<IEnumerable<ChargeWide>> GetChargeWidesByMemberNoAsync(int memberNo);
        Task<IEnumerable<ChargeWide>> GetChargeWidesByCategoryAndRegionAsync(int categoryNo, int regionNo);
    }
}
