using Newtonsoft.Json;
using RookieShopLite.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace RookieShopLite.Areas.Admin.ApiServices.Cart
{
    public class CartApiService : ICartApiService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CartApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task AddToCart(int id)
        {
            var httpClient = _httpClientFactory.CreateClient("local");
            var content = JsonConvert.SerializeObject(id);
            var httpContent = new StringContent(content.ToString(), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("api/carts", httpContent);
            response.EnsureSuccessStatusCode();
        }

        public async Task CheckOutCart(int id)
        {
            var httpClient = _httpClientFactory.CreateClient("local");
            var response = await httpClient.DeleteAsync("api/carts" + $"/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<IList<CartViewModel>> GetCartHistory()
        {
            var httpClient = _httpClientFactory.CreateClient("local");
            var response = await httpClient.GetAsync("api/carts");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IList<CartViewModel>>();
        }

        public async Task<CartViewModel> GetCurrentCart()
        {
            var httpClient = _httpClientFactory.CreateClient("local");
            var response = await httpClient.GetAsync("api/carts");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<CartViewModel>();
        }
    }
}
