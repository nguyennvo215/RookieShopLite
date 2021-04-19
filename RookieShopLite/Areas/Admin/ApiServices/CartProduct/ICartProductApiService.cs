using RookieShopLite.ViewModel;
using System.Threading.Tasks;

namespace RookieShopLite.Areas.Admin.ApiServices.CartProduct
{
    public interface ICartProductApiService
    {
        Task AddProductToCart(int id);
        Task DeleteProductInCart(int id);
        Task<CartViewModel> GetCurrentCart();
    }
}
