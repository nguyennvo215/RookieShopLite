using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RookieShopLite.Areas.Admin.ApiServices.Category;
using RookieShopLite.Areas.Admin.ApiServices.Product;
using RookieShopLite.Models;
using System.Diagnostics;
using System.Threading.Tasks;

namespace RookieShopLite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductApiService _product;
        private readonly ICategoryApiService _category;

        public HomeController(ILogger<HomeController> logger, IProductApiService product, ICategoryApiService category)
        {
            _logger = logger;
            _product = product;
            _category = category;
        }

        public async Task<IActionResult> Index(int categoryId)
        {
            if (categoryId != 0)
            {
                var products = await _product.GetProductsByCategory(categoryId);
                return View(products);
            }
            else
            {
                var products = await _product.GetProducts();
                return View(products);
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> ProductView(int id)
        {
            var product = await _product.GetProduct(id);
            return View(product);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
