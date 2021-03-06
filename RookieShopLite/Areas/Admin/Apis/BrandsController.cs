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
    public class BrandsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BrandsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<BrandViewModel>>> GetBrands()
        {
            return await _context.Brands
                .Where(x => x.isDeleted == false)
                .Select(x => new BrandViewModel { Id = x.Id, BrandName = x.BrandName, BrandDescription = x.BrandDescription })
                .ToListAsync();
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<BrandViewModel>> GetBrand(int id)
        {
            var brand = await _context.Brands.FindAsync(id);

            if (brand == null || brand.isDeleted == true)
            {
                return NotFound();
            }

            var brandViewModel = new BrandViewModel
            {
                Id = brand.Id,
                BrandName = brand.BrandName,
                BrandDescription = brand.BrandDescription
            };

            return brandViewModel;
        }

        [HttpPut("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<BrandViewModel>> PutBrand(int id, BrandCreateRequest brandCreateRequest)
        {
            var brand = await _context.Brands.FindAsync(id);

            if (brand == null || brand.isDeleted == true)
            {
                return NotFound();
            }

            brand.BrandName = brandCreateRequest.BrandName;
            brand.BrandDescription = brandCreateRequest.BrandDescription;
            await _context.SaveChangesAsync();

            var brandViewModel = new BrandViewModel
            {
                Id = brand.Id,
                BrandName = brand.BrandName,
                BrandDescription = brand.BrandDescription
            };

            return brandViewModel;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<BrandViewModel>> PostBrand(BrandCreateRequest brandCreateRequest)
        {
            var brand = new Brand
            {
                BrandName = brandCreateRequest.BrandName,
                BrandDescription = brandCreateRequest.BrandDescription,
                isDeleted = false
            };

            _context.Brands.Add(brand);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBrand", new { id = brand.Id }, new BrandViewModel { Id = brand.Id, BrandName = brand.BrandName });
        }

        [HttpDelete("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteBrand(int id)
        {
            var brand = await _context.Brands.FindAsync(id);
            if (brand == null || brand.isDeleted == true)
            {
                return NotFound();
            }

            brand.isDeleted = true;
            _context.Brands.Update(brand);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
