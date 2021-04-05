using RookieShopLite.Areas.Admin.Models;
using RookieShopLite.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RookieShopLite.Areas.Admin.ApiServices.Product
{
    interface IProductApiService
    {
        Task<IList<ProductViewModel>> GetProducts();
        Task<ProductViewModel> GetProduct(int id);
        Task<ProductViewModel> PutProduct(int id, ProductCreateRequest productCreateRequest);
        Task<ProductViewModel> PostProduct(ProductCreateRequest productCreateRequest);
        Task DeleteProduct(int id);
    }
}
