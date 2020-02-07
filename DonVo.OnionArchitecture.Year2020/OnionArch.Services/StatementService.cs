using OnionArch.Domain.Entities;
using OnionArch.Domain.Interfaces;
using OnionArch.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnionArch.Services
{
    public class StatementService : IStatementService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StatementService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
