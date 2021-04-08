﻿using RookieShopLite.Areas.Admin.Models;
using RookieShopLite.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RookieShopLite.Areas.Admin.ApiServices.Product
{
    interface IProductApiService
    {
        Task<IList<ProductViewModel>> GetProducts();
        Task<IList<ProductViewModel>> GetProduct(int id);
        Task<ProductViewModel> PutProduct(int id, ProductCreateRequest productCreateRequest);
        Task<ProductViewModel> PostProduct(ProductCreateRequest productCreateRequest);
        Task DeleteProduct(int id);
    }
}
