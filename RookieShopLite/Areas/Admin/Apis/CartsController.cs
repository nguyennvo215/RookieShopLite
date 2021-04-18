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

        //[HttpGet]
        //[AllowAnonymous]
        //public async Task<ActionResult<IEnumerable<CartViewModel>>> GetCartHistory()
        //{
        //    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //    //var getCart = from s in _context.Carts
        //    //              .Where(c => c.UserId == ClaimTypes.Name && c.isCheckedOut == true)
        //    //              select s;
        //    return await _context.Carts
        //        .Include("CartProduct")
        //        .Where(c => c.UserId == userId && c.isCheckedOut == true)
        //        .Select(x => new CartViewModel
        //        {
        //            Id = x.Id,
        //            UserId = x.UserId,
        //            ProductLists = x.Products.Select(p => new CartProductViewModel
        //            {
        //                CartId = x.Id,
        //                Id = p.Id,
        //                imgPath = p.ProductImages.ToString(),
        //                ProductName = p.ProductName,
        //                ProductPriceNow = p.ProductPriceNow,
        //                ProductPriceBefore = p.ProductPriceBefore
        //            }).ToList()
        //        }).ToListAsync();
        //}

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<CartViewModel>> GetCurrentCart()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var getCart = await _context.Carts.FirstOrDefaultAsync(x => x.UserId == userId && x.isCheckedOut == false);
            if(getCart == null)
            {
                var newCart = new Cart
                {
                    UserId = userId,
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
                return new CartViewModel
                {
                    Id = getCart.Id,
                    UserId = userId,
                    ProductLists = getCart.Products.Select(p => new CartProductViewModel
                    {
                        CartId = getCart.Id,
                        Id = p.Id,
                        imgPath = p.ProductImages.FirstOrDefault().ToString(),
                        ProductName = p.ProductName,
                        ProductPriceNow = p.ProductPriceNow,
                        ProductPriceBefore = p.ProductPriceBefore
                    }).ToList()
                };
            }            
            
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
