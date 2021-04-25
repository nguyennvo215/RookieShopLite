using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using RookieShopLite.Data;
using RookieShopLite.ViewModel;
using RookieShopLite.Areas.Admin.ApiServices.Product;
using RookieShopLite.Areas.Admin.ApiServices.Cart;
using RookieShopLite.Areas.Admin.ApiServices.CartProduct;

namespace RookieShopLite.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IProductApiService _product;
        private readonly ICartProductApiService _cartProduct;
        private readonly ICartApiService _cart;

        public CartController(ApplicationDbContext context, IProductApiService product, ICartProductApiService cartProduct, ICartApiService cart)
        {
            _context = context;
            _product = product;
            _cartProduct = cartProduct;
            _cart = cart;
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int id)
        {
            await _cartProduct.AddProductToCart(id);
            //return RedirectToAction(nameof(CartDetail));
            return Redirect("CartDetail");
        }

        public async Task<ActionResult<CartViewModel>> CartDetail()
        {
            var cart = await _cartProduct.GetCurrentCart();
            return View(cart);
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
