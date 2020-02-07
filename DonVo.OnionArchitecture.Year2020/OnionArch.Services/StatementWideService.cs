using OnionArch.Domain.Entities;
using OnionArch.Domain.Interfaces;
using OnionArch.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnionArch.Services
{
    public class StatementWideService : IStatementWideService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StatementWideService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<StatementWide>> GetAllStatementWides()
        {
            return await _unitOfWork.StatementWides.GetAllStatementWidesAsync();
        }

        public async Task<StatementWide> GetStatementWideById(int statementNo)
        {
            return await _unitOfWork.StatementWides.GetStatementWideByIdAsync(statementNo);
        }

        public async Task<IEnumerable<StatementWide>> GetStatementWidesByMember(int memberNo)
        {
            return await _unitOfWork.StatementWides.GetStatementWidesByMemberAsync(memberNo);
        }

        public async Task<IEnumerable<StatementWide>> GetStatementWidesByRegion(int regionNo)
        {
            return await _unitOfWork.StatementWides.GetStatementWidesByRegionAsync(regionNo);
        }
    }
}
