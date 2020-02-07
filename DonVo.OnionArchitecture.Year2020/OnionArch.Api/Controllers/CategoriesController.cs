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
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Category>>> GetAllCategories()
        {
            var categories = await _categoryService.GetAllCategories();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategoryById(int id)
        {
            var category = await _categoryService.GetCategoryById(id);
            return Ok(category);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] Category categoryData)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int result = await _categoryService.UpdateCategory(categoryData, id);
                    if (result == 1)
                    {
                        return Created("UpdatedCategory", null);
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
        public async Task<IActionResult> Post([FromBody] Category categoryData)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int result = await _categoryService.AddCategory(categoryData);
                    if (result == 1)
                    {
                        return Created("CreateCategory", categoryData);
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
                var result = await _categoryService.DeleteCategoryById(id);
                if (result == 1)
                    return Created("DeleteCategory", id);
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
