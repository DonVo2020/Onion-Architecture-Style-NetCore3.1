using OnionArch.Domain.Interfaces;
using OnionArch.Domain.Interfaces.Repositories;
using OnionArch.Infrastructure.Data;
using OnionArch.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnionArch.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CreditContext _context;

        private BasicMemberRepository _basicMemberRepository;
        private CorporationRepository _corporationRepository;
        private CategoryRepository _categoryRepository;
        private OverdueRepository _overdueRepository;
        private ChargeWideRepository _chargeWideRepository;
        private PaymentWideRepository _paymentWideRepository;
        private RegionRepository _regionRepository;
        private ProviderRepository _providerRepository;
        private StatementWideRepository _statementWideRepository;

        public UnitOfWork(CreditContext context)
        {
            _context = context;
        }

        public IBasicMemberRepository BasicMembers => _basicMemberRepository ??= new BasicMemberRepository(_context);
        public ICorporationRepository Corporations => _corporationRepository ??= new CorporationRepository(_context);
        public ICategoryRepository Categories => _categoryRepository ??= new CategoryRepository(_context);
        public IOverdueRepository Overdues => _overdueRepository ??= new OverdueRepository(_context);
        public IChargeWideRepository ChargeWides => _chargeWideRepository ??= new ChargeWideRepository(_context);
        public IPaymentWideRepository PaymentWides => _paymentWideRepository ??= new PaymentWideRepository(_context);
        public IRegionRepository Regions => _regionRepository ??= new RegionRepository(_context);
        public IProviderRepository Providers => _providerRepository ??= new ProviderRepository(_context);
        public IStatementWideRepository StatementWides => _statementWideRepository ??= new StatementWideRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
