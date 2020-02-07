using Microsoft.AspNetCore.Mvc;
using OnionArch.Domain.Entities;
using OnionArch.Infrastructure.Data;
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
    public class ProvidersController : ControllerBase
    {
        private readonly IProviderService _providerService;

        public ProvidersController(IProviderService providerService)
        {
            _providerService = providerService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Provider>>> GetAllProviders()
        {
            var providers = await _providerService.GetAllProviders();         
            return Ok(providers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Provider>> GetProviderById(int id)
        {
            var provider = await _providerService.GetProviderById(id);
            return Ok(provider);
        }

        [HttpGet("Regions")]
        public async Task<ActionResult<IEnumerable<Provider>>> GetProvidersByRegion(int regionNo)
        {
            var providers = await _providerService.GetProvidersByRegion(regionNo);
            return Ok(providers);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProvider(int id, [FromBody] Provider providerData)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int result = await _providerService.UpdateProvider(providerData, id);
                    if (result == 1)
                    {
                        return Created("UpdatedProvider", null);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return BadRequest(ModelState);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Provider providerData)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int result = await _providerService.AddProvider(providerData);
                    if (result == 1)
                    {
                        return Created("CreateProvider", providerData);
                    }
                    else
                        return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError);
                }
                catch (Exception ex)
                {
                    throw ex;
                    //return BadRequest(new { Message = "Member was already existed." });
                    //return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError);
                }
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoryById(int id)
        {
            try
            {
                var result = await _providerService.DeleteProviderById(id);
                if (result == 1)
                    return Created("DeleteProvider", id);
                else
                    return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
