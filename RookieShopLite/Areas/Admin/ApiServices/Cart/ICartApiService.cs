using RookieShopLite.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RookieShopLite.Areas.Admin.ApiServices.Cart
{
    public interface ICartApiService
    {
        Task<IList<CartViewModel>> GetCartHistory();
        Task CheckOutCart(int id);
    }
}
