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
    public class OverduesController : ControllerBase
    {
        private readonly IOverdueService _overdueService;

        public OverduesController(IOverdueService overdueService)
        {
            _overdueService = overdueService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Overdue>>> GetAllOverdues()
        {
            var overdues = await _overdueService.GetAllOverdues();         
            return Ok(overdues);
        }

        [HttpGet("{memberNo}")]
        public async Task<ActionResult<Overdue>> GetOverduesByMemberNo(int memberNo)
        {
            var overdues = await _overdueService.GetOverduesByMemberNo(memberNo);
            return Ok(overdues);
        }
    }
}
