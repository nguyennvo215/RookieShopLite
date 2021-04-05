using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RookieShopLite.Areas.Admin.Models;
using RookieShopLite.Data;
using RookieShopLite.Model;
using RookieShopLite.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RookieShopLite.Areas.Admin.Apis
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<ProductViewModel>>> GetProducts()
        {
            return await _context.Products
                .Where(x => x.isDeleted == false)
                .Select(x => new ProductViewModel 
                { 
                    Id = x.Id,
                    ProductName = x.ProductName,
                    BrandId = x.BrandId,
                    CategoryId = x.CategoryId,
                    ProductShortDescription = x.ProductShortDescription,
                    ProductFullDescription = x.ProductFullDescription,
                    ProductPriceNow = x.ProductPriceNow,
                    ProductPriceBefore = x.ProductPriceBefore
                })
                .ToListAsync();
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<ProductViewModel>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null || product.isDeleted == true)
            {
                return NotFound();
            }

            var productViewModel = new ProductViewModel
            {
                Id = product.Id,
                ProductName = product.ProductName,
                BrandId = product.BrandId,
                CategoryId = product.CategoryId,
                ProductShortDescription = product.ProductShortDescription,
                ProductFullDescription = product.ProductFullDescription,
                ProductPriceNow = product.ProductPriceNow,
                ProductPriceBefore = product.ProductPriceBefore
            };

            return productViewModel;
        }

        [HttpPut("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<ProductViewModel>> PutProduct(int id, ProductCreateRequest productCreateRequest)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null || product.isDeleted == true)
            {
                return NotFound();
            }

            product.ProductName = productCreateRequest.ProductName;
            product.ProductShortDescription = productCreateRequest.ProductShortDescription;
            product.ProductFullDescription = productCreateRequest.ProductFullDescription;
            product.ProductPriceNow = productCreateRequest.ProductPriceNow;
            product.CategoryId = productCreateRequest.CategoryId;
            product.BrandId = productCreateRequest.BrandId;
            product.AddedDate = DateTime.Now;
            product.AddedBy = HttpContext.User.Identity.Name;
            await _context.SaveChangesAsync();

            var productViewModel = new ProductViewModel
            {
                Id = product.Id,
                ProductName = product.ProductName,
                ProductShortDescription = product.ProductShortDescription,
                ProductFullDescription = product.ProductFullDescription,
                ProductPriceNow = product.ProductPriceNow,
                ProductPriceBefore = productCreateRequest.ProductPriceBefore,
                CategoryId = product.CategoryId,
                BrandId = product.BrandId
            };

            return productViewModel;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<ProductViewModel>> PostProduct(ProductCreateRequest productCreateRequest)
        {
            var product = new Product
            {
                ProductName = productCreateRequest.ProductName,
                ProductShortDescription = productCreateRequest.ProductShortDescription,
                ProductFullDescription = productCreateRequest.ProductFullDescription,
                ProductPriceNow = productCreateRequest.ProductPriceNow,
                CategoryId = productCreateRequest.CategoryId,
                BrandId = productCreateRequest.BrandId,
                AddedDate = DateTime.Now,
                AddedBy = HttpContext.User.Identity.Name
                
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBrand", new { id = product.Id },
                new ProductViewModel 
                {
                    Id = product.Id,
                    ProductName = product.ProductName,
                    ProductShortDescription = product.ProductShortDescription,
                    ProductFullDescription = product.ProductFullDescription,
                    ProductPriceNow = product.ProductPriceNow,
                    ProductPriceBefore = productCreateRequest.ProductPriceBefore,
                    CategoryId = product.CategoryId,
                    BrandId = product.BrandId
                });
        }

        [HttpDelete("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null || product.isDeleted == true)
            {
                return NotFound();
            }

            product.isDeleted = true;
            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
