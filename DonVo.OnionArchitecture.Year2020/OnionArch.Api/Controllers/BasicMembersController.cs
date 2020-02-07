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
    public class BasicMembersController : ControllerBase
    {
        private readonly IBasicMemberService _basicMemberService;

        public BasicMembersController(IBasicMemberService basicMemberService)
        {
            _basicMemberService = basicMemberService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<BasicMember>>> GetAllBasicMembers()
        {
            try
            {
                var basicMembers = await _basicMemberService.GetAllBasicMembers();
                return Ok(basicMembers);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BasicMember>> GetBasicMemberById(int id)
        {
            var basicMember = await _basicMemberService.GetBasicMemberById(id);
            return Ok(basicMember);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBasicMember(int id, [FromBody] Member memberData)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int result = await _basicMemberService.UpdateBasicMember(memberData, id);
                    if (result == 1)
                    {
                        return Created("UpdatedMember", null);
                    }
                }
                catch(Exception ex)
                {
                    throw ex;
                }                
            }
            return BadRequest(ModelState);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Member memberData)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int result = await _basicMemberService.AddBasicMember(memberData);
                    if (result == 1)
                    {
                        return Created("CreateMember", memberData);
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
        public async Task<IActionResult> DeleteBasicMemberById(int id)
        {
            try
            {
                var result = await _basicMemberService.DeleteBasicMemberById(id);
                if(result == 1)
                    return Created("DeleteMember", id);
                else
                    return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
