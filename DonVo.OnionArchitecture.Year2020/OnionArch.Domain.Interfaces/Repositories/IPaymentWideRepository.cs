using OnionArch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnionArch.Domain.Interfaces.Repositories
{
    public interface IPaymentWideRepository : IRepository<PaymentWide>
    {
        Task<IEnumerable<PaymentWide>> GetAllPaymentWidesAsync();
        Task<PaymentWide> GetPaymentWideByIdAsync(int paymentNo);
        Task<IEnumerable<PaymentWide>> GetPaymentWidesByMemberNoAsync(int memberNo);
        Task<IEnumerable<PaymentWide>> GetPaymentWidesByRegionAsync(int regionNo);
    }
}
