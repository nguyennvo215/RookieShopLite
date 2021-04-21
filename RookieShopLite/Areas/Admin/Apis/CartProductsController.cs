using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RookieShopLite.Areas.Admin.ApiServices.Cart;
using RookieShopLite.Areas.Admin.ApiServices.Product;
using RookieShopLite.Data;
using RookieShopLite.Model;
using RookieShopLite.ViewModel;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RookieShopLite.Areas.Admin.Apis
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartProductsController : ControllerBase
    {
        private readonly ICartApiService _cart;
        private readonly ApplicationDbContext _context;
        private readonly IProductApiService _product;

        public CartProductsController(ICartApiService cart, ApplicationDbContext context, IProductApiService product)
        {
            _context = context;
            _cart = cart;
            _product = product;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<CartViewModel>> GetCurrentCart()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var getCart = await _context.Carts.FirstOrDefaultAsync(x => x.UserId == userId && x.isCheckedOut == false);
            if (getCart == null)
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

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> AddProductToCart(int id)
        {
            var product = await _product.GetProduct(id);
            var cart = GetCurrentCart();

            foreach (var p in product)
            {
                var cartProduct = new CartProduct
                {
                    CartId = cart.Id,
                    ProductName = p.ProductName,
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
        public async Task<IActionResult> DeleteProductInCart(int id)
        {
            var product = await _context.CartProducts.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.CartProducts.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
