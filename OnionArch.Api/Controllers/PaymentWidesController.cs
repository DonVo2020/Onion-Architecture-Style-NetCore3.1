using Microsoft.AspNetCore.Mvc;
using OnionArch.Domain.Entities;
using OnionArch.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnionArch.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PaymentWidesController : ControllerBase
    {
        private readonly IPaymentWideService _paymentWideService;

        public PaymentWidesController(IPaymentWideService paymentWideService)
        {
            _paymentWideService = paymentWideService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<PaymentWide>>> GetAllPaymentWides()
        {
            var paymentWides = await _paymentWideService.GetAllPaymentWides();         
            return Ok(paymentWides);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentWide>> GetPaymentWidesById(int id)
        {
            var paymentWide = await _paymentWideService.GetPaymentWidesByPaymentNo(id);
            return Ok(paymentWide);
        }

        [HttpGet("Members")]
        public async Task<ActionResult<PaymentWide>> GetPaymentWidesByMemberNo(int memberNo)
        {
            var paymentWides = await _paymentWideService.GetPaymentWidesByMemberNo(memberNo);
            return Ok(paymentWides);
        }

        [HttpGet("Regions")]
        public async Task<ActionResult<PaymentWide>> GetPaymentWidesRegion(int regionNo)
        {
            var paymentWides = await _paymentWideService.GetPaymentWidesByRegion(regionNo);
            return Ok(paymentWides);
        }
    }
}
