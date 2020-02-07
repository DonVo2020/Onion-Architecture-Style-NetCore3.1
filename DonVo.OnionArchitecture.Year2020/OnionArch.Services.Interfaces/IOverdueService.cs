using OnionArch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnionArch.Services.Interfaces
{
    public interface IOverdueService
    {
        Task<IEnumerable<Overdue>> GetAllOverdues();
        Task<IEnumerable<Overdue>> GetOverduesByMemberNo(int memberNo);
    }
}
