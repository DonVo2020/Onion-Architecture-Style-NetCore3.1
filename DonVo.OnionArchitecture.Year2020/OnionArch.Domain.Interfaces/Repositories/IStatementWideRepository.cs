using OnionArch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnionArch.Domain.Interfaces.Repositories
{
    public interface IStatementWideRepository : IRepository<StatementWide>
    {
        Task<IEnumerable<StatementWide>> GetAllStatementWidesAsync();
        Task<StatementWide> GetStatementWideByIdAsync(int statementNo);
        Task<IEnumerable<StatementWide>> GetStatementWidesByMemberAsync(int memberNo);
        Task<IEnumerable<StatementWide>> GetStatementWidesByRegionAsync(int regionNo);
    }
}
