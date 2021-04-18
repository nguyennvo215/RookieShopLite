using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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


        public async Task AddProductToCart(int id)
        {
            var httpClient = _httpClientFactory.CreateClient("local");
            var content = JsonConvert.SerializeObject(id);
            var httpContent = new StringContent(content.ToString(), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("api/cartproducts", httpContent);
            response.EnsureSuccessStatusCode();
        }

        public Task DeleteProductInCart(int id)
        {
            throw new NotImplementedException();
        }
    }
}
