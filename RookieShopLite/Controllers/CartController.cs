using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using RookieShopLite.Data;
using RookieShopLite.ViewModel;
using System.Linq;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using RookieShopLite.Model;
using RookieShopLite.Areas.Admin.ApiServices.Product;

namespace RookieShopLite.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IProductApiService _product;

        public CartController(ApplicationDbContext context, IProductApiService product)
        {
            _context = context;
            _product = product;
        }

        [HttpPost("{Id}")]
        public async Task<IActionResult> AddToCart(int Id)
        {
            var product = await _product.GetProduct(Id);
            var getCart = await _context.Carts.FirstOrDefaultAsync(x => x.UserId == ClaimTypes.NameIdentifier && x.isCheckedOut == false);
            if (getCart == null )
            {
                var cart = new Cart
                {
                    UserId = ClaimTypes.NameIdentifier,
                    AddedDate = DateTime.Now,
                    isCheckedOut = false
                };

                _context.Carts.Add(cart);
                await _context.SaveChangesAsync();

                foreach (var p in product)
                {
                    var cartProduct = new CartProduct
                    {
                        CartId = cart.Id,
                        ProductName = p.ProductName,
                        ProductPriceBefore = p.ProductPriceBefore,
                        ProductPriceAfter = p.ProductPriceNow,
                        imgPath = p.images.FirstOrDefault(),
                    };
                    _context.CartProducts.Add(cartProduct);
                    await _context.SaveChangesAsync();
                }
            }
            foreach (var p in product)
            {
                var cartProduct = new CartProduct
                {
                    CartId = getCart.Id,
                    ProductName = p.ProductName,
                    ProductPriceBefore = p.ProductPriceBefore,
                    ProductPriceAfter = p.ProductPriceNow,
                    imgPath = p.images.FirstOrDefault(),
                };
                _context.CartProducts.Add(cartProduct);
                await _context.SaveChangesAsync();
            }
            return NoContent();
        }

        // GET: CartController/Details/5
        public async Task<ActionResult<CartViewModel>> Details(int id)
        {
            return View();
        }

        // GET: CartController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CartController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CartController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CartController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CartController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CartController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
