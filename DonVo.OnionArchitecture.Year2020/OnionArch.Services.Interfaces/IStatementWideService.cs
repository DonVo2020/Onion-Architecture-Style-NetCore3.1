using OnionArch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnionArch.Services.Interfaces
{
    public interface IStatementWideService
    {
        Task<IEnumerable<StatementWide>> GetAllStatementWides();
        Task<StatementWide> GetStatementWideById(int statementNo);
        Task<IEnumerable<StatementWide>> GetStatementWidesByMember(int memberNo);
        Task<IEnumerable<StatementWide>> GetStatementWidesByRegion(int regionNo);
    }
}
