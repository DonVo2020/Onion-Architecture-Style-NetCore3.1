using OnionArch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnionArch.Services.Interfaces
{
    public interface IChargeWideService
    {
        Task<IEnumerable<ChargeWide>> GetAllChargeWides();
        Task<IEnumerable<ChargeWide>> GetChargeWidesByMemberNo(int memberNo);
        Task<IEnumerable<ChargeWide>> GetChargeWidesByCategoryAndRegion(int categoryNo, int regionNo);
    }
}
