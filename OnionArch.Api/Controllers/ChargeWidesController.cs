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
    public class ChargeWidesController : ControllerBase
    {
        private readonly IChargeWideService _chargeWideService;

        public ChargeWidesController(IChargeWideService chargeWideService)
        {
            _chargeWideService = chargeWideService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<ChargeWide>>> GetAllChargeWides()
        {
            var chargeWides = await _chargeWideService.GetAllChargeWides();         
            return Ok(chargeWides);
        }

        [HttpGet("{memberNo}")]
        public async Task<ActionResult<ChargeWide>> GetChargeWidesByMemberNo(int memberNo)
        {
            var chargeWides = await _chargeWideService.GetChargeWidesByMemberNo(memberNo);
            return Ok(chargeWides);
        }

        [HttpGet("{categoryNo}/{regionNo}")]
        public async Task<ActionResult<ChargeWide>> GetChargeWidesByCategoryAndRegion(int categoryNo, int regionNo)
        {
            var chargeWides = await _chargeWideService.GetChargeWidesByCategoryAndRegion(categoryNo, regionNo);
            return Ok(chargeWides);
        }
    }
}
