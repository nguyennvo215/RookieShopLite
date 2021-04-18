using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RookieShopLite.Areas.Admin.ApiServices.CartProduct
{
    public interface ICartProductApiService
    {
        Task AddProductToCart(int id);
        Task DeleteProductInCart(int id);
    }
}
