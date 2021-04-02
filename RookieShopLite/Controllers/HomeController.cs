using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RookieShopLite.Areas.Admin.ApiClients;
using RookieShopLite.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RookieShopLite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBrandApiService _brandApiService;

        public HomeController(ILogger<HomeController> logger, IBrandApiService brandApiService)
        {
            _logger = logger;
            _brandApiService = brandApiService;
        }

        public IActionResult Index()
        {
            return View();
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
