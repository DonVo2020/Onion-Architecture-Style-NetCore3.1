using OnionArch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnionArch.Domain.Interfaces.Repositories
{
    public interface IOverdueRepository : IRepository<Overdue>
    {
        Task<IEnumerable<Overdue>> GetAllOverduesAsync();
        Task<IEnumerable<Overdue>> GetOverduesByMemberNoAsync(int memberNo);
    }
}
