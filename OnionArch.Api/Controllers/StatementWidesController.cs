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
    public class StatementWides : ControllerBase
    {
        private readonly IStatementWideService _statementWideService;

        public StatementWides(IStatementWideService statementWideService)
        {
            _statementWideService = statementWideService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<StatementWide>>> GetAllStatementWides()
        {
            var statementWides = await _statementWideService.GetAllStatementWides();         
            return Ok(statementWides);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StatementWide>> GetStatementWideById(int id)
        {
            var statementWide = await _statementWideService.GetStatementWideById(id);
            return Ok(statementWide);
        }

        [HttpGet("Members")]
        public async Task<ActionResult<StatementWide>> GetStatementWidesByMember(int memberNo)
        {
            var statementWides = await _statementWideService.GetStatementWidesByMember(memberNo);
            return Ok(statementWides);
        }

        [HttpGet("Regions")]
        public async Task<ActionResult<StatementWide>> GetStatementWidesByRegion(int regionNo)
        {
            var statementWides = await _statementWideService.GetStatementWidesByRegion(regionNo);
            return Ok(statementWides);
        }
    }
}
