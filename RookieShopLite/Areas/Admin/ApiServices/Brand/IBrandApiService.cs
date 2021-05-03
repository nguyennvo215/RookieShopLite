using RookieShopLite.Areas.Admin.Models;
using RookieShopLite.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RookieShopLite.Areas.Admin.ApiServices.Brand
{
    public interface IBrandApiService
    {
        Task<IList<BrandViewModel>> GetBrands();
        Task<BrandViewModel> GetBrand(int id);
        Task<BrandViewModel> PutBrand(int id, BrandCreateRequest brandCreateRequest);
        Task<BrandViewModel> PostBrand(BrandCreateRequest brandCreateRequest);
        Task DeleteBrand(int id);
    }
}
