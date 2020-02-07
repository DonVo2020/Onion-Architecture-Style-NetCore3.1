using OnionArch.Domain.Entities;
using OnionArch.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnionArch.Infrastructure.Data.Repositories
{
    public class PaymentRepository : Repository<Payment>, IPaymentRepository
    {
        public PaymentRepository(CreditContext context) : base(context) { }
    }
}
