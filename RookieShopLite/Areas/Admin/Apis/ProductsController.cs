using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RookieShopLite.Areas.Admin.Models;
using RookieShopLite.Data;
using RookieShopLite.Model;
using RookieShopLite.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RookieShopLite.Areas.Admin.Apis
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ProductsController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<ProductViewModel>>> GetProducts()
        {
            return await _context.Products
                .Include("ProductImages")
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
                    ProductPriceBefore = x.ProductPriceBefore,
                    images = x.ProductImages.Select(u => u.imgPath).ToList()
                })
                .ToListAsync();
        }

        [HttpGet("categoryId={id}")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<ProductViewModel>>> GetProductsByCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null || category.isDeleted == true)
            {
                return NotFound();
            }

            return await _context.Products
                .Include("ProductImages")
                .Where(x => x.isDeleted == false && x.CategoryId == id)
                .Select(x => new ProductViewModel
                {
                    Id = x.Id,
                    ProductName = x.ProductName,
                    BrandId = x.BrandId,
                    CategoryId = x.CategoryId,
                    ProductShortDescription = x.ProductShortDescription,
                    ProductFullDescription = x.ProductFullDescription,
                    ProductPriceNow = x.ProductPriceNow,
                    ProductPriceBefore = x.ProductPriceBefore,
                    images = x.ProductImages.Select(u => u.imgPath).ToList()
                })
                .ToListAsync();
        }

        [HttpGet("brandId={id}")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<ProductViewModel>>> GetProductsByBrand(int id)
        {
            var category = await _context.Brands.FindAsync(id);

            if (category == null || category.isDeleted == true)
            {
                return NotFound();
            }

            return await _context.Products
                .Include("ProductImages")
                .Where(x => x.isDeleted == false && x.BrandId == id)
                .Select(x => new ProductViewModel
                {
                    Id = x.Id,
                    ProductName = x.ProductName,
                    BrandId = x.BrandId,
                    CategoryId = x.CategoryId,
                    ProductShortDescription = x.ProductShortDescription,
                    ProductFullDescription = x.ProductFullDescription,
                    ProductPriceNow = x.ProductPriceNow,
                    ProductPriceBefore = x.ProductPriceBefore,
                    images = x.ProductImages.Select(u => u.imgPath).ToList()
                })
                .ToListAsync();
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<ProductViewModel>>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            var products = await _context.Products.Include("ProductImages").ToListAsync();
            if (product == null || product.isDeleted == true)
            {
                return NotFound();
            }

            return await _context.Products
                .Include("ProductImages")
                .Where(x => x.isDeleted == false && x.Id == id)
                .Select(x => new ProductViewModel
                {
                    Id = x.Id,
                    ProductName = x.ProductName,
                    BrandId = x.BrandId,
                    CategoryId = x.CategoryId,
                    ProductShortDescription = x.ProductShortDescription,
                    ProductFullDescription = x.ProductFullDescription,
                    ProductPriceNow = x.ProductPriceNow,
                    ProductPriceBefore = x.ProductPriceBefore,
                    images = x.ProductImages.Select(u => u.imgPath).ToList(),
                    Ratings = x.Ratings.Select(r => new UserRatingViewModel
                    {
                        UserId = r.UserId,
                        UserName = r.UserName,
                        Rating = r.RatingNumber,
                        Content = r.Content
                    }).ToList()
                })
                .ToListAsync();

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
            product.isDeleted = false;
            await _context.SaveChangesAsync();

            if (productCreateRequest.ImgPath == null)
            {
                productCreateRequest.ImgPath = "";
            }

            var image = new ProductImage
            {
                imgPath = productCreateRequest.ImgPath,
                ProductId = product.Id,
                AddedDate = DateTime.Now,
                isDeleted = false
            };

            _context.Images.Add(image);
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
                ProductPriceBefore = productCreateRequest.ProductPriceBefore,
                CategoryId = productCreateRequest.CategoryId,
                BrandId = productCreateRequest.BrandId,
                AddedDate = DateTime.Now,
                AddedBy = HttpContext.User.Identity.Name,
                isDeleted = false                
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            if (productCreateRequest.ImgPath == null)
            {
                productCreateRequest.ImgPath = "";
            }                

            var image = new ProductImage
            {
                imgPath = productCreateRequest.ImgPath,
                ProductId = product.Id,
                AddedDate = DateTime.Now,
                isDeleted = false
            };

            _context.Images.Add(image);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.Id },
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
