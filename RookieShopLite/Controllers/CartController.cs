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

        [HttpPost("{Id}")]
        public async Task<IActionResult> AddToCart(int id)
        {
            await _cartProduct.AddProductToCart(id);
            string referer = Request.Headers["Referer"].ToString();
            return RedirectToAction(referer);
        }

        public async Task<ActionResult<CartViewModel>> CartDetails()
        {
            return await _cart.GetCurrentCart();
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
