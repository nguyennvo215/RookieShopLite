using Microsoft.AspNetCore.Mvc;
using RookieShopLite.Areas.Admin.ApiServices.Category;
using System.Threading.Tasks;

namespace RookieShopLite.ViewComponents
{
    public class CategoryListViewComponent : ViewComponent
    {
        private readonly ICategoryApiService _category;

        public CategoryListViewComponent(ICategoryApiService category)
        {
            _category = category;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await _category.GetCategories();
            return View(items);
        }
    }
}
