using OnionArch.Domain.Entities;
using OnionArch.Domain.Interfaces;
using OnionArch.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnionArch.Services
{
    public class CorporationService : ICorporationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CorporationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Corporation>> GetAllCorporations()
        {
            return await _unitOfWork.Corporations.GetAllCorporationsAsync();
        }

        public async Task<Corporation> GetCorporationById(int corpNo)
        {
            return await _unitOfWork.Corporations.GetCorporationByIdAsync(corpNo);
        }

        public async Task<IEnumerable<Corporation>> GetCorporationsByRegionId(int regionNo)
        {
            return await _unitOfWork.Corporations.GetCorporationsByRegionIdAsync(regionNo);
        }

        public async Task<IEnumerable<Corporation>> FindCorporationsContainMembers()
        {
            return await _unitOfWork.Corporations.FindCorporationsContainMembersAsync();
        }

        public async Task<int> UpdateCorporation(Corporation corp, int corpNo)
        {
            await _unitOfWork.Corporations.UpdateCorporationAsync(corp, corpNo);
            return await _unitOfWork.CommitAsync();
        }
    }
}
