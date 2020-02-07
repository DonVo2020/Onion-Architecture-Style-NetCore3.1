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
    public class RegionsController : ControllerBase
    {
        private readonly IRegionService _regionService;

        public RegionsController(IRegionService regionService)
        {
            _regionService = regionService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Region>>> GetAllRegions()
        {
            var regions = await _regionService.GetAllRegions();         
            return Ok(regions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Region>> GetRegionById(int id)
        {
            var region = await _regionService.GetRegionById(id);
            return Ok(region);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRegion(int id, [FromBody] Region regionData)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int result = await _regionService.UpdateRegion(regionData, id);
                    if (result == 1)
                    {
                        return Created("UpdatedRegion", null);
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
