using Microsoft.AspNetCore.Mvc;
using RookieShopLite.Areas.Admin.ApiServices.Brand;
using System.Threading.Tasks;

namespace RookieShopLite.ViewComponents
{
    public class BrandListViewComponent : ViewComponent
    {
        private readonly IBrandApiService _brand;

        public BrandListViewComponent(IBrandApiService brand)
        {
            _brand = brand;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await _brand.GetBrands();
            return View(items);
        }
    }
}
