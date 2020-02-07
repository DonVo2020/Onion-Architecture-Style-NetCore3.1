using OnionArch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnionArch.Services.Interfaces
{
    public interface IPaymentWideService
    {
        Task<IEnumerable<PaymentWide>> GetAllPaymentWides();
        Task<PaymentWide> GetPaymentWidesByPaymentNo(int paymentNo);
        Task<IEnumerable<PaymentWide>> GetPaymentWidesByMemberNo(int memberNo);
        Task<IEnumerable<PaymentWide>> GetPaymentWidesByRegion(int regionNo);
    }
}
