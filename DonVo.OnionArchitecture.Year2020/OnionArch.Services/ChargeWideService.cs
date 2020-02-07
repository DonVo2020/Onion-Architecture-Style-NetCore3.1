using OnionArch.Domain.Entities;
using OnionArch.Domain.Interfaces;
using OnionArch.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnionArch.Services
{
    public class ChargeWideService : IChargeWideService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ChargeWideService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ChargeWide>> GetAllChargeWides()
        {
            return await _unitOfWork.ChargeWides.GetAllChargeWidesAsync();
        }

        public async Task<IEnumerable<ChargeWide>> GetChargeWidesByMemberNo(int memberNo)
        {
            return await _unitOfWork.ChargeWides.GetChargeWidesByMemberNoAsync(memberNo);
        }

        public async Task<IEnumerable<ChargeWide>> GetChargeWidesByCategoryAndRegion(int categoryNo, int regionNo)
        {
            return await _unitOfWork.ChargeWides.GetChargeWidesByCategoryAndRegionAsync(categoryNo,regionNo);
        }
    }
}
