using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RookieShopLite.Areas.Admin.ApiServices.Product;
using RookieShopLite.Data;
using RookieShopLite.Model;
using RookieShopLite.Models;
using RookieShopLite.ViewModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RookieShopLite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductApiService _product;

        public HomeController(ILogger<HomeController> logger, IProductApiService product)
        {
            _logger = logger;
            _product = product;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _product.GetProducts();
            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
