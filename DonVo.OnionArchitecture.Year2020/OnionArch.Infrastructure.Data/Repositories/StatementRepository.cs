using OnionArch.Domain.Entities;
using OnionArch.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnionArch.Infrastructure.Data.Repositories
{
    public class StatementRepository : Repository<Statement>, IStatementRepository
    {
        public StatementRepository(CreditContext context) : base(context) { }
    }
}
