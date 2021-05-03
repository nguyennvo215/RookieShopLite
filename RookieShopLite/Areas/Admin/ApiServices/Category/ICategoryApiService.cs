using RookieShopLite.Areas.Admin.Models;
using RookieShopLite.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RookieShopLite.Areas.Admin.ApiServices.Category
{
    public interface ICategoryApiService
    {
        Task<IList<CategoryViewModel>> GetCategories();
        Task<CategoryViewModel> GetCategory(int id);
        Task<CategoryViewModel> PutCategory(int id, CategoryCreateRequest categoryCreateRequest);
        Task<CategoryViewModel> PostCategory(CategoryCreateRequest categoryCreateRequest);
        Task DeleteCategory(int id);
    }
}
