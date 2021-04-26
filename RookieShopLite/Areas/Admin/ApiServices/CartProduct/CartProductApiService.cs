using Newtonsoft.Json;
using RookieShopLite.Areas.Admin.Models;
using RookieShopLite.ViewModel;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace RookieShopLite.Areas.Admin.ApiServices.CartProduct
{
    public class CartProductApiService : ICartProductApiService
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public CartProductApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task AddProductToCart(CartProductCreateRequest request)
        {
            var httpClient = _httpClientFactory.CreateClient("local");
            var content = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("api/cartproducts", httpContent);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteProductInCart(int id)
        {
            var httpClient = _httpClientFactory.CreateClient("local");
            var content = JsonConvert.SerializeObject(id);
            var httpContent = new StringContent(content.ToString(), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("api/cartproducts", httpContent);
            response.EnsureSuccessStatusCode();
        }

        public async Task<CartViewModel> GetCurrentCart()
        {
            var httpClient = _httpClientFactory.CreateClient("local");
            var response = await httpClient.GetAsync("api/cartproducts");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<CartViewModel>();
        }
    }
}
