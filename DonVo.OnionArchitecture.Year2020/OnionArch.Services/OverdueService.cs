using OnionArch.Domain.Entities;
using OnionArch.Domain.Interfaces;
using OnionArch.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnionArch.Services
{
    public class OverdueService : IOverdueService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OverdueService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Overdue>> GetAllOverdues()
        {
            return await _unitOfWork.Overdues.GetAllOverduesAsync();
        }

        public async Task<IEnumerable<Overdue>> GetOverduesByMemberNo(int memberNo)
        {
            return await _unitOfWork.Overdues.GetOverduesByMemberNoAsync(memberNo);
        }
    }
}
