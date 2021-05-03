using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RookieShopLite.Areas.Admin.Models;
using RookieShopLite.Data;
using RookieShopLite.Model;
using RookieShopLite.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace RookieShopLite.Areas.Admin.Apis
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;


        public CategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<CategoryViewModel>>> GetCategories()
        {
            return await _context.Categories
                .Where(x => x.isDeleted == false)
                .Select(x => new CategoryViewModel { Id = x.Id, CategoryName = x.CategoryName, CategoryDescription = x.CategoryDescription })
                .ToListAsync();
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<CategoryViewModel>> GetCategories(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null || category.isDeleted == true)
            {
                return NotFound();
            }

            var categoryViewModel = new CategoryViewModel
            {
                Id = category.Id,
                CategoryName = category.CategoryName,
                CategoryDescription = category.CategoryDescription
            };

            return categoryViewModel;
        }

        [HttpPut("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> PutCategory(int id, CategoryCreateRequest categoryCreateRequest)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null || category.isDeleted == true)
            {
                return NotFound();
            }

            category.CategoryName = categoryCreateRequest.CategoryName;
            category.CategoryDescription = categoryCreateRequest.CategoryDescription;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<CategoryViewModel>> PostCategory(CategoryCreateRequest categoryCreateRequest)
        {
            var category = new Category
            {
                CategoryName = categoryCreateRequest.CategoryName,
                CategoryDescription = categoryCreateRequest.CategoryDescription
            };

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategory", new { id = category.Id }, new CategoryViewModel { Id = category.Id, CategoryName = category.CategoryName });
        }

        [HttpDelete("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null || category.isDeleted == true)
            {
                return NotFound();
            }

            category.isDeleted = true;
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
