using ChineseAuction.Dtos;
using ChineseAuction.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChineseAuction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        // Controller methods for handling HTTP requests related to Category entity

        // Get all categories
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            try
            {
                var categories = await _categoryService.GetAllCategoriesAsync();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                //שליחת האקספשין ללוגר כאן
                return BadRequest("Internal server error occurred.");
            }
        }

        // Get category by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            try
            {
                var category = await _categoryService.GetCategoryByIdAsync(id);
                if (category == null) return NotFound("The id:" + id + " ,did not found🤚");
                return Ok(category);
            }
            catch (Exception ex)
            {
                //שליחת האקספשין ללוגר כאן
                return BadRequest("Internal server error occurred.");
            }
        }

        // Add new category
        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] CategoryDto createCategoryDto)
        {
            try
            {
                GetCategoryDto category = await _categoryService.AddCategoryAsync(createCategoryDto);
                return CreatedAtAction(nameof(GetCategoryById), new { id = category.Id }, category);
            }
            catch (Exception ex)
            {
                //שליחת האקספשין ללוגר כאן
                return BadRequest(ex.Message);
            }
        }
        // Update category
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] CategoryDto updateCategoryDto)
        {
            try
            {
                var updatedCategory = await _categoryService.UpdateCategoryAsync(id, updateCategoryDto);
                if (updatedCategory == null) return NotFound();
                return Ok(updatedCategory);
            }
            catch (Exception ex)
            {
                //שליחת האקספשין ללוגר כאן
                return BadRequest(ex.Message);
            }
        }
        // Delete category
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            try
            {
                var isDeleted = await _categoryService.DeleteCategoryAsync(id);
                if (!isDeleted) return NotFound("The id:" + id + " ,did not found🤚");
                return Ok("Category deleted successfully.");
            }
            catch (Exception ex)
            {
                //שליחת האקספשין ללוגר כאן
                return BadRequest("Internal server error occurred.");
            }
        }
    }
}
