using OnionArch.Domain.Entities;
using OnionArch.Domain.Interfaces;
using OnionArch.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnionArch.Services
{
    public class PaymentWideService : IPaymentWideService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PaymentWideService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<PaymentWide>> GetAllPaymentWides()
        {
            return await _unitOfWork.PaymentWides.GetAllPaymentWidesAsync();
        }

        public async Task<PaymentWide> GetPaymentWidesByPaymentNo(int paymentNo)
        {
            return await _unitOfWork.PaymentWides.GetPaymentWideByIdAsync(paymentNo);
        }

        public async Task<IEnumerable<PaymentWide>> GetPaymentWidesByMemberNo(int memberNo)
        {
            return await _unitOfWork.PaymentWides.GetPaymentWidesByMemberNoAsync(memberNo);
        }

        public async Task<IEnumerable<PaymentWide>> GetPaymentWidesByRegion(int regionNo)
        {
            return await _unitOfWork.PaymentWides.GetPaymentWidesByRegionAsync(regionNo);
        }
    }
}
