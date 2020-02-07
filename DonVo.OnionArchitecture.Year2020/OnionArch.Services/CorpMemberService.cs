using OnionArch.Domain.Entities;
using OnionArch.Domain.Interfaces;
using OnionArch.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnionArch.Services
{
    public class CorpMemberService : ICorpMemberService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CorpMemberService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
