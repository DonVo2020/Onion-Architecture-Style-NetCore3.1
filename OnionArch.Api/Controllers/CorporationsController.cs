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
    public class CorporationsController : ControllerBase
    {
        private readonly ICorporationService _corporationService;

        public CorporationsController(ICorporationService corporationService)
        {
            _corporationService = corporationService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Corporation>>> GetAllCorporations()
        {
            var corporations = await _corporationService.GetAllCorporations();        
            return Ok(corporations);
        }

        [HttpGet("Corporations2")]
        public async Task<ActionResult<IEnumerable<Corporation>>> FindCorporationsContainMembers()
        {
            var corporations = await _corporationService.FindCorporationsContainMembers();
            return Ok(corporations);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Corporation>> GetCorporationById(int id)
        {
            var corporation = await _corporationService.GetCorporationById(id);
            return Ok(corporation);
        }

        [HttpGet("Regions/{id}")]
        public async Task<ActionResult<IEnumerable<Corporation>>> GetCorporationsByRegionId(int id)
        {
            var corporations = await _corporationService.GetCorporationsByRegionId(id);
            return Ok(corporations);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCorporation(int id, [FromBody] Corporation corpData)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int result = await _corporationService.UpdateCorporation(corpData, id);
                    if (result == 1)
                    {
                        return Created("UpdatedCorporation", null);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return BadRequest(ModelState);
        }
    }
}
