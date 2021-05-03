using RookieShopLite.Areas.Admin.Models;
using RookieShopLite.ViewModel;
using System.Threading.Tasks;

namespace RookieShopLite.Areas.Admin.ApiServices.CartProduct
{
    public interface ICartProductApiService
    {
        Task AddProductToCart(CartProductCreateRequest request);
        Task DeleteProductInCart(int id);
        Task<CartViewModel> GetCurrentCart();
    }
}
