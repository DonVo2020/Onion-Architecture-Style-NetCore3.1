using OnionArch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnionArch.Services.Interfaces
{
    public interface ICorporationService
    {
        Task<IEnumerable<Corporation>> GetAllCorporations();
        Task<Corporation> GetCorporationById(int memberNo);
        Task<IEnumerable<Corporation>> GetCorporationsByRegionId(int regionNo);
        Task<IEnumerable<Corporation>> FindCorporationsContainMembers();
        Task<int> UpdateCorporation(Corporation corp, int corpNo);
    }
}
