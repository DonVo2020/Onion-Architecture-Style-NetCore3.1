using OnionArch.Domain.Interfaces;
using OnionArch.Services.Interfaces;

namespace OnionArch.Services
{
    public class StatusService : IStatusService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StatusService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
