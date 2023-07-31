using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopsRU.Application.Contract.Request.Category;
using ShopsRU.Application.Interfaces.Services;
using ShopsRU.Persistence.Implementations.Services;

namespace ShopsRU.Host.Controllers
{
    
    [Route("api/")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        [Route("category")]
        public async Task<IActionResult> CreateAsync(CreateCategoryRequest createCategoryRequest)
        {
            var response = await _categoryService.CreateAsync(createCategoryRequest);
            return Ok(response);
        }

        [HttpPut]
        [Route("category")]
        public async Task<IActionResult> UpdateAsync(UpdateCategoryRequest updateCategoryRequest)
        {
            var response = await _categoryService.UpdateAsync(updateCategoryRequest);
            return Ok(response);
        }
    }
}
