using OnionArch.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnionArch.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBasicMemberRepository BasicMembers { get; }
        ICorporationRepository Corporations { get; }
        ICategoryRepository Categories { get; }
        IOverdueRepository Overdues { get; }
        IChargeWideRepository ChargeWides { get; }
        IPaymentWideRepository PaymentWides { get; }
        IRegionRepository Regions { get; }
        IProviderRepository Providers { get; }
        IStatementWideRepository StatementWides { get; }

        Task<int> CommitAsync();
    }
}
