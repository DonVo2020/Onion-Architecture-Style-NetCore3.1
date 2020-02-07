using OnionArch.Domain.Entities;
using OnionArch.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace OnionArch.Infrastructure.Data.Repositories
{
    public class PaymentWideRepository : Repository<PaymentWide>, IPaymentWideRepository
    {
        public PaymentWideRepository(CreditContext context) : base(context) { }

        public async Task<IEnumerable<PaymentWide>> GetAllPaymentWidesAsync()
        {
            return await CreditContext.PaymentWide.ToListAsync();
        }

        public async Task<PaymentWide> GetPaymentWideByIdAsync(int paymentNo)
        {
            return await CreditContext.PaymentWide.SingleOrDefaultAsync(m => m.PaymentNo == paymentNo);
        }

        public async Task<IEnumerable<PaymentWide>> GetPaymentWidesByMemberNoAsync(int memberNo)
        {
            return await CreditContext.PaymentWide.Where(m => m.MemberNo == memberNo).ToListAsync();
        }

        public async Task<IEnumerable<PaymentWide>> GetPaymentWidesByRegionAsync(int regionNo)
        {
            return await CreditContext.PaymentWide
                .Where(m => m.RegionNo == regionNo).ToListAsync();
        }


        private CreditContext CreditContext
        {
            get { return Context as CreditContext; }
        }
    }
}
