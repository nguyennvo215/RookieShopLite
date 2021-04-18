using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RookieShopLite.Areas.Admin.ApiServices.Cart;
using RookieShopLite.Areas.Admin.ApiServices.Product;
using RookieShopLite.Data;
using RookieShopLite.Model;
using System.Linq;
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

        [HttpPost("{Id}")]
        [AllowAnonymous]
        public async Task<IActionResult> AddProductToCart(int id)
        {
            var product = await _product.GetProduct(id);
            var cart = _cart.GetCurrentCart();

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
