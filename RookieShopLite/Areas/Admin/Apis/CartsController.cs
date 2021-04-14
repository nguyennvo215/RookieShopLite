using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RookieShopLite.Areas.Admin.ApiServices.Product;
using RookieShopLite.Data;
using RookieShopLite.Model;
using RookieShopLite.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RookieShopLite.Areas.Admin.Apis
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IProductApiService _product;

        public CartsController(ApplicationDbContext context, IProductApiService product)
        {
            _context = context;
            _product = product;
        }

        public async Task<ActionResult<IEnumerable<CartViewModel>>> GetCartHistory()
        {
            //var getCart = from s in _context.Carts
            //              .Where(c => c.UserId == ClaimTypes.Name && c.isCheckedOut == true)
            //              select s;
            return await _context.Carts
                .Include("CartProduct")
                .Where(c => c.UserId == ClaimTypes.NameIdentifier && c.isCheckedOut == true)
                .Select(x => new CartViewModel
                {
                    Id = x.Id,
                    UserId = x.UserId,
                    ProductLists = x.Products.Select(p => new CartProductViewModel
                    {
                        CartId = x.Id,
                        Id = p.Id,
                        imgPath = p.ProductImages.ToString(),
                        ProductName = p.ProductName,
                        ProductPriceNow = p.ProductPriceNow,
                        ProductPriceBefore = p.ProductPriceBefore
                    }).ToList()
                }).ToListAsync();
        }

        public async Task<ActionResult<CartViewModel>> GetCurrentCart()
        {            
            var getCart = await _context.Carts.FirstOrDefaultAsync(x => x.UserId == ClaimTypes.NameIdentifier && x.isCheckedOut == false);
            if(getCart == null)
            {
                var newCart = new Cart
                {
                    UserId = ClaimTypes.NameIdentifier,
                    AddedDate = DateTime.Now,
                    isCheckedOut = false
                };

                _context.Carts.Add(newCart);
                await _context.SaveChangesAsync();

                var cart = new CartViewModel
                {
                    Id = newCart.Id,
                    UserId = newCart.UserId,
                };
                return cart;
            } 
            else
            {
                var cart = new CartViewModel
                {
                    Id = getCart.Id,
                    UserId = ClaimTypes.NameIdentifier,
                    ProductLists = getCart.Products.Select(p => new CartProductViewModel
                    {
                        CartId = getCart.Id,
                        Id = p.Id,
                        imgPath = p.ProductImages.ToString(),
                        ProductName = p.ProductName,
                        ProductPriceNow = p.ProductPriceNow,
                        ProductPriceBefore = p.ProductPriceBefore
                    }).ToList()
                };
                return cart;
            }            
            
        }

        [HttpPost("{Id}")]
        [AllowAnonymous]
        public async Task<IActionResult> AddToCart(int id)
        {
            var product = await _product.GetProduct(id);
            var cart = GetCurrentCart();

            foreach (var p in product)
            {
                var cartProduct = new CartProduct
                {
                    CartId = cart.Id,
                    ProductName = p.ProductName,
                    Id = p.Id,
                    ProductPriceNow = p.ProductPriceNow,
                    ProductPriceBefore = p.ProductPriceBefore,
                    imgPath = p.images.FirstOrDefault().ToString(),
                };

                _context.CartProducts.Add(cartProduct);
                await _context.SaveChangesAsync();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> CheckoutCart(int id)
        {
            var cart = await _context.Carts.FindAsync(id);
            if (cart == null || cart.isCheckedOut == true)
            {
                return NotFound();
            }

            cart.isCheckedOut = true;
            _context.Carts.Update(cart);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
