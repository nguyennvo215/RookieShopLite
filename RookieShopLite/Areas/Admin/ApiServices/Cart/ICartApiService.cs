using Microsoft.AspNetCore.Mvc;
using RookieShopLite.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RookieShopLite.Areas.Admin.ApiServices.Cart
{
    public interface ICartApiService
    {
        Task<IList<CartViewModel>> GetCartHistory();
        Task<CartViewModel> GetCurrentCart();
        Task AddToCart(int id);
    }
}
